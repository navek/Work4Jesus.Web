using System.Web.Http;
using Work4Jesus.RepoService.Repositories;

namespace Work4Jesus.Web.Controllers
{
    public class TestController : ApiController
    {
        IUserRepository _userRepository;
        public TestController(IUserRepository userRepo)
        {
            _userRepository = userRepo;
        }

        [HttpGet]
        public string Execute()
        {
            return "OK";
        }
    }
}
