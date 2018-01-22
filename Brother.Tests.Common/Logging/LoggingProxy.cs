using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Activation;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;
using System.Runtime.Remoting.Services;

namespace Brother.Tests.Common.Logging
{

    [DebuggerStepThrough]
    public class LoggingProxy : RealProxy 
    {
        private static readonly string[] IgnoreMethodNames = { "ToString" };

        private readonly object _target;

        public static TT Wrap<TT>(TT target) 
        {
            return (TT)new LoggingProxy( target).GetTransparentProxy();
        }

        public LoggingProxy( object target) : this(target, target.GetType()) 
        {
        }

        public LoggingProxy(object target, Type classToProxy) : base(classToProxy)
        {
            this._target = target;
        }

        public override IMessage Invoke(IMessage msg)
        {
            IMessage response = null;
            IMethodCallMessage call = (IMethodCallMessage)msg;
            IConstructionCallMessage ctor = call as IConstructionCallMessage;

            if (ctor != null)
            {
                RealProxy sp = RemotingServices.GetRealProxy(this._target);
                sp.InitializeServerObject(ctor);
                MarshalByRefObject tp = this.GetTransparentProxy() as MarshalByRefObject;
                response = EnterpriseServicesHelper.CreateConstructionReturnMessage(ctor, tp);
            }
            else
            {
                response = this.Invoke(call);
            }

            return response;
        }

        private IMessage Invoke(IMethodCallMessage call)
        {
            ILoggingService _loggingService = (_target is IILoggingService) ?
                ((IILoggingService)_target).LoggingService : null ;

            bool isIgnoreLogging = IgnoreMethodNames.Any(s => s == call.MethodBase.Name);
            if (_loggingService != null && isIgnoreLogging == false)
            {
                LoggingUtil.LoggingOnMethodEntry(_loggingService, _target, call.MethodBase, call.Args);
            }             
            ReturnMessage response = RemotingServices.ExecuteMessage((MarshalByRefObject)_target, call) as ReturnMessage;
            if (_loggingService != null && isIgnoreLogging == false && IsIgnoreLoggingInstance(response) == false )
            {
                _loggingService.WriteLog(LoggingLevel.DEBUG, "<< {0}", response.ReturnValue);
            }
            return response;
        }

        private bool IsIgnoreLoggingInstance(ReturnMessage response)
        {
            if (response == null || response.ReturnValue == null ) return true;
            if (typeof(void) == response.ReturnValue.GetType()) return true;
            return false;
        }
    }


    [AttributeUsage(AttributeTargets.Class, Inherited = true)]
    public class LoggingAttribute : ProxyAttribute
    {
        public LoggingAttribute()
        { }

        public override MarshalByRefObject CreateInstance(Type serverType)
        {
            MarshalByRefObject target = base.CreateInstance(serverType);
            LoggingProxy proxy = new LoggingProxy(target, serverType);

            return (MarshalByRefObject)proxy.GetTransparentProxy();
        }
    }

}
