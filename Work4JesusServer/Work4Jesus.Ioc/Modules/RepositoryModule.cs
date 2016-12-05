using System.IO;
using System.Web;
using Ninject.Modules;
using Work4Jesus.RepoService.Repositories;
using WorkForJesus.RepoServiceImplementation.Repository;

namespace Work4Jesus.Ioc.Modules
{
    public class RepositoryModule : NinjectModule
    {
        public override void Load()
        {
            var data = Path.Combine(HttpRuntime.AppDomainAppPath, "App_Data");

            Bind<IUserRepository>()
                .To<UserRepository>()
                .WithConstructorArgument(Path.Combine(data, "user_repository.json"));

            Bind<IEventRepository>()
                .To<EventRepository>()
                .WithConstructorArgument(Path.Combine(data, "event_repository.json"));
        }
    }
}