using System;
using System.Collections.Generic;
using MarvelSharp.Enums;
using MarvelSharp.Parameters;
using NUnit.Framework;

namespace MarvelSharp.Tests.Unit.Parameters
{
    public class CharacterParametersTests
    {
        [Test]
        public void ToDictionary_ReturnsCorrectDictionary()
        {
            // Arrange
            var sut = new CharacterParameters
            {
                Name = "TestName456",
                NameStartsWith = "TestStartName789",
                ModifiedSince = new DateTime(2015, 1, 15, 8, 59, 21),
                Comics = new List<int> { 1, 2, 3 },
                Series = new List<int> { 12 },
                Events = new List<int>(),
                Stories = new List<int> { 0 },
                OrderBy = CharacterOrder.NameAscending,
                Limit = 5,
                Offset = 10
            };

            // Act
            var result = sut.ToDictionary();

            // Assert - TO DO
        }
    }
}
