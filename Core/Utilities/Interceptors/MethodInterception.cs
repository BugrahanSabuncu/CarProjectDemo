using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Interceptors
{
    public abstract class MethodInterception:MethodInterceptionBaseAttribute
    {
        public virtual void onBefore(IInvocation invocation) { }
        public virtual void onAfter(IInvocation invocation) { }
        public virtual void onException(IInvocation invocation, System.Exception e) { }
        public virtual void onSuccess(IInvocation invocation) { }
        public override void Intercept(IInvocation invocation)
        {
            var isSuccess = true;
            onBefore(invocation);
            try
            {
                invocation.Proceed();
            }
            catch (Exception e)
            {
                isSuccess = false;
                onException(invocation,e);
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    onSuccess(invocation);
                }
            }
            onAfter(invocation);
        }

    }
}
