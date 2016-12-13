using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using Ninject.Syntax;

namespace Work4Jesus.Web.App_Start
{
    public class NinjectResolver : NinjectScope, System.Web.Http.Dependencies.IDependencyResolver
    {
        private Ninject.IKernel _kernel;
        public NinjectResolver(Ninject.IKernel root) : base(root)
        {
            _kernel = root;
        }

        public IDependencyScope BeginScope()
        {
            return new NinjectScope(_kernel.BeginBlock());
        }
    }
}