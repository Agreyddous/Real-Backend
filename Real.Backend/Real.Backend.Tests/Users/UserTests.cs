using Microsoft.VisualStudio.TestTools.UnitTesting;
using Real.Backend.Domain.Commands.Handlers.Users;
using Real.Backend.Domain.Commands.Input;
using Real.Backend.Domain.Enities;
using Real.Backend.Domain.ValueObjects;
using Real.Backend.Shared.Enums;
using Real.Backend.Tests.Repositories;
using System;

namespace Real.Backend.Tests.Users
{
	[TestClass]
	public class UserTests
	{
		private User testUser = new User(new Name("Fernando", "Gomes"), new Email("fernandovbmgomes@hotmail.com"), new Login("Nando", "PassPass"), EGender.Male, "Profil Pic Goes Here", DateTime.Now);

		#region Register

		[TestMethod]
		[TestCategory("User - Register")]
		public void CreateNewUser()
		{
			User user = new User(new Name("Fernando", "Gomes"), new Email("fernandovbmgomes@hotmail.com"), new Login("Nando", "senha123456789"), EGender.Male, "Imagem", DateTime.Now);
			Assert.IsTrue(user.Valid);
		}

		[TestMethod]
		[TestCategory("User - Register")]
		public void HandleNewUser()
		{
			RegisterUserCommand command = new RegisterUserCommand
			{
				Birthday = DateTime.Now,
				Email = "fernandovbmgomes@hotmail.com",
				Firstname = "Fernando",
				Gender = EGender.Male,
				Lastname = "Gomes",
				Middlename = "Velloso Borges de Mélo",
				Password = "PassPass",
				ProfileImage = "Some Pic Goes Here",
				Username = "Nando"
			};

			UserRepository repository = new UserRepository();

			RegisterUserCommandHandler handler = new RegisterUserCommandHandler(repository);

			handler.Handle(command);

			Assert.IsNotNull(repository.TestUser);
			Assert.IsTrue(handler.Valid);
		}

		[TestMethod]
		[TestCategory("User - Register")]
		public void HandleNewUserNullCommand()
		{
			RegisterUserCommand command = null;

			UserRepository repository = new UserRepository();

			RegisterUserCommandHandler handler = new RegisterUserCommandHandler(repository);

			handler.Handle(command);

			Assert.IsNull(repository.TestUser);
			Assert.IsTrue(handler.Invalid);
		}

		[TestMethod]
		[TestCategory("User - Register")]
		public void HandleNewUserNoPassword()
		{
			RegisterUserCommand command = new RegisterUserCommand
			{
				Birthday = DateTime.Now,
				Email = "fernandovbmgomes@hotmail.com",
				Firstname = "Fernando",
				Gender = EGender.Male,
				Lastname = "Gomes",
				Middlename = "Velloso Borges de Mélo",
				Password = null,
				ProfileImage = "Some Pic Goes Here",
				Username = "Nando"
			};

			UserRepository repository = new UserRepository();

			RegisterUserCommandHandler handler = new RegisterUserCommandHandler(repository);

			handler.Handle(command);

			Assert.IsNull(repository.TestUser);
			Assert.IsTrue(handler.Invalid);
		}

		[TestMethod]
		[TestCategory("User - Register")]
		public void HandleNewUserNoLogin()
		{
			RegisterUserCommand command = new RegisterUserCommand
			{
				Birthday = DateTime.Now,
				Email = "fernandovbmgomes@hotmail.com",
				Firstname = "Fernando",
				Gender = EGender.Male,
				Lastname = "Gomes",
				Middlename = "Velloso Borges de Mélo",
				Password = "PassPass",
				ProfileImage = "Some Pic Goes Here",
				Username = null
			};

			UserRepository repository = new UserRepository();

			RegisterUserCommandHandler handler = new RegisterUserCommandHandler(repository);

			handler.Handle(command);

			Assert.IsNull(repository.TestUser);
			Assert.IsTrue(handler.Invalid);
		}

		[TestMethod]
		[TestCategory("User - Register")]
		public void HandleNewUserNoEmail()
		{
			RegisterUserCommand command = new RegisterUserCommand
			{
				Birthday = DateTime.Now,
				Email = null,
				Firstname = "Fernando",
				Gender = EGender.Male,
				Lastname = "Gomes",
				Middlename = "Velloso Borges de Mélo",
				Password = "PassPass",
				ProfileImage = "Some Pic Goes Here",
				Username = "Nando"
			};

			UserRepository repository = new UserRepository();

			RegisterUserCommandHandler handler = new RegisterUserCommandHandler(repository);

			handler.Handle(command);

			Assert.IsNull(repository.TestUser);
			Assert.IsTrue(handler.Invalid);
		}

