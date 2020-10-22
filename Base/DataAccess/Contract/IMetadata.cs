namespace Base
{
    public interface IMetadata<T> where T : IModel
    {
        
        #if USE_KEY_SUFFIX_OID
            ColumnInfo Oid { get; }
        #endif

        #if USE_KEY_SUFFIX_ID
            ColumnInfo Id { get; }
        #endif

        string DbTableName { get; }

        string DbTableAlias { get; }
        
    }
}