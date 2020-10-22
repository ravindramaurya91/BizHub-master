using System;

namespace Base
{
    public interface ITables
    {
        IMetadata<T> GetTable<T>(Type type) where T : IModel;
    }
}