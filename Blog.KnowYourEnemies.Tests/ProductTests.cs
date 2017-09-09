using System;
using System.Transactions;
using Blog.KnowYourEnemies.ProductStates;
using Xunit;

namespace Blog.KnowYourEnemies.Tests
{
    public class ProductTests
    {
        private readonly Action stubSoldoutAction = () =>
        {
            var o = new object();
        };

        [Fact]
        public void Deposit_Quantity0Amount1_ReturnsQuantity1()
        {
            //Arrange
            var sut = new Product(0, new ProductState(stubSoldoutAction));
            //Act
            sut.Deposit(1);
            //Assert
            Assert.Equal(1, sut.Quantity);
        }

        [Fact]
        public void Deposit_Quantity1BannedAmount1_ReturnsQuantity0()
        {
            //Arrange
            var sut = new Product(1, new BannedState(stubSoldoutAction));
            //Act
            sut.Withdraw(1);
            //Assert
            Assert.Equal(1, sut.Quantity);
        }

      

        [Fact]
        public void Withdraw_Quantity0Amount1_ReturnsQuantity0()
        {
            //Arrange
            var sut = new Product(0, new ProductState(stubSoldoutAction));
            //Act
            sut.Withdraw(1);
            //Assert
            Assert.Equal(0, sut.Quantity);
        }

        [Fact]
        public void Withdraw_Quantity1Amount1_ReturnsQuantity0()
        {
            //Arrange
            var sut = new Product(1, new ProductState(stubSoldoutAction));
            //Act
            sut.Withdraw(1);
            //Assert
            Assert.Equal(0, sut.Quantity);
        }

        [Fact]
        public void Withdraw_Quantity1BannedAmount1_ReturnsQuantity1()
        {
            //Arrange
            var sut = new Product(1, new BannedState(stubSoldoutAction));
            //Act
            sut.Withdraw(1);
            //Assert
            Assert.Equal(1, sut.Quantity);
        }

        [Fact]
        public void Withdraw_Quantity1Amount2_ReturnsQuantity1()
        {
            //Arrange
            var sut = new Product(1, new ProductState(stubSoldoutAction));
            //Act
            sut.Withdraw(2);
            //Assert
            Assert.Equal(1, sut.Quantity);
        }

        [Fact]
        public void Withdraw_Quantity1Amount1_ReturnsIsSoldOut()
        {
            //Arrange
            var sut = new Product(1,new ProductState(stubSoldoutAction));
            //Act
            sut.Withdraw(1);
            //Assert
            Assert.IsType<SoldoutState>(sut.State); 
        }
    }
}

//using System;
//using System.Reflection.Metadata.Ecma335;
//using Xunit;
//
//namespace Blog.KnowYourEnemies.Tests
//{
//    public class ProductTests
//    {
//        private readonly Action stubSoldoutAction = () =>
//        {
//            var o = new object();
//        };
//
//        [Fact]
//        public void Deposit_Quantity0Amount1_ReturnsQuantity1()
//        {
//            //Arrange
//            var sut = new Product(0, stubSoldoutAction);
//            //Act
//            sut.Deposit(1);
//            //Assert
//            Assert.Equal(1, sut.Quantity);
//        }
//
//        [Fact]
//        public void Deposit_Quantity1BannedAmount1_ReturnsQuantity0()
//        {
//            //Arrange
//            var sut = new Product(1, stubSoldoutAction, true);
//            //Act
//            sut.Withdraw(1);
//            //Assert
//            Assert.Equal(1, sut.Quantity);
//        }
//
//        [Fact]
//        public void Deposit_Quantity1Amount1_IsNotSoldout()
//        {
//            //Arrange
//            var sut = new Product(1, stubSoldoutAction, true);
//            //Act
//            sut.Withdraw(1);
//            //Assert
//            Assert.True(sut.IsSoldout);
//        }
//
//        [Fact]
//        public void Withdraw_Quantity0Amount1_ReturnsQuantity0()
//        {
//            //Arrange
//            var sut = new Product(0, stubSoldoutAction);
//            //Act
//            sut.Withdraw(1);
//            //Assert
//            Assert.Equal(0, sut.Quantity);
//        }
//
//        [Fact]
//        public void Withdraw_Quantity1Amount1_ReturnsQuantity0()
//        {
//            //Arrange
//            var sut = new Product(1, stubSoldoutAction);
//            //Act
//            sut.Withdraw(1);
//            //Assert
//            Assert.Equal(0, sut.Quantity);
//        }
//
//        [Fact]
//        public void Withdraw_Quantity1BannedAmount1_ReturnsQuantity1()
//        {
//            //Arrange
//            var sut = new Product(1, stubSoldoutAction, true);
//            //Act
//            sut.Withdraw(1);
//            //Assert
//            Assert.Equal(1, sut.Quantity);
//        }
//
//        [Fact]
//        public void Withdraw_Quantity1Amount2_ReturnsQuantity1()
//        {
//            //Arrange
//            var sut = new Product(1, stubSoldoutAction);
//            //Act
//            sut.Withdraw(2);
//            //Assert
//            Assert.Equal(1, sut.Quantity);
//        }
//
//        [Fact]
//        public void Withdraw_Quantity1Amount1_ReturnsIsSoldOut()
//        {
//            //Arrange
//            var sut = new Product(1, stubSoldoutAction, false, false);
//            //Act
//            sut.Withdraw(1);
//            //Assert
//            Assert.True(sut.IsSoldout);
//        }
//    }
//}