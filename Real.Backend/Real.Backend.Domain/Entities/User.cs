using FluentValidator.Validation;
using Real.Backend.Domain.ValueObjects;
using Real.Backend.Shared.Entities;
using Real.Backend.Shared.Enums;
using System;

namespace Real.Backend.Domain.Enities
{
	public class User : Entity
	{
		public User(Name name, Email email, Login login, EGender gender, string profileImage, DateTime birthday)
		{
			Name = name;
			Email = email;
			Login = login;
			Gender = gender;
			ProfileImage = profileImage;
			Birthday = birthday;

			CreatedOn = DateTime.Now;
			Active = true;

			AddNotifications(new ValidationContract()
				.IsNotNull(Gender, "Gender", "Gender can't be null")
				.IsNotNull(Birthday, "Birthday", "Birthday can't be null")
				.IsNotNullOrEmpty(ProfileImage, "ProfileImage", "Can't be null or empty"));

			AddNotifications(Name.Notifications);
			AddNotifications(Email.Notifications);
			AddNotifications(Login.Notifications);
		}

		public Name Name { get; private set; }
		public Login Login { get; private set; }
		public Email Email { get; private set; }
		public EGender Gender { get; private set; }
		public string ProfileImage { get; private set; }
		public DateTime Birthday { get; private set; }
		public DateTime CreatedOn { get; private set; }
		public bool Active { get; private set; }

		public bool Update(Name name)
		{
			if (name != null)
			{
				AddNotifications(name.Notifications);

				if (Valid)
					Name = name;
			}

			else
				AddNotification("Name", "Can't be null");

			return Valid;
		}

		public bool Update(Login login)
		{
			if (login != null)
			{
				AddNotifications(login.Notifications);

				if (Valid)
				{
					if (Login.Username != login.Username)
						Login.Update(login.Username, login.Password);

					else
						Login.Update(login.Password);
					
					AddNotifications(Login.Notifications);
				}
			}

			else
				AddNotification("Login", "Can't be null");

			return Valid;
		}

		public bool Update(Email email)
		{
			if (email != null)
			{
				AddNotifications(email.Notifications);

				if (Valid)
					Email = email;
			}

			else
				AddNotification("Email", "Can't be null");

			return Valid;
		}

		public void Update(EGender gender) => Gender = gender;

		public bool Update(string profileImage)
		{
			if (profileImage != null)
			{
				AddNotifications(new ValidationContract()
						.IsNotNullOrEmpty(ProfileImage, "ProfileImage", "Can't be null or empty"));

				if (Valid)
					ProfileImage = profileImage;
			}

			return Valid;
		}

		public bool Update(DateTime birthday)
		{
			if (birthday != null)
				Birthday = birthday;

			else
				AddNotification("Birthday", "Can't be null");

			return Valid;
		}

		public void Activate() => Active = true;
		public void DeActivate() => Active = false;
	}
}