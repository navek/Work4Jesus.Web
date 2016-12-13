using Ninject.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

namespace Work4Jesus.Web.App_Start
{
    public class NinjectScope : IDependencyScope
    {
        protected Ninject.Syntax.IResolutionRoot _root;
        public NinjectScope(Ninject.Syntax.IResolutionRoot root)
        {
            _root = root;
        }
        public void Dispose()
        {
            var disposable = _root as IDisposable;
            disposable?.Dispose();
            _root = null;
        }

        public object GetService(Type serviceType)
        {
            var request = _root.CreateRequest(serviceType, null, new Parameter[0], true, true);
            return _root.Resolve(request).SingleOrDefault();
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            var request = _root.CreateRequest(serviceType, null, new Parameter[0], true, true);
            return _root.Resolve(request).ToList();
        }
    }
}