		[TestMethod]
		[TestCategory("User - Register")]
		public void HandleNewUserNoProfileImage()
		{
			RegisterUserCommand command = new RegisterUserCommand
			{
				Birthday = DateTime.Now,
				Email = "fernandovbmgomes@hotmail.com",
				Firstname = "Fernando",
				Gender = EGender.Male,
				Lastname = "Gomes",
				Middlename = "Velloso Borges de Mélo",
				Password = "PassPass",
				ProfileImage = null,
				Username = "Nando"
			};

			UserRepository repository = new UserRepository();

			RegisterUserCommandHandler handler = new RegisterUserCommandHandler(repository);

			handler.Handle(command);

			Assert.IsNull(repository.TestUser);
			Assert.IsTrue(handler.Invalid);
		}

		[TestMethod]
		[TestCategory("User - Register")]
		public void HandleNewUserNoFirstname()
		{
			RegisterUserCommand command = new RegisterUserCommand
			{
				Birthday = DateTime.Now,
				Email = "fernandovbmgomes@hotmail.com",
				Firstname = null,
				Gender = EGender.Male,
				Lastname = "Gomes",
				Middlename = "Velloso Borges de Mélo",
				Password = "PassPass",
				ProfileImage = "Some Pic Goes Here",
				Username = "Nando"
			};

			UserRepository repository = new UserRepository();

			RegisterUserCommandHandler handler = new RegisterUserCommandHandler(repository);

			handler.Handle(command);

			Assert.IsNull(repository.TestUser);
			Assert.IsTrue(handler.Invalid);
		}

		[TestMethod]
		[TestCategory("User - Register")]
		public void HandleNewUserNoLastname()
		{
			RegisterUserCommand command = new RegisterUserCommand
			{
				Birthday = DateTime.Now,
				Email = "fernandovbmgomes@hotmail.com",
				Firstname = "Fernando",
				Gender = EGender.Male,
				Lastname = null,
				Middlename = "Velloso Borges de Mélo",
				Password = "PassPass",
				ProfileImage = "Some Pic Goes Here",
				Username = "Nando"
			};

			UserRepository repository = new UserRepository();

			RegisterUserCommandHandler handler = new RegisterUserCommandHandler(repository);

			handler.Handle(command);

			Assert.IsNull(repository.TestUser);
			Assert.IsTrue(handler.Invalid);
		}

		[TestMethod]
		[TestCategory("User - Register")]
		public void HandleNewUserNoMiddlename()
		{
			RegisterUserCommand command = new RegisterUserCommand
			{
				Birthday = DateTime.Now,
				Email = "fernandovbmgomes@hotmail.com",
				Firstname = "Fernando",
				Gender = EGender.Male,
				Lastname = "Gomes",
				Middlename = null,
				Password = "PassPass",
				ProfileImage = "Some Pic Goes Here",
				Username = "Nando"
			};

			UserRepository repository = new UserRepository();

			RegisterUserCommandHandler handler = new RegisterUserCommandHandler(repository);

			handler.Handle(command);

			Assert.IsNotNull(repository.TestUser);
			Assert.IsTrue(handler.Valid);
		}

		#endregion

		#region Update

		[TestMethod]
		[TestCategory("User - Update")]
		public void HandleUpdateUser()
		{
			UpdateUserCommand command = new UpdateUserCommand
			{
				Firstname = "Gabriela",
				Middlename = "Borges da",
				Lastname = "Silva",
				Address = "gabriela.borges-silva@hotmail.com",
				ProfileImage = "Another Pic Goes Here"
			};

			UpdateUserCommandHandler handler = new UpdateUserCommandHandler(new UserRepository());

			handler.Handle(command);

			Assert.IsTrue(handler.Valid);
		}

		[TestMethod]
		[TestCategory("User - Update")]
		public void UpdateUserUsername()
		{
			testUser.Update(new Login("Fernando", "PassPass"));

			Assert.IsTrue(testUser.Valid);
		}

		[TestMethod]
		[TestCategory("User - Update")]
		public void UpdateUserPassword()
		{
			testUser.Update(new Login(testUser.Login.Username, "WordWord"));

			Assert.IsTrue(testUser.Valid);
		}

		[TestMethod]
		[TestCategory("User - Update")]
		public void UpdateUserNullUsername()
		{
			testUser.Update(new Login(null, "PassPass"));

			Assert.IsTrue(testUser.Invalid);
		}

		[TestMethod]
		[TestCategory("User - Update")]
		public void UpdateUserNullPassword()
		{
			testUser.Update(new Login(testUser.Login.Username, null));

			Assert.IsTrue(testUser.Invalid);
		}

		[TestMethod]
		[TestCategory("User - Update")]
		public void UpdateUserInvalidUsername()
		{
			testUser.Update(new Login("", "PassPass"));

			Assert.IsTrue(testUser.Invalid);
		}

		[TestMethod]
		[TestCategory("User - Update")]
		public void UpdateUserInvalidPassword()
		{
			testUser.Update(new Login(testUser.Login.Username, ""));

			Assert.IsTrue(testUser.Invalid);
		}

		[TestMethod]
		[TestCategory("User - Update")]
		public void HandleUpdateUserNullCommand()
		{
			UpdateUserCommand command = null;

			UpdateUserCommandHandler handler = new UpdateUserCommandHandler(new UserRepository());

			handler.Handle(command);

			Assert.IsTrue(handler.Invalid);
		}

