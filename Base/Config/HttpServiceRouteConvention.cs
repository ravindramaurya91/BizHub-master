using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace Base
{

    public class HttpServiceRouteConvention : IControllerModelConvention
    {

        private HttpServiceAttribute GetHttpServiceAttribute(Type type)
        {
            var attributes = type.GetCustomAttributes(typeof(HttpServiceAttribute), true);

            if (attributes.Length > 0)
            {
                return (HttpServiceAttribute) attributes[0];
            }

            return null;
        }

        public void Apply(ControllerModel controller)
        {

            var attribute = GetHttpServiceAttribute(controller.ControllerType);

            if (attribute == null)
            {
                return;
            }
            
            bool isGeneric = controller.ControllerType.IsGenericType;
            string genericName = null;

            if (isGeneric)
            {
                Type[] genericTypes = controller.ControllerType.GetGenericArguments().Where(t => !t.IsGenericParameter).ToArray();

                if (genericTypes.Length != 1)
                {
                    return;
                }

                genericName = genericTypes[0].Name;
            }
            
            string groupName = null;

            if (attribute.Name != null)
            {
                if (isGeneric)
                {
                    groupName = attribute.Name.Replace("[type]", genericName);
                }
                else
                {
                    groupName = attribute.Name;
                }
            }
            else
            {
                if (isGeneric)
                {
                    groupName = genericName;
                }
                else
                {
                    groupName = controller.ControllerType.Name;
                }
            }

            controller.ApiExplorer.GroupName = groupName;

            var actionsToRemove = new List<ActionModel>();

            foreach (var action in controller.Actions)
            {

                bool hasHttpAttribute = action.Attributes.Where(att => att.GetType().Name.StartsWith("Http")).Count() > 0;

                if (! hasHttpAttribute)
                {
                    actionsToRemove.Add(action);
                    continue;
                }

                if (action.Selectors != null && action.Selectors.Count > 0)
                {
                    var selector = action.Selectors[0];
                    var arm = selector.AttributeRouteModel;

                    if (arm == null)
                    {
                        var newAttribute = new RouteAttribute($"/api/{groupName}/[action]");
                        arm = new AttributeRouteModel(newAttribute);
                        selector.AttributeRouteModel = arm;
                    }

                }
            }

            foreach (var actionToRemove in actionsToRemove)
            {
                // Console.Error.WriteLine($"Removing Action: {actionToRemove.DisplayName}");
                controller.Actions.Remove(actionToRemove);
            }

        }
    }




}