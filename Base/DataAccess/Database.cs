using System;
using PetaPoco;
using SqlKata;

namespace Base
{
    public class Database
    {

        public static IDatabase GetInstance() => Context.Get<IDatabase>();

        public static Query CreateQuery() => new Query();

    }
}