using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using FluentAssertions;
using Infrastructure.Core.Helpers;

namespace Infrastructure.Core.Tests.Unit.Helpers.StringHelper {
    [TestFixture]
    public class TrimToMaxLengthTests {
        [Test]
        public void TrimToMaxLength_StringLessThanMax_ReturnsString() {
            var s = "this is unchanged";
            s.TrimToMaxLength(100).Should().Be("this is unchanged");
        }

        [Test]
        public void TrimToMaxLength_StringExactlyMaxLength_ReturnsString() {
            var s = "length 8";
            s.TrimToMaxLength(8).Should().Be("length 8");
        }

        [Test]
        public void TrimToMaxLength_StringOneMoreThanMaxLength_ReturnsStringWithmaxLength() {
            var s = "length 8";
            s.TrimToMaxLength(7).Should().Be("length ");
        }

        [Test]
        public void TrimToMaxLength_StringMuchMoreThanMaxLength_ReturnsStringWithmaxLength() {
            var s = "This is a pretty long string";
            s.TrimToMaxLength(1).Should().Be("T");
        }
    }
}
