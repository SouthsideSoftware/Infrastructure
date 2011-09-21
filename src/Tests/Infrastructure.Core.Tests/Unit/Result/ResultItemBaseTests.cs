using System;
using System.Xml.Linq;
using Infrastructure.Core.CodeContracts;
using Infrastructure.Core.Result;
using NUnit.Framework;
using FluentAssertions;

namespace Infrastructure.Core.Tests.Unit.Result
{
    [TestFixture]
    public class ResultItemTests
    {
        [Test]
        public void Constructor_NonZeroCodeAndMessageWithContent_DoesNotThrowException()
        {
            Action act = () => new ResultItem(-1, "this is a test");
            act.ShouldNotThrow();
        }

        [Test]
        public void Constructor_NonZeroCodeAndMessageWithEmptyContent_ThrowsPreconditionExceptionContainsParameterName()
        {
            Action act = () => new ResultItem(-1, "");
            act.ShouldThrow<PreconditionException>().And.Message.Contains("message");
        }

        [Test]
        public void Constructor_NonZeroCodeAndMessageWithWhitespaceContent_ThrowsPreconditionExceptionContainsParameterName()
        {
            Action act = () => new ResultItem(-1, " \t ");
            act.ShouldThrow<PreconditionException>().And.Message.Contains("message");
        }

        [Test]
        public void ToString_Instance_ReturnsExpectedText()
        {
            var item = new ResultItem(-1, "test message");
            item.ToString().Should().Be("-1 - test message");
        }

        [Test]
        public void Equals_CompareTwoRefsToSameInstance_ReturnsTrue()
        {
            var item = new ResultItem(-1, "test message");
            var item2 = item;
            item.Equals(item2).Should().BeTrue();
        }

        [Test]
        public void Equals_CompareTwoInstanceSameContents_ReturnsTrue()
        {
            var item = new ResultItem(-1, "test message");
            var item2 = new ResultItem(-1, "test message");
            item.Equals(item2).Should().BeTrue();
        }

        [Test]
        public void Equals_CompareTwoInstanceDifferingResultCodes_ReturnsFalse()
        {
            var item = new ResultItem(1, "test message");
            var item2 = new ResultItem(-1, "test message");
            item.Equals(item2).Should().BeFalse();
        }

        [Test]
        public void Equals_CompareTwoInstanceDifferingMessage_ReturnsFalse()
        {
            var item = new ResultItem(-1, "test message1");
            var item2 = new ResultItem(-1, "test message2");
            item.Equals(item2).Should().BeFalse();
        }

        [Test]
        public void Equals_CompareInstanceToNull_ReturnsFalse()
        {
            var item = new ResultItem(-1, "test message1");
            item.Equals(null).Should().BeFalse();
        }

        [Test]
        public void Constructor_EnumValueLessThanZero_IsErrorType()
        {
            var item = new ResultItem(-1, "message");
            item.Type.Should().Be(ResultItemType.Error);
        }

        [Test]
        public void Constructor_EnumValueGreaterThanZero_IsWarningType()
        {
            var item = new ResultItem(1, "message");
            item.Type.Should().Be(ResultItemType.Warning);
        }


    }
}
