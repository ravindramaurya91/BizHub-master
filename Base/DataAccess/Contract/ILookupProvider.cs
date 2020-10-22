using SqlKata;

namespace Base
{
    
    public interface ILookupProvider<T> where T : IModel
    {
        Query CreateLookupQuery();
    }

}