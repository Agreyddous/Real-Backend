using Real.Backend.Shared.Commands;
using System;

namespace Real.Backend.Domain.Commands.Input
{
	public class UpdateUserCommand : ICommand
	{
		public Guid Id { get; set; }
		public string Firstname { get; set; }
		public string Middlename { get; set; }
		public string Lastname { get; set; }
		public string Address { get; set; }
		public string ProfileImage { get; set; }
	}
}