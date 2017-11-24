using Real.Backend.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using Real.Backend.Domain.Commands.Input;
using Real.Backend.Domain.Enities;
using Real.Backend.Infra.Context;
using System.Data.Entity;

namespace Real.Backend.Infra.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly RealContext _context;

		public UserRepository(RealContext context) => _context = context;

		public bool Add(User user)
		{
			if (user.Valid)
				_context.Users.Add(user);

			return user.Valid;
		}

		public bool EmailExists(string email) => _context.Users.Any(x => x.Email.Address == email.Trim());
		public User Get(Guid id) => _context.Users.FirstOrDefault(x => x.Id == id);
		public User Get(string username) => _context.Users.FirstOrDefault(x => x.Login.Username == username);
		public bool IdExists(Guid id) => _context.Users.Any(x => x.Id == id);
		public List<User> Search(SearchUserCommand command) => _context.Users.AsNoTracking().Where(x => x.Login.Username.Contains(command.Username) || x.Name.Firstname.Contains(command.FirstName) || x.Name.Middlename.Contains(command.MiddleName) || x.Name.Lastname.Contains(command.LastName) || x.Email.Address.Contains(command.Email)).ToList();
		public bool Update(User user)
		{
			if (user.Valid)
				_context.Entry(user).State = EntityState.Modified;

			return user.Valid;
		}

		public bool UsernameExists(string username) => _context.Users.Any(x => x.Login.Username == username.Trim());
	}
}