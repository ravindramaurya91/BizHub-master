using System;
using System.Collections.Generic;
using System.Text.Json;
using PetaPoco;

namespace Base
{
    [Serializable]
    public class Record<T> where T : IModel, new()
    {
        #region Fields 
        private bool _editInProgress = false;
        private bool _deleteMe = false;
        #endregion Fields

        private static IDatabase db { get { return Context.Get<IDatabase>(); } }
        public static void Save(T record) { db.Save(record); }
        public int Delete() { return db.Delete(this); }
        public static int Delete(object primaryKey) { return db.Delete<T>(primaryKey); }
        public bool IsNew() { return db.IsNew(this); }
        public static bool Exists(object primaryKey) { return db.Exists<T>(primaryKey); }
        public static bool Exists(string sql, params object[] args) { return db.Exists<T>(sql, args); }
        public static T SingleOrDefault(object primaryKey) { return db.SingleOrDefault<T>(primaryKey); }
        public static T SingleOrDefault(string sql, params object[] args) { return db.SingleOrDefault<T>(sql, args); }
        public static T SingleOrDefault(Sql sql) { return db.SingleOrDefault<T>(sql); }
        public static T FirstOrDefault(string sql, params object[] args) { return db.FirstOrDefault<T>(sql, args); }
        public static T FirstOrDefault(Sql sql) { return db.FirstOrDefault<T>(sql); }
        public static T Single(object primaryKey) { return db.Single<T>(primaryKey); }
        public static T Single(string sql, params object[] args) { return db.Single<T>(sql, args); }
        public static T Single(Sql sql) { return db.Single<T>(sql); }
        public static T First(string sql, params object[] args) { return db.First<T>(sql, args); }
        public static T First(Sql sql) { return db.First<T>(sql); }
        public static List<T> Fetch(string sql, params object[] args) { return db.Fetch<T>(sql, args); }
        public static List<T> Fetch(Sql sql) { return db.Fetch<T>(sql); }
        public static List<T> Fetch(long page, long itemsPerPage, string sql, params object[] args) { return db.Fetch<T>(page, itemsPerPage, sql, args); }
        public static List<T> Fetch(long page, long itemsPerPage, Sql sql) { return db.Fetch<T>(page, itemsPerPage, sql); }
        public static List<T> SkipTake(long skip, long take, string sql, params object[] args) { return db.SkipTake<T>(skip, take, sql, args); }
        public static List<T> SkipTake(long skip, long take, Sql sql) { return db.SkipTake<T>(skip, take, sql); }
        public static Page<T> Page(long page, long itemsPerPage, string sql, params object[] args) { return db.Page<T>(page, itemsPerPage, sql, args); }
        public static Page<T> Page(long page, long itemsPerPage, Sql sql) { return db.Page<T>(page, itemsPerPage, sql); }
        public static IEnumerable<T> Query(string sql, params object[] args) { return db.Query<T>(sql, args); }
        public static IEnumerable<T> Query(Sql sql) { return db.Query<T>(sql); }

        #region Vitual Metods
        public virtual void Save() { db.Save(this); }
        public virtual void CascadingDelete() { Delete(); }
        public static string ToJson(T obj) { return JsonSerializer.Serialize<T>(obj); }
        public static T  FromJson(string tsJson) { return JsonSerializer.Deserialize<T>(tsJson); }
        #endregion (Vitual Metods)

        #region Base Extended Properties
        [Ignore]
        public bool EditInProgress {
            get { return _editInProgress; }
            set { _editInProgress = value; }
        }
        [Ignore]
        public bool DeleteMe {
            get { return _deleteMe; }
            set { _deleteMe = value; }
        }
        #endregion (Base Extended Properties)
    }
}