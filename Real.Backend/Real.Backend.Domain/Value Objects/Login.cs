using FluentValidator;
using FluentValidator.Validation;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Real.Backend.Domain.ValueObjects
{
	public class Login : Notifiable
	{
		protected Login() { }

		public Login(string username, string password)
		{
			if (username == null)
				AddNotification("Username", "Is Null");

			if (password == null)
				AddNotification("password", "Is Null");

			if (Valid)
			{
				Username = username;
				Password = EncryptPassword(password);

				AddNotifications(new ValidationContract().Requires()
					.HasMinLen(Username, 3, "Username", "Is too short").HasMaxLen(Username, 20, "Username", "Is too long")
					.IsNotNullOrEmpty(Password, "Password", "Is invalid").HasMinLen(password, 8, "Password", "Is too short")); 
			}
		}

		public string Username { get; private set; }
		public string Password { get; private set; }

		private string EncryptPassword(string pass)
		{
			string result = null;

			if (!string.IsNullOrEmpty(pass))
			{
				string password = (pass += "|ED2BCA0C-7EF7-409E-ABE7-90BAC55F5DFE");

				MD5 md5 = MD5.Create();
				byte[] data = md5.ComputeHash(Encoding.Default.GetBytes(password));

				StringBuilder sbString = new StringBuilder();

				foreach (byte Byte in data)
					sbString.Append(Byte.ToString("x2"));

				result = sbString.ToString();
			}

			return result;
		}

		internal bool Update(string username, string password)
		{
			if(username == null)
				AddNotification("Username", "Is Null");

			if (password == null)
				AddNotification("password", "Is Null");

			if (Valid)
			{
				Username = username;

				AddNotifications(new ValidationContract().Requires()
					.HasMinLen(Username, 3, "Username", "Is too short").HasMaxLen(Username, 20, "Username", "Is too long")
					.AreEquals(Password, password, "Password", "Does not match"));
			}

			return Valid;
		}

		internal bool Update(string password)
		{
			if (password != null)
			{
				Password = EncryptPassword(password);

				AddNotifications(new ValidationContract().Requires().IsNotNullOrEmpty(Password, "Password", "Is invalid").HasMinLen(password, 8, "Password", "Is too short"));
			}

			else
				AddNotification("password", "Is Null");

			return Valid;
		}
	}
}