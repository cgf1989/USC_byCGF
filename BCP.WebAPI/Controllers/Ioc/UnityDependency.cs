using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using Microsoft.Practices.Unity;
using BCP.Domain;

namespace BCP.WebAPI.Controllers
{
    public class UnityDependency : IDependencyResolver, IDependencyScope
    {
        UnityBootStrapper _unityBootStrapper = null;

        public UnityDependency()
        {
            if (_unityBootStrapper == null)
                _unityBootStrapper = new UnityBootStrapper();
            _unityBootStrapper.Bindings();
        }

        public IDependencyScope BeginScope()
        {
            //throw new NotImplementedException();
            return this;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == null) return null;
            try
            {
                return _unityBootStrapper.UnityContainer.Resolve(serviceType);
            }
            catch (Exception ex)
            { }
            return null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _unityBootStrapper.UnityContainer.ResolveAll(serviceType);
        }

        public void Dispose()
        {
            //throw new NotImplementedException();           
        }
    }
}