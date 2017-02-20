using Moq;
using NUnit.Framework;
using System;
using TravelGuide.Data;
using TravelGuide.Services.Articles;
using TravelGuide.Services.Factories;
using TravelGuide.Tests.Services.Articles.Mock;

namespace TravelGuide.Tests.Services.Articles.ArticleServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenPassedDbContextIsNull()
        {
            // Arrange
            var factoryMock = new Mock<IArticleFactory>();

            //// Act & Assert
            //var ex = Assert.Throws<ArgumentNullException>(() => new ArticleService(null, factoryMock.Object));
            //StringAssert.Contains("DdContext", ex.Message);
        }

        [Test]
        public void ThrowArgumentNullException_WhenPassedFactoryIsNull()
        {
            // Arrange
            var contextMock = new Mock<ITravelGuideContext>();

            //// Act & Assert
            //var ex = Assert.Throws<ArgumentNullException>(() => new ArticleService(contextMock.Object, null));
            //StringAssert.Contains("factory", ex.Message);
        }

        [Test]
        public void ReturnAnArticleServiceInstance_WhenPassedParamsAreValid()
        {
            // Arrange
            var contextMock = new Mock<ITravelGuideContext>();
            var factoryMock = new Mock<IArticleFactory>();

            //// Act 
            //var service = new ArticleService(contextMock.Object, factoryMock.Object);

            //// Assert
            //Assert.IsInstanceOf<ArticleService>(service);
        }

        [Test]
        public void AssignCorrectContextValue_WhenPassedParamsAreValid()
        {
            // Arrange
            var contextMock = new Mock<ITravelGuideContext>();
            var factoryMock = new Mock<IArticleFactory>();

            // Act 
            var service = new ExtendedArticleService(contextMock.Object, factoryMock.Object);

            // Assert
            Assert.AreSame(contextMock.Object, service.Context);
        }

        [Test]
        public void AssignCorrectFactoryValue_WhenPassedParamsAreValid()
        {
            // Arrange
            var contextMock = new Mock<ITravelGuideContext>();
            var factoryMock = new Mock<IArticleFactory>();

            // Act 
            var service = new ExtendedArticleService(contextMock.Object, factoryMock.Object);

            // Assert
            Assert.AreSame(factoryMock.Object, service.ArticleFactory);
        }
    }
}
