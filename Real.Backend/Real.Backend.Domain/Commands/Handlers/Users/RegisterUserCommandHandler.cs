using FluentValidator;
using Real.Backend.Domain.Commands.Input;
using Real.Backend.Domain.Commands.Results;
using Real.Backend.Domain.Enities;
using Real.Backend.Domain.Repositories;
using Real.Backend.Domain.ValueObjects;
using Real.Backend.Shared.Commands;

namespace Real.Backend.Domain.Commands.Handlers.Users
{
	public class RegisterUserCommandHandler : Notifiable, ICommandHandler<RegisterUserCommand>
	{
		private readonly IUserRepository _repository;

		public RegisterUserCommandHandler(IUserRepository repository) => _repository = repository;

		public ICommandResult Handle(RegisterUserCommand Command)
		{
			ICommandResult result = null;

			if (Command != null)
			{
				if (!_repository.UsernameExists(Command.Username))
				{
					Name name = new Name(Command.Firstname, Command.Lastname, Command.Middlename);
					Login login = new Login(Command.Username, Command.Password);
					Email email = new Email(Command.Email);

					User user = new User(name, email, login, Command.Gender, Command.ProfileImage, Command.Birthday);

					if (user.Valid)
					{
						_repository.Add(user);

						result = new GenericCommandResult(user.Id, "User " + user.Login.Username + " Created");
					}

					else
						AddNotifications(user.Notifications);
				}

				else
					AddNotification("Username", "Username already taken");
			}

			else
				AddNotification("Command", "Invalid command");

			return result;
		}
	}
}