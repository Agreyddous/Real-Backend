using FluentValidator;
using Real.Backend.Domain.Commands.Input;
using Real.Backend.Domain.Commands.Results;
using Real.Backend.Domain.Enities;
using Real.Backend.Domain.Repositories;
using Real.Backend.Domain.ValueObjects;
using Real.Backend.Shared.Commands;

namespace Real.Backend.Domain.Commands.Handlers.Users
{
	public class UpdateUserCommandHandler : Notifiable, ICommandHandler<UpdateUserCommand>
	{
		private readonly IUserRepository _repository;

		public UpdateUserCommandHandler(IUserRepository repository) => _repository = repository;

		public ICommandResult Handle(UpdateUserCommand Command)
		{
			ICommandResult result = null;

			if (Command != null)
			{
				User user = _repository.Get(Command.Id);

				Command.Firstname = Command.Firstname ?? user.Name.Firstname;
				Command.Middlename = Command.Middlename ?? user.Name.Middlename;
				Command.Lastname = Command.Lastname ?? user.Name.Lastname;

				Command.Address = Command.Address ?? user.Email.Address;
				Command.ProfileImage = Command.ProfileImage ?? user.ProfileImage;

				Name name = new Name(Command.Firstname, Command.Lastname, Command.Middlename);
				Email email = new Email(Command.Address);

				user.Update(name);
				user.Update(email);
				user.Update(Command.ProfileImage);

				if (user.Valid)
				{
					_repository.Update(user);

					result = new GenericCommandResult(user.Id, "User " + user.Login.Username + " Updated");
				}

				else
					AddNotifications(user.Notifications);
			}

			else
				AddNotification("Command", "Can't be null");

			return result;
		}
	}
}