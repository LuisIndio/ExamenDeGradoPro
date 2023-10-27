using Domain.Factories;
using Domain.Factories.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Testing.Domain
{
    public class AccountTest
    {
        [Fact]
        public void CreateAccount_Should_CreateUserWithGivenValues()
        {
            // Arrange
            AccountFactory accountFactory = new AccountFactory();

            Guid id = Guid.NewGuid();
            string name = "Cuenta Principal";
            decimal balance = 0;

            // Act
            var account = accountFactory.CreateAccount(id,name,balance);

            // Assert
            Xunit.Assert.NotNull(account);  // Verifica que la instancia de usuario no sea nula
        }
    }
}
