using Moq;
using NUnit.Framework;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using TravelGuide.Data;
using TravelGuide.Models;
using TravelGuide.Services.Articles;
using TravelGuide.Services.Factories;

namespace TravelGuide.Tests.Services.Articles.ArticleServiceTests
{
    [TestFixture]
    public class CreateArticle_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenPassedUsernameIsNull()
        {
            // Arrange
            var contextMock = new Mock<ITravelGuideContext>();
            var factoryMock = new Mock<IArticleFactory>();
            string username = null;
            var title = "some name";
            var city = "some name";
            var country = "some name";
            var content = "50 symbols content... tooooooooooooooooo looooooooooooooooooong";
            var imageUrl = "some name";

            //// Act
            //var service = new ArticleService(contextMock.Object, factoryMock.Object);

            //// Assert
            //var ex = Assert.Throws<ArgumentNullException>(() => service.CreateArticle(username, title, city, country, content, imageUrl));
            //StringAssert.Contains("Username", ex.Message);
        }

        [Test]
        public void ThrowArgumentException_WhenPassedTitleIsNull()
        {
            // Arrange
            var contextMock = new Mock<ITravelGuideContext>();
            var factoryMock = new Mock<IArticleFactory>();
            var username = "some name";
            string title = null;
            var city = "some name";
            var country = "some name";
            var content = "50 symbols content... tooooooooooooooooo looooooooooooooooooong";
            var imageUrl = "some name";

            //// Act
            //var service = new ArticleService(contextMock.Object, factoryMock.Object);

            //// Assert
            //var ex = Assert.Throws<ArgumentException>(() => service.CreateArticle(username, title, city, country, content, imageUrl));
            //StringAssert.Contains("Title", ex.Message);
        }

        [Test]
        [TestCase("a")]
        [TestCase("0123456789012345678901234567891")]
        public void ThrowArgumentException_WhenPassedTitleLengthIsNotInPermittedRange(string title)
        {
            // Arrange
            var contextMock = new Mock<ITravelGuideContext>();
            var factoryMock = new Mock<IArticleFactory>();
            var username = "some name";
            var city = "some name";
            var country = "some name";
            var content = "50 symbols content... tooooooooooooooooo looooooooooooooooooong";
            var imageUrl = "some name";

            //// Act
            //var service = new ArticleService(contextMock.Object, factoryMock.Object);

            //// Assert
            //var ex = Assert.Throws<ArgumentException>(() => service.CreateArticle(username, title, city, country, content, imageUrl));
            //StringAssert.Contains("Title", ex.Message);
        }

        [Test]
        public void ThrowArgumentException_WhenPassedCityIsNull()
        {
            // Arrange
            var contextMock = new Mock<ITravelGuideContext>();
            var factoryMock = new Mock<IArticleFactory>();
            var username = "some name";
            var title = "some name";
            string city = null;
            var country = "some name";
            var content = "50 symbols content... tooooooooooooooooo looooooooooooooooooong";
            var imageUrl = "some name";

            //// Act
            //var service = new ArticleService(contextMock.Object, factoryMock.Object);

            //// Assert
            //var ex = Assert.Throws<ArgumentException>(() => service.CreateArticle(username, title, city, country, content, imageUrl));
            //StringAssert.Contains("City", ex.Message);
        }

        [Test]
        [TestCase("a")]
        [TestCase("0123456789012345678901234567891")]
        public void ThrowArgumentException_WhenPassedCityLengthIsNotInPermittedRange(string city)
        {
            // Arrange
            var contextMock = new Mock<ITravelGuideContext>();
            var factoryMock = new Mock<IArticleFactory>();
            var username = "some name";
            var title = "some name";
            var country = "some name";
            var content = "50 symbols content... tooooooooooooooooo looooooooooooooooooong";
            var imageUrl = "some name";

            //// Act
            //var service = new ArticleService(contextMock.Object, factoryMock.Object);

            //// Assert
            //var ex = Assert.Throws<ArgumentException>(() => service.CreateArticle(username, title, city, country, content, imageUrl));
            //StringAssert.Contains("City", ex.Message);
        }

        [Test]
        public void ThrowArgumentException_WhenPassedCountryIsNull()
        {
            // Arrange
            var contextMock = new Mock<ITravelGuideContext>();
            var factoryMock = new Mock<IArticleFactory>();
            var username = "some name";
            var title = "some name";
            var city = "some name";
            string country = null;
            var content = "50 symbols content... tooooooooooooooooo looooooooooooooooooong";
            var imageUrl = "some name";

            //// Act
            //var service = new ArticleService(contextMock.Object, factoryMock.Object);

            //// Assert
            //var ex = Assert.Throws<ArgumentException>(() => service.CreateArticle(username, title, city, country, content, imageUrl));
            //StringAssert.Contains("Country", ex.Message);
        }

