﻿using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using MarvelSharp.Internal.Interfaces;
using MarvelSharp.Internal.Services;
using MarvelSharp.Model;
using static MarvelSharp.MarvelApiResources;

namespace MarvelSharp.Tests.Unit.Services
{
    [TestFixture]
    public class CharacterServiceTests
    {
        private const string MockApiPublicKey = "";
        private const string MockApiPrivateKey = "";
        private const string MockUrl = "https://mock-url.com/";
        private const string MockHttpResponse = "{ 'code' : '200' }";

        private Mock<IHttpService> _mockHttpService;
        private Mock<IUrlBuilder> _mockUrlBuilder;
        private Mock<IParser<Character>> _mockParser;

        [SetUp]
        public void SetUp()
        {
            _mockHttpService = new Mock<IHttpService>();
            _mockUrlBuilder = new Mock<IUrlBuilder>();
            _mockParser = new Mock<IParser<Character>>();
            _mockUrlBuilder.Setup(u => u.BuildUrl(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int?>(), It.IsAny<int?>(), null)).Returns(MockUrl);
            _mockHttpService.Setup(h => h.GetAsync(It.IsAny<string>())).ReturnsAsync(MockHttpResponse);
            _mockParser.Setup(p => p.ParseList(It.IsAny<object>())).Returns(new List<Character>());
        }

        private CharacterService GetSubjectUnderTest()
        {
            return new CharacterService(_mockHttpService.Object, _mockParser.Object, _mockUrlBuilder.Object, MockApiPublicKey, MockApiPrivateKey);
        }

        [Test]
        public void GetAllAsync_CallsApiMethod()
        {
            // Arrange
            var sut = GetSubjectUnderTest();

            // Act
            var result = sut.GetAllAsync(null).Result;

            // Assert
            _mockUrlBuilder.Verify(u => u.BuildUrl(MockApiPublicKey, MockApiPrivateKey, UrlSuffixAllCharacters, null, null, null), Times.Once);
            _mockHttpService.Verify(s => s.GetAsync(MockUrl), Times.Once);
            _mockParser.Verify(p => p.GetResponse<List<Character>>(It.IsAny<object>()), Times.Once);
        }

        [Test]
        public void GetByIdAsync_CallsApiMethod()
        {
            // Arrange
            var sut = GetSubjectUnderTest();

            // Act
            var result = sut.GetByIdAsync(0).Result;

            // Assert
            _mockUrlBuilder.Verify(u => u.BuildUrl(MockApiPublicKey, MockApiPrivateKey, string.Format(UrlSuffixCharacterById, 0), 1, 0, null), Times.Once);
            _mockHttpService.Verify(s => s.GetAsync(MockUrl), Times.Once);
            _mockParser.Verify(p => p.GetResponse<Character>(It.IsAny<object>()), Times.Once);
        }

        [Test]
        public void GetByComicAsync_CallsApiMethod()
        {
            // Arrange
            var sut = GetSubjectUnderTest();

            // Act
            var result = sut.GetByComicAsync(0).Result;

            // Assert
            _mockUrlBuilder.Verify(u => u.BuildUrl(MockApiPublicKey, MockApiPrivateKey, string.Format(UrlSuffixComicCharacters, 0), null, null, null), Times.Once);
            _mockHttpService.Verify(s => s.GetAsync(MockUrl), Times.Once);
            _mockParser.Verify(p => p.GetResponse<List<Character>>(It.IsAny<object>()), Times.Once);
        }

        [Test]
        public void GetByEventAsync_CallsApiMethod()
        {
            // Arrange
            var sut = GetSubjectUnderTest();

            // Act
            var result = sut.GetByEventAsync(0).Result;

            // Assert
            _mockUrlBuilder.Verify(u => u.BuildUrl(MockApiPublicKey, MockApiPrivateKey, string.Format(UrlSuffixEventCharacters, 0), null, null, null), Times.Once);
            _mockHttpService.Verify(s => s.GetAsync(MockUrl), Times.Once);
            _mockParser.Verify(p => p.GetResponse<List<Character>>(It.IsAny<object>()), Times.Once);
        }


        [Test]
        public void GetBySeriesAsync_CallsApiMethod()
        {
            // Arrange
            var sut = GetSubjectUnderTest();

            // Act
            var result = sut.GetBySeriesAsync(0).Result;

            // Assert
            _mockUrlBuilder.Verify(u => u.BuildUrl(MockApiPublicKey, MockApiPrivateKey, string.Format(UrlSuffixSeriesCharacters, 0), null, null, null), Times.Once);
            _mockHttpService.Verify(s => s.GetAsync(MockUrl), Times.Once);
            _mockParser.Verify(p => p.GetResponse<List<Character>>(It.IsAny<object>()), Times.Once);
        }

        [Test]
        public void GetByStoryAsync_CallsApiMethod()
        {
            // Arrange
            var sut = GetSubjectUnderTest();

            // Act
            var result = sut.GetByStoryAsync(0).Result;

            // Assert
            _mockUrlBuilder.Verify(u => u.BuildUrl(MockApiPublicKey, MockApiPrivateKey, string.Format(UrlSuffixStoryCharacters, 0), null, null, null), Times.Once);
            _mockHttpService.Verify(s => s.GetAsync(MockUrl), Times.Once);
            _mockParser.Verify(p => p.GetResponse<List<Character>>(It.IsAny<object>()), Times.Once);
        }
    }
}
