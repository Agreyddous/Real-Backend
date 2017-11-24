using FluentValidator;
using FluentValidator.Validation;

namespace Real.Backend.Domain.ValueObjects
{
	public class Name : Notifiable
	{
		protected Name() { }
		public Name(string firstname, string lastname, string middlename = "")
		{
			if(firstname == null)
				AddNotification("Firstname", "Is null");

			if(lastname == null)
				AddNotification("Lastname", "Is null");

			if(middlename == null)
				middlename = "";

			if(Valid)
			{
				Firstname = firstname;
				Middlename = middlename;
				Lastname = lastname;

				AddNotifications(new ValidationContract().Requires()
					.HasMinLen(Firstname, 3, "Firstname", "Is too short").HasMaxLen(Firstname, 15, "Firstname", "Is too long")
					.HasMaxLen(Middlename, 30, "Middlename", "Is too long")
					.HasMinLen(Lastname, 3, "Lastname", "Is too short").HasMaxLen(Lastname, 15, "Lastname", "Is too short")); 
			}
		}

		public string Firstname { get; private set; }
		public string Middlename { get; private set; }
		public string Lastname { get; private set; }

		public override string ToString() => Firstname + " " + Middlename + " " + Lastname;
	}
}