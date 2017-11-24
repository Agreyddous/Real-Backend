using FluentValidator;
using FluentValidator.Validation;

namespace Real.Backend.Domain.ValueObjects
{
	public class Email : Notifiable
	{
		protected Email () { }

		public Email(string address)
		{
			if (address != null)
			{
				Address = address.Trim();

				AddNotifications(new ValidationContract().Requires()
					.IsEmail(Address, "Address", "Not valid"));
			}

			else
				AddNotification("Email", "Can't be null");
		}

		public string Address { get; private set; }

		public override string ToString() => Address;
	}
}