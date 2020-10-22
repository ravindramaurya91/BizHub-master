namespace Base
{
    public abstract class Metadata<T> : IMetadata<T> where T : IModel
    {

        private string tableAlias = null;


        #if USE_KEY_SUFFIX_OID
            public abstract ColumnInfo Oid { get; }
        #endif

        #if USE_KEY_SUFFIX_ID
            public abstract ColumnInfo Id { get; }
        #endif
        
        public abstract string DbTableName { get; }

        public string DbTableAlias
        {
            get
            {
                if (tableAlias == null)
                {
                    return DbTableName;
                }
                else
                {
                    return tableAlias;
                }
            }
            set
            {
                this.tableAlias = value;
            }
        }

        protected ColumnInfo DefineColumn(string name)
        {
            return new ColumnInfo(name, DbTableName, DbTableAlias);
        }

        protected ColumnInfo DefineResultColumn(string name)
        {
            return new ColumnInfo(name, DbTableName, DbTableAlias, true);
        }

        public static implicit operator string(Metadata<T> metadata)
        {
            if (metadata.DbTableName.Equals(metadata.DbTableAlias))
            {
                return metadata.DbTableName;
            }
            else
            {
                return $"{metadata.DbTableName} as {metadata.DbTableAlias}";
            }
        }

    }
}