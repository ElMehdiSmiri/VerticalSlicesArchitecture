using App.Domain.Entities;

namespace App.Test.Domain
{
    public class CountryTest
    {
        [Fact]
        public void Country_Constructor_Success()
        {
            // Arrange
            string name = "USA";
            string language = "English";
            int population = 328200000;

            // Act
            var country = new Country(name, language, population);

            // Assert
            Assert.NotNull(country);
            Assert.Equal(name, country.Name);
            Assert.Equal(language, country.Language);
            Assert.Equal(population, country.Population);
        }

        [Fact]
        public void Country_Constructor_Throws_ArgumentNullException()
        {
            // Arrange, Act, Assert
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            Assert.Throws<ArgumentNullException>(() => new Country(null, "English", 1000000));
            Assert.Throws<ArgumentNullException>(() => new Country("USA", null, 1000000));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
        }


        [Fact]
        public void Country_Constructor_Throws_ArgumentException()
        {
            // Arrange, Act, Assert
            Assert.Throws<ArgumentException>(() => new Country("", "English", 1000000));
            Assert.Throws<ArgumentException>(() => new Country("USA", "", 1000000));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Country("USA", "English", -1000000));
        }

        [Fact]
        public void Country_Update()
        {
            // Arrange
            var country = new Country("USA", "English", 1000000);

            // Act
            country.Update("Canada", "French", 500000);

            // Assert
            Assert.Equal("Canada", country.Name);
            Assert.Equal("French", country.Language);
            Assert.Equal(500000, country.Population);
        }

        [Fact]
        public void Country_AddCity_Throws_ArgumentException()
        {
            // Arrange
            var country = new Country("USA", "English", 1000000);
            var city = new City("New York", 3000000, country);

            country.AddCity(city);

            // Act and Assert
            Assert.Throws<ArgumentException>(() => country.AddCity(city));
        }
    }
}
