using Xunit;

namespace Blog.KnowYourEnemies.Tests
{
    public class ProductTests
    {
        [Fact]
        public void Deposit_Quantity0Amount1_ReturnsQuantity1()
        {
            //Arrange
            var sut = new Product(0);
            //Act
            sut.Deposit(1);
            //Assert
            Assert.Equal(1, sut.Quantity);
        }
        
        [Fact]
        public void Deposit_Quantity1BannedAmount1_ReturnsQuantity0()
        {
            //Arrange
            var sut = new Product(1, true);
            //Act
            sut.Withdraw(1);
            //Assert
            Assert.Equal(1, sut.Quantity);
        }
        [Fact]
        public void Withdraw_Quantity0Amount1_ReturnsQuantity0()
        {
            //Arrange
            var sut = new Product(0);
            //Act
            sut.Withdraw(1);
            //Assert
            Assert.Equal(0, sut.Quantity);
        }
        
        [Fact]
        public void Withdraw_Quantity1Amount1_ReturnsQuantity0()
        {
            //Arrange
            var sut = new Product(1);
            //Act
            sut.Withdraw(1);
            //Assert
            Assert.Equal(0, sut.Quantity);
        }
        [Fact]
        public void Withdraw_Quantity1BannedAmount1_ReturnsQuantity1()
        {
            //Arrange
            var sut = new Product(1, true);
            //Act
            sut.Withdraw(1);
            //Assert
            Assert.Equal(1, sut.Quantity);
        }
        
        [Fact]
        public void Withdraw_Quantity1Amount2_ReturnsQuantity1()
        {
            //Arrange
            var sut = new Product(1);
            //Act
            sut.Withdraw(2);
            //Assert
            Assert.Equal(1, sut.Quantity);
        }
        
    }
}