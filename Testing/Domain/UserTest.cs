using System;
using Xunit;
using Domain.events;
using Domain.Model.Transaction;
using Domain.Model;
using System.Security.Cryptography.X509Certificates;
using Domain.Factories;

namespace Testing.Domain
{
    public class UserTest
    {
        [Fact]
        public void CreateUser_Should_CreateUserWithGivenValues()
        {
            // Arrange
            UserFactory userFactory = new UserFactory();

            string name = "indio";
            string email = "indio@gmail.com";
            string password = "12345678";

            // Act
            var user = userFactory.CreateUser(name, email , password);

            // Assert
            Xunit.Assert.NotNull(user);  // Verifica que la instancia de usuario no sea nula
            
        }

    }
}