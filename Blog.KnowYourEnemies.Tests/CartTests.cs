using System;
using System.Collections.Generic;
using System.Linq;
using Blog.KnowYourEnemies.ProductStates;
using Xunit;

namespace Blog.KnowYourEnemies.Tests
{
    public class CartTests
    {
        
        private readonly Action stubSoldoutAction = () =>
        {
            var o = new object();
        };
        
        [Fact]
        public void GetAvailable_1AvailableProduct_ReturnsListLenght1()
        {
            //Arrange
            var listProduct = new List<Product>
            {
                new Product(1, new ActiveState(stubSoldoutAction)),
                new Product(2, new BannedState(stubSoldoutAction)),
                new Product(3, new SoldoutState(stubSoldoutAction)),
            };
            
            var sut = new Cart(listProduct);
            //Act
            var result= sut.GetAvailable();
            //Assert
            Assert.Equal(1, result.Products.Count());
        }

        
        [Fact]
        public void GetTotal_1AvailableProductPrice10_ReturnsPrice10()
        {
            //Arrange
            var listProduct = new List<Product>
            {
                new Product(1, new ActiveState(stubSoldoutAction), 10),
                new Product(2, new BannedState(stubSoldoutAction), new decimal(9.4)),
                new Product(3, new SoldoutState(stubSoldoutAction), new decimal(4.5)),
            };
            
            var sut = new Cart(listProduct);
            //Act
            var result= sut.GetTotal();
            //Assert
            Assert.Equal(10, result);
        }

    }
}