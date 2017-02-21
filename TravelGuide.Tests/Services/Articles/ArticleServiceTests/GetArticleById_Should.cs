using Moq;
using NUnit.Framework;
using System;
using TravelGuide.Data;
using TravelGuide.Models.Articles;
using TravelGuide.Services.Articles;
using TravelGuide.Services.Factories;

namespace TravelGuide.Tests.Services.Articles.ArticleServiceTests
{
    [TestFixture]
    public class GetArticleById_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenPassedIdIsNull()
        {
            // Arrange
            var contextMock = new Mock<ITravelGuideContext>();
            var factoryMock = new Mock<IArticleFactory>();
            var commentFactoryMock = new Mock<IArticleCommentFactory>();
            var targetArticle = new Article();

            contextMock.Setup(x => x.Articles.Find(It.IsAny<Guid>())).Returns(targetArticle);
            var service = new ArticleService(contextMock.Object, factoryMock.Object, commentFactoryMock.Object);

            // Act 
            var article = service.GetArticleById(Guid.NewGuid());

            // Assert
            Assert.AreSame(targetArticle, article);
        }
    }
}
