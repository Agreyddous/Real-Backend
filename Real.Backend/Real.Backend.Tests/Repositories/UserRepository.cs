using Real.Backend.Domain.Repositories;
using System;
using System.Collections.Generic;
using Real.Backend.Domain.Commands.Input;
using Real.Backend.Domain.Enities;
using Real.Backend.Domain.ValueObjects;
using Real.Backend.Shared.Enums;

namespace Real.Backend.Tests.Repositories
{
	public class UserRepository : IUserRepository
	{
		public User TestUser { get; set; }
		public bool Add(User user)
		{
			if (user.Valid)
				TestUser = user;

			return user.Valid;
		}

		public bool EmailExists(string email) => false;
		public User Get(Guid id) => new User(new Name("Fernando", "Gomes"), new Email("fernandovbmgomes@hotmail.com"), new Login("Nando", "PassPass"), EGender.Male, "Profil Pic Goes Here", DateTime.Now);
		public User Get(string username) => throw new NotImplementedException();
		public bool IdExists(Guid id) => false;
		public List<User> Search(SearchUserCommand command) => throw new NotImplementedException();
		public bool Update(User user)
		{
			if (user.Valid)
				TestUser = user;

			return user.Valid;
		}

		public bool UsernameExists(string username) => false;
	}
}