        [Test]
        [TestCase("a")]
        [TestCase("0123456789012345678901234567891")]
        public void ThrowArgumentException_WhenPassedCountryLengthIsNotInPermittedRange(string country)
        {
            // Arrange
            var contextMock = new Mock<ITravelGuideContext>();
            var factoryMock = new Mock<IArticleFactory>();
            var username = "some name";
            var title = "some name";
            var city = "some name";
            var content = "50 symbols content... tooooooooooooooooo looooooooooooooooooong";
            var imageUrl = "some name";

            //// Act
            //var service = new ArticleService(contextMock.Object, factoryMock.Object);

            //// Assert
            //var ex = Assert.Throws<ArgumentException>(() => service.CreateArticle(username, title, city, country, content, imageUrl));
            //StringAssert.Contains("Country", ex.Message);
        }

        [Test]
        public void ThrowArgumentException_WhenPassedContentIsNull()
        {
            // Arrange
            var contextMock = new Mock<ITravelGuideContext>();
            var factoryMock = new Mock<IArticleFactory>();
            string username = "some name";
            var title = "some name";
            var city = "some name";
            var country = "some name";
            string content = null;
            var imageUrl = "some name";

            //// Act
            //var service = new ArticleService(contextMock.Object, factoryMock.Object);

            //// Assert
            //var ex = Assert.Throws<ArgumentException>(() => service.CreateArticle(username, title, city, country, content, imageUrl));
            //StringAssert.Contains("Content", ex.Message);
        }

