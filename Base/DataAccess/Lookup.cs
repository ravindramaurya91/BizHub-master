namespace Base
{

    public class LookupImpl : ILookup
    {

        #if USE_KEY_SUFFIX_OID
            public long Oid { get; set; }
        #endif

        #if USE_KEY_SUFFIX_ID
            public long Id { get; set; }
        #endif

        public string Name {get;set;}

    }

}