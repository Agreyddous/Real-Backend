using Real.Backend.Domain.Commands.Input;
using Real.Backend.Domain.Enities;
using System;
using System.Collections.Generic;

namespace Real.Backend.Domain.Repositories
{
	public interface IUserRepository
	{
		User Get(Guid id);
		User Get(string username);
		List<User> Search(SearchUserCommand command);
		bool UsernameExists(string username);
		bool EmailExists(string email);
		bool IdExists(Guid id);
		bool Add(User user);
		bool Update(User user);
	}
}