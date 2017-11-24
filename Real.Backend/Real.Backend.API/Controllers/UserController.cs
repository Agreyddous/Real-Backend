using Real.Backend.Infra.Transactions;
using Real.Backend.Domain.Repositories;

namespace Real.Backend.API.Controllers
{
	public class UserController : BaseController
	{
		private readonly IUserRepository _repository;
		public UserController(IUow uow, IUserRepository repository) : base(uow)
		{
			_repository = repository;
		}
	}
}