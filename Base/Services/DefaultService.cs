using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetaPoco;
using PetaPoco.SqlKata;
using SqlKata;

namespace Base
{

    public class DefaultService<T> : ILookupProvider<T> where T : IModel, new()
    {

        [HttpGet]
        public virtual IEnumerable<T> Fetch(bool includeResultColumns = false)
        {
            Query query = CreateFetchQuery(includeResultColumns);
            // query.LogSql($"Fetch {typeof(T).Name}");
            return query.Fetch<T>();
        }

        [HttpPost]
        public virtual T Save([FromBody] T record)
        {
            var db = Database.GetInstance();
            db.Save(record);
            return record;
        }

        [HttpPost]
        public virtual void Delete(long key)
        {
            var db = Database.GetInstance();
            db.Delete<T>(key);
        }

        [HttpGet]
        #if USE_KEY_SUFFIX_OID
            public T FindByOid(long oid, bool includeResultColumns = false)
        #else
            public T FindById(long id, bool includeResultColumns = false)
        #endif
        {
            var table = Context.Get<IMetadata<T>>();
            var result = CreateFetchQuery(includeResultColumns)
                #if USE_KEY_SUFFIX_OID
                    .Where(table.Oid, oid)
                #else
                    .Where(table.Id, id)
                #endif
                .FirstOrDefault<T>();
            return result;
        }

        [HttpGet]
        public virtual Page<LookupImpl> Lookup(string filter)
        {
            var lookup = CreateLookupQuery();
            var query = Database.CreateQuery()
                .From(lookup.As("lookup"));

            if (filter != null && filter.Length > 0)
            {
                query.WhereContains("name", filter, false);
            }

            return query.Page<LookupImpl>(1, 20);
        }

        public virtual Query CreateDefaultQuery()
        {
            var table = Context.Get<IMetadata<T>>();
            return Database.CreateQuery()
                .Select($"{table.DbTableName}.*")
                .From(table.DbTableName);
        }

        public virtual Query CreateLookupQuery()
        {
            var table = Context.Get<IMetadata<T>>();

            var query = Database.CreateQuery();

            #if USE_KEY_SUFFIX_OID
                query.Select(table.Oid);
                query.SelectRaw($"CAST({table.Oid.QualifiedRaw} AS VARCHAR(20)) AS name");
            #endif

            #if USE_KEY_SUFFIX_ID
                query.Select(table.Id);
                query.SelectRaw($"CAST({table.Id.QualifiedRaw} AS VARCHAR(20)) AS name");
            #endif

            query.From(table.DbTableName);

            return query;
        }

        public virtual Query CreateResultQuery()
        {
            return CreateDefaultQuery();
        }

        public Query CreateFetchQuery(bool includeResultColumns = false)
        {
            if (includeResultColumns)
            {
                return CreateResultQuery();
            }
            else
            {
                return CreateDefaultQuery();
            }
        }

        protected void AddLookupToQuery<L>(Query mainQuery, ColumnInfo columnAlias, ColumnInfo columnFk) where L : IModel
        {

            ILookupProvider<L> lookupProvider = Context.Get<ILookupProvider<L>>();

            string subQueryAlias = columnAlias.Unqualified;
            string keyName = null;
            
            #if USE_KEY_SUFFIX_OID
                keyName = "oid";
            #endif

            #if USE_KEY_SUFFIX_ID
                keyName = "id";
            #endif

            Query subQuery = lookupProvider.CreateLookupQuery().As(subQueryAlias);
            mainQuery.LeftJoin(subQuery, join => join.On($"{subQueryAlias}.{keyName}", columnFk.Qualified));
            mainQuery.Select($"{columnAlias.Unqualified}.name as {columnAlias.Unqualified}");
        }

    }

}
