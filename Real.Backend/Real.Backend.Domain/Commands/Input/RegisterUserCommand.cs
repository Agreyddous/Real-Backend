using Real.Backend.Shared.Commands;
using Real.Backend.Shared.Enums;
using System;

namespace Real.Backend.Domain.Commands.Input
{
	public class RegisterUserCommand : ICommand
	{
		public string Firstname { get; set; }
		public string Middlename { get; set; }
		public string Lastname { get; set; }

		public string Email { get; set; }

		public string Username { get; set; }
		public string Password { get; set; }

		public EGender Gender { get; set; }
		public string ProfileImage { get; set; }
		public DateTime Birthday { get; set; }
	}
}