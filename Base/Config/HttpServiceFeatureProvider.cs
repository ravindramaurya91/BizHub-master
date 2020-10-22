using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace Base
{

    public class HttpServiceFeatureProvider : IApplicationFeatureProvider<ControllerFeature>
    {

        public void PopulateFeature(IEnumerable<ApplicationPart> parts, ControllerFeature feature)
        {

            var currentAssembly = typeof(HttpServiceFeatureProvider).Assembly;

            var candidates =
                from a in AppDomain.CurrentDomain.GetAssemblies()
                from t in a.GetTypes()
                let attributes = t.GetCustomAttributes(typeof(HttpServiceAttribute), true)
                where attributes != null && attributes.Length > 0
                select new { Type = t, Attributes = attributes.Cast<HttpServiceAttribute>() };

            foreach (var candidate in candidates)
            {
                
                if (candidate.Type.IsGenericType)
                {

                    List<TypeInfo> typeInfos = GetPermutations(candidate.Type);

                    foreach (var typeInfo in typeInfos)
                    {
                        feature.Controllers.Add(typeInfo);
                    }

                }
                else
                {

                    TypeInfo typeInfo = candidate.Type.GetTypeInfo();
                    feature.Controllers.Add(typeInfo);

                }

            }

        }

        public List<TypeInfo> GetPermutations(Type serviceType)
        {
            List<TypeInfo> results = new List<TypeInfo>();
            IEnumerable<Type> innerTypes = null;

            // Console.Error.WriteLine($"INFO: Registering controllers for generic http service {serviceType.Name}.");

            var typeargs = serviceType.GetGenericArguments();

            if (typeargs.Length == 1)
            {
                foreach (var typearg in typeargs)
                {
                    // Console.Error.WriteLine($"    ######## Generic Type Argument: {typearg.Name}");

                    var constraints = typearg.GetGenericParameterConstraints();

                    if (constraints.Length == 0)
                    {
                        Console.Error.WriteLine($"ERROR: Generic HttpService {serviceType.Name} not initialized due to missing generic type constraint.");
                    }
                    else if (constraints.Length == 1)
                    {
                        var constraint = constraints[0];

                        if (constraint.IsInterface || constraint.IsClass)
                        {
                            innerTypes = AppDomain.CurrentDomain.GetAssemblies()
                                .SelectMany(s => s.GetTypes())
                                .Where(p => constraint.IsAssignableFrom(p) && ! constraint.Equals(p) && !p.IsAbstract && !p.IsInterface);
                        }
                    }
                    else
                    {
                        Console.Error.WriteLine($"ERROR: Generic HttpService {serviceType.Name} not initialized due to multiple generic type constraints. Only one generic type constraint supported.");
                    }

                }
            }
            else
            {
                Console.Error.WriteLine($"ERROR: Generic HttpService {serviceType.Name} not initialized due to multiple generic arguments. Only one generic argument supported.");
            }


            if (innerTypes != null)
            {
                foreach (var innerType in innerTypes)
                {
                    Console.Error.WriteLine($"INFO: Registering generic http service {serviceType.Name} with type {innerType.Name}.");
                    TypeInfo typeInfo = serviceType.MakeGenericType(innerType).GetTypeInfo();
                    results.Add(typeInfo);
                }
            }

            return results;
        }

    }

}