using MarvelSharp.Interfaces;
using MarvelSharp.Model;
using MarvelSharp.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelSharp.Tests.Unit.Services
{
    [TestFixture]
    public class ComicServiceTests
    {
        private const string MockApiPublicKey = "";
        private const string MockApiPrivateKey = "";
        private const string MockUrl = "https://mock-url.com/";
        private const string MockHttpResponse = "{ 'code' : '200' }";

        private Mock<IHttpService> _mockHttpService;
        private Mock<IUrlBuilder> _mockUrlBuilder;
        private Mock<IParser<Comic>> _mockParser;

        [SetUp]
        public void SetUp()
        {
            _mockHttpService = new Mock<IHttpService>();
            _mockUrlBuilder = new Mock<IUrlBuilder>();
            _mockParser = new Mock<IParser<Comic>>();
            _mockUrlBuilder.Setup(u => u.BuildUrl(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int?>(), It.IsAny<int?>(), null)).Returns(MockUrl);
            _mockHttpService.Setup(h => h.GetAsync(It.IsAny<string>())).ReturnsAsync(MockHttpResponse);
            _mockParser.Setup(p => p.ParseList(It.IsAny<object>())).Returns(new List<Comic>());
        }

        private ComicService GetSubjectUnderTest()
        {
            return new ComicService(_mockHttpService.Object, _mockParser.Object, _mockUrlBuilder.Object, MockApiPublicKey, MockApiPrivateKey);
        }

        [Test]
        public void GetAllAsync_CallsApiMethod()
        {
            // Arrange
            var sut = GetSubjectUnderTest();

            // Act
            var result = sut.GetAllAsync(null).Result;

            // Assert
            _mockUrlBuilder.Verify(u => u.BuildUrl(MockApiPublicKey, MockApiPrivateKey, MarvelApi.GetAllComics, null, null, null), Times.Once);
            _mockHttpService.Verify(s => s.GetAsync(MockUrl), Times.Once);
            _mockParser.Verify(p => p.GetResponse<List<Comic>>(It.IsAny<object>()), Times.Once);
        }

        [Test]
        public void GetByIdAsync_CallsApiMethod()
        {
            // Arrange
            var sut = GetSubjectUnderTest();

            // Act
            var result = sut.GetByIdAsync(0).Result;

            // Assert
            _mockUrlBuilder.Verify(u => u.BuildUrl(MockApiPublicKey, MockApiPrivateKey, string.Format(MarvelApi.GetComic, 0), 1, 0, null), Times.Once);
            _mockHttpService.Verify(s => s.GetAsync(MockUrl), Times.Once);
            _mockParser.Verify(p => p.GetResponse<Comic>(It.IsAny<object>()), Times.Once);
        }

        [Test]
        public void GetByCharacterAsync_CallsApiMethod()
        {
            // Arrange
            var sut = GetSubjectUnderTest();

            // Act
            var result = sut.GetByCharacterAsync(0).Result;

            // Assert
            _mockUrlBuilder.Verify(u => u.BuildUrl(MockApiPublicKey, MockApiPrivateKey, string.Format(MarvelApi.GetCharacterComics, 0), null, null, null), Times.Once);
            _mockHttpService.Verify(s => s.GetAsync(MockUrl), Times.Once);
            _mockParser.Verify(p => p.GetResponse<List<Comic>>(It.IsAny<object>()), Times.Once);
        }

        [Test]
        public void GetByCreatorAsync_CallsApiMethod()
        {
            // Arrange
            var sut = GetSubjectUnderTest();

            // Act
            var result = sut.GetByCreatorAsync(0).Result;

            // Assert
            _mockUrlBuilder.Verify(u => u.BuildUrl(MockApiPublicKey, MockApiPrivateKey, string.Format(MarvelApi.GetCreatorComics, 0), null, null, null), Times.Once);
            _mockHttpService.Verify(s => s.GetAsync(MockUrl), Times.Once);
            _mockParser.Verify(p => p.GetResponse<List<Comic>>(It.IsAny<object>()), Times.Once);
        }

        [Test]
        public void GetByEventAsync_CallsApiMethod()
        {
            // Arrange
            var sut = GetSubjectUnderTest();

            // Act
            var result = sut.GetByEventAsync(0).Result;

            // Assert
            _mockUrlBuilder.Verify(u => u.BuildUrl(MockApiPublicKey, MockApiPrivateKey, string.Format(MarvelApi.GetEventComics, 0), null, null, null), Times.Once);
            _mockHttpService.Verify(s => s.GetAsync(MockUrl), Times.Once);
            _mockParser.Verify(p => p.GetResponse<List<Comic>>(It.IsAny<object>()), Times.Once);
        }

        [Test]
        public void GetBySeriesAsync_CallsApiMethod()
        {
            // Arrange
            var sut = GetSubjectUnderTest();

            // Act
            var result = sut.GetBySeriesAsync(0).Result;

            // Assert
            _mockUrlBuilder.Verify(u => u.BuildUrl(MockApiPublicKey, MockApiPrivateKey, string.Format(MarvelApi.GetSeriesComics, 0), null, null, null), Times.Once);
            _mockHttpService.Verify(s => s.GetAsync(MockUrl), Times.Once);
            _mockParser.Verify(p => p.GetResponse<List<Comic>>(It.IsAny<object>()), Times.Once);
        }

        [Test]
        public void GetByStoryAsync_CallsApiMethod()
        {
            // Arrange
            var sut = GetSubjectUnderTest();

            // Act
            var result = sut.GetByStoryAsync(0).Result;

            // Assert
            _mockUrlBuilder.Verify(u => u.BuildUrl(MockApiPublicKey, MockApiPrivateKey, string.Format(MarvelApi.GetStoryComics, 0), null, null, null), Times.Once);
            _mockHttpService.Verify(s => s.GetAsync(MockUrl), Times.Once);
            _mockParser.Verify(p => p.GetResponse<List<Comic>>(It.IsAny<object>()), Times.Once);
        }
    }
}
