namespace Base
{
    public interface ILookup
    {
        
        #if USE_KEY_SUFFIX_OID
            long Oid { get; set; }
        #endif

        #if USE_KEY_SUFFIX_ID
            long Id { get; set; }
        #endif

        string Name { get; set; }
        
    }
}