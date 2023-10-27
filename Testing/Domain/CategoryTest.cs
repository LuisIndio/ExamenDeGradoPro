using Domain.Factories;
using Domain.Factories.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Testing.Domain
{
    public class CategoryTest
    {
        [Fact]
        public void CreateCategory_Should_CreateUserWithGivenValues()
        {
            // Arrange
            CategoryFactory categoryFactory = new CategoryFactory();

            Guid id = Guid.NewGuid();
            string name = "viajes";
            string description = "esta categoria es para cuando se haga un ingreso o egreso de los viajes";

            // Act
            var category = categoryFactory.CreateCategory(id, name, description);

            // Assert
            Xunit.Assert.NotNull(category);  // Verifica que la instancia de usuario no sea nula
            Xunit.Assert.Equal(name, category.Name);

        }
    }
}