        [Test]
        [TestCase("0123456789012345678901234567890123456789012345678")]
        [TestCase("012345678901234567890123456789123012345678901234567890123456789123012345678901234567890123456789123101234567890123456789012345678912301234567890123456789012345678912301234567890123456789012345678912310123456789012345678901234567891230123456789012345678901234567891230123456789012345678901234567891231012345678901234567890123456789123012345678901234567890123456789123012345678901234567890123456789123101234567890123456789012345678912301234567890123456789012345678912301234567890123456789012345678912310123456789012345678901234567891230123456789012345678901234567891230123456789012345678901234567891231012345678901234567890123456789123012345678901234567890123456789123012345678901234567890123456789123101234567890123456789012345678912301234567890123456789012345678912301234567890123456789012345678912310123456789012345678901234567891230123456789012345678901234567891230123456789012345678901234567891231012345678901234567890123456789123012345678901234567890123456789123012345678901234567890123456789123101234567890123456789012345678912301234567890123456789012345678912301234567890123456789012345678912310123456789012345678901234567891230123456789012345678901234567891230123456789012345678901234567891231012345678901234567890123456789123012345678901234567890123456789123012345678901234567890123456789123101234567890123456789012345678912301234567890123456789012345678912301234567890123456789012345678912310123456789012345678901234567891230123456789012345678901234567891230123456789012345678901234567891231012345678901234567890123456789123012345678901234567890123456789123012345678901234567890123456789123101234567890123456789012345678912301234567890123456789012345678912301234567890123456789012345678912310123456789012345678901234567891230123456789012345678901234567891230123456789012345678901234567891231012345678901234567890123456789123012345678901234567890123456789123012345678901234567890123456789123101234567890123456789012345678912301234567890123456789012345678912301234567890123456789012345678912310123456789012345678901234567891230123456789012345678901234567891230123456789012345678901234567891231012345678901234567890123456789123012345678901234567890123456789123012345678901234567890123456789123101234567890123456789012345678912301234567890123456789012345678912301234567890123456789012345678912310123456789012345678901234567891230123456789012345678901234567891230123456789012345678901234567891231012345678901234567890123456789123012345678901234567890123456789123012345678901234567890123456789123101234567890123456789012345678912301234567890123456789012345678912301234567890123456789012345678912310123456789012345678901234567891230123456789012345678901234567891230123456789012345678901234567891231012345678901234567890123456789123012345678901234567890123456789123012345678901234567890123456789123101234567890123456789012345678912301234567890123456789012345678912301234567890123456789012345678912310123456789012345678901234567891230123456789012345678901234567891230123456789012345678901234567891231012345678901234567890123456789123012345678901234567890123456789123012345678901234567890123456789123101234567890123456789012345678912301234567890123456789012345678912301234567890123456789012345678912310123456789012345678901234567891230123456789012345678901234567891230123456789012345678901234567891231012345678901234567890123456789123012345678901234567890123456789123012345678901234567890123456789123101234567890123456789012345678912301234567890123456789012345678912301234567890123456789012345678912310123456789012345678901234567891230123456789012345678901234567891230123456789012345678901234567891231012345678901234567890123456789123012345678901234567890123456789123012345678901234567890123456789123101234567890123456789012345678912301234567890123456789012345678912301234567890123456789012345678912310123456789012345678901234567891230123456789012345678901234567891230123456789012345678901234567891231012345678901234567890123456789123012345678901234567890123456789123012345678901234567890123456789123101234567890123456789012345678912301234567890123456789012345678912301234567890123456789012345678912310123456789012345678901234567891230123456789012345678901234567891230123456789012345678901234567891231012345678901234567890123456789123012345678901234567890123456789123012345678901234567890123456789123101234567890123456789012345678912301234567890123456789012345678912301234567890123456789012345678912310123456789012345678901234567891230123456789012345678901234567891230123456789012345678901234567891231012345678901234567890123456789123012345678901234567890123456789123012345678901234567890123456789123101234567890123456789012345678912301234567890123456789012345678912301234567890123456789012345678912310123456789012345678901234567891230123456789012345678901234567891230123456789012345678901234567891231012345678901234567890123456789123012345678901234567890123456789123012345678901234567890123456789123118901234567891230123456789012345678901234567891231189012345678912301234567890123456789012345678912311890123456789123012345678901234567890123456789123118901234567891230123456789012345678901234567891231189012345678912301234567890123456789012345678912311890123456789123012345678901234567890123456789123118901234567891230123456789012345678901234567891231189012345678912301234567890123456789012345678912311890123456789123012345678901234567890123456789123118901234567891230123456789012345678901234567891231189012345678912301234567890123456789012345678912311890123456789123012345678901234567890123456789123118901234567891230123456789012345678901234567891231189012345678912301234567890123456789012345678912311890123456789123012345678901234567890123456789123118901234567891230123456789012345678901234567891231189012345678912301234567890123456789012345678912311")]
        public void ThrowArgumentException_WhenPassedContentLengthIsNotInPermittedRange(string content)
        {
            // Arrange
            var contextMock = new Mock<ITravelGuideContext>();
            var factoryMock = new Mock<IArticleFactory>();
            var username = "some name";
            var title = "some name";
            var city = "some name";
            var country = "some name";
            var imageUrl = "some name";

            //// Act
            //var service = new ArticleService(contextMock.Object, factoryMock.Object);

            //// Assert
            //var ex = Assert.Throws<ArgumentException>(() => service.CreateArticle(username, title, city, country, content, imageUrl));
            //StringAssert.Contains("Content", ex.Message);
        }

        [Test]
        public void ThrowArgumentNullException_WhenPassedImageUrlIsNull()
        {
            // Arrange
            var contextMock = new Mock<ITravelGuideContext>();
            var factoryMock = new Mock<IArticleFactory>();
            var username = "some name";
            var title = "some name";
            var city = "some name";
            var country = "some name";
            var content = "50 symbols content... tooooooooooooooooo looooooooooooooooooong";
            string imageUrl = null;

            //// Act
            //var service = new ArticleService(contextMock.Object, factoryMock.Object);

            //// Assert
            //var ex = Assert.Throws<ArgumentNullException>(() => service.CreateArticle(username, title, city, country, content, imageUrl));
            //StringAssert.Contains("ImageUrl", ex.Message);
        }

        [Test]
        public void ThrowInvalidOperationException_WhenPassedUserCannotBeFound()
        {
            // Arrange
            var contextMock = new Mock<ITravelGuideContext>();
            var factoryMock = new Mock<IArticleFactory>();
            var dbSetMock = new Mock<IDbSet<User>>();
            var username = "some name";
            var title = "some name";
            var city = "some name";
            var country = "some name";
            var content = "50 symbols content... tooooooooooooooooo looooooooooooooooooong";
            string imageUrl = "some url";
            
            contextMock.Setup(x => x.Users).Returns(dbSetMock.Object);

            //// Act
            //var service = new ArticleService(contextMock.Object, factoryMock.Object);

            //// Assert
            //var ex = Assert.Throws<InvalidOperationException>(() => service.CreateArticle(username, title, city, country, content, imageUrl));
            //StringAssert.Contains("logged in", ex.Message);
        }
    }
}
