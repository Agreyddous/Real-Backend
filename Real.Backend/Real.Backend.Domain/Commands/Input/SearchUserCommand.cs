using Real.Backend.Shared.Commands;

namespace Real.Backend.Domain.Commands.Input
{
	public class SearchUserCommand : ICommand
	{
		public string Username { get; set; }
		public string FirstName { get; set; }
		public string MiddleName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
	}
}