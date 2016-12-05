using CommonServiceLocator.NinjectAdapter.Unofficial;
using Microsoft.Practices.ServiceLocation;
using Ninject;
using Work4Jesus.Ioc.Modules;

namespace Work4Jesus.Ioc
{
    public class Ioc
    {
        public IKernel Kernel { get; }

        public Ioc()
        {
            Kernel = GetNinjectModules();
            ServiceLocator.SetLocatorProvider(() => new NinjectServiceLocator(Kernel));
        }

        public StandardKernel GetNinjectModules()
        {
            return new StandardKernel(new RepositoryModule(), new ServiceModule());
        }
    }
}