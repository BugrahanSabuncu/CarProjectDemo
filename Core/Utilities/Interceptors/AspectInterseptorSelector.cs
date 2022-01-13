using System;
using System.Reflection;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Castle.DynamicProxy;

namespace Core.Utilities.Interceptors
{
    public class AspectInterseptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
                (true).ToList();
            var methodAttributes = type.GetMethod(method.Name)
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);

            return classAttributes.OrderBy(p => p.Priority).ToArray();

        }
    }
}
