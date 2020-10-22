namespace Base
{
    public interface IModel
    {

        #if USE_KEY_SUFFIX_OID
            long Oid { get; set; }
        #endif

        #if USE_KEY_SUFFIX_ID
            long Id { get; set; }
        #endif

    }
}