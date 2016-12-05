using Ninject.Modules;
using Work4Jesus.RepoService;
using WorkForJesus.RepoServiceImplementation.Service;

namespace Work4Jesus.Ioc.Modules
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserService>().To<UserService>();
            Bind<IEventService>().To<EventService>();
        }
    }
}