		[TestMethod]
		[TestCategory("User - Update")]
		public void HandleUpdateUserNoFirstname()
		{
			UpdateUserCommand command = new UpdateUserCommand
			{
				Firstname = null,
				Middlename = "Borges da",
				Lastname = "Silva",
				Address = "gabriela.borges-silva@hotmail.com",
				ProfileImage = "Another Pic Goes Here"
			};

			UpdateUserCommandHandler handler = new UpdateUserCommandHandler(new UserRepository());

			handler.Handle(command);

			Assert.IsTrue(handler.Valid);
		}

		[TestMethod]
		[TestCategory("User - Update")]
		public void HandleUpdateUserNoLastname()
		{
			UpdateUserCommand command = new UpdateUserCommand
			{
				Firstname = "Gabriela",
				Middlename = "Borges da",
				Lastname = null,
				Address = "gabriela.borges-silva@hotmail.com",
				ProfileImage = "Another Pic Goes Here"
			};

			UpdateUserCommandHandler handler = new UpdateUserCommandHandler(new UserRepository());

			handler.Handle(command);

			Assert.IsTrue(handler.Valid);
		}

		[TestMethod]
		[TestCategory("User - Update")]
		public void HandleUpdateUserNoMiddlename()
		{
			UpdateUserCommand command = new UpdateUserCommand
			{
				Firstname = "Gabriela",
				Middlename = null,
				Lastname = "Silva",
				Address = "gabriela.borges-silva@hotmail.com",
				ProfileImage = "Another Pic Goes Here"
			};

			UpdateUserCommandHandler handler = new UpdateUserCommandHandler(new UserRepository());

			handler.Handle(command);

			Assert.IsTrue(handler.Valid);
		}

		[TestMethod]
		[TestCategory("User - Update")]
		public void HandleUpdateUserNoAddress()
		{
			UpdateUserCommand command = new UpdateUserCommand
			{
				Firstname = "Gabriela",
				Middlename = "Borges da",
				Lastname = "Silva",
				Address = null,
				ProfileImage = "Another Pic Goes Here"
			};

			UpdateUserCommandHandler handler = new UpdateUserCommandHandler(new UserRepository());

			handler.Handle(command);

			Assert.IsTrue(handler.Valid);
		}

		[TestMethod]
		[TestCategory("User - Update")]
		public void HandleUpdateUserEmptyFirstname()
		{
			UpdateUserCommand command = new UpdateUserCommand
			{
				Firstname = "",
				Middlename = "Borges da",
				Lastname = "Silva",
				Address = "gabriela.borges-silva@hotmail.com",
				ProfileImage = "Another Pic Goes Here"
			};

			UpdateUserCommandHandler handler = new UpdateUserCommandHandler(new UserRepository());

			handler.Handle(command);

			Assert.IsTrue(handler.Invalid);
		}

		[TestMethod]
		[TestCategory("User - Update")]
		public void HandleUpdateUserEmptyMiddleName()
		{
			UpdateUserCommand command = new UpdateUserCommand
			{
				Firstname = "Gabriela",
				Middlename = "",
				Lastname = "Silva",
				Address = "gabriela.borges-silva@hotmail.com",
				ProfileImage = "Another Pic Goes Here"
			};

			UpdateUserCommandHandler handler = new UpdateUserCommandHandler(new UserRepository());

			handler.Handle(command);

			Assert.IsTrue(handler.Valid);
		}

		[TestMethod]
		[TestCategory("User - Update")]
		public void HandleUpdateUserEmptyLastname()
		{
			UpdateUserCommand command = new UpdateUserCommand
			{
				Firstname = "Gabriela",
				Middlename = "Borges da",
				Lastname = "",
				Address = "gabriela.borges-silva@hotmail.com",
				ProfileImage = "Another Pic Goes Here"
			};

			UpdateUserCommandHandler handler = new UpdateUserCommandHandler(new UserRepository());

			handler.Handle(command);

			Assert.IsTrue(handler.Invalid);
		}

		[TestMethod]
		[TestCategory("User - Update")]
		public void HandleUpdateUserEmptyAddress()
		{
			UpdateUserCommand command = new UpdateUserCommand
			{
				Firstname = "Gabriela",
				Middlename = "Borges da",
				Lastname = "Silva",
				Address = "",
				ProfileImage = "Another Pic Goes Here"
			};

			UpdateUserCommandHandler handler = new UpdateUserCommandHandler(new UserRepository());

			handler.Handle(command);

			Assert.IsTrue(handler.Invalid);
		}

		[TestMethod]
		[TestCategory("User - Update")]
		public void HandleUpdateUserEmptyProfileImage()
		{
			UpdateUserCommand command = new UpdateUserCommand
			{
				Firstname = "",
				Middlename = "Borges da",
				Lastname = "Silva",
				Address = "gabriela.borges-silva@hotmail.com",
				ProfileImage = ""
			};

			UpdateUserCommandHandler handler = new UpdateUserCommandHandler(new UserRepository());

			handler.Handle(command);

			Assert.IsTrue(handler.Invalid);
		}

		#endregion
	}
}