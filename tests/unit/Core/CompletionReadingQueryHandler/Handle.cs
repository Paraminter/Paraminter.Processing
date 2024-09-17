namespace Paraminter.Processors;

using Moq;

using Paraminter.Cqs;
using Paraminter.Processors.Queries;

using System;

using Xunit;

public sealed class Handle
{
    [Fact]
    public void NullQuery_ThrowsArgumentNullException()
    {
        var fixture = FixtureFactory.Create<IQuery>();

        var result = Record.Exception(() => Target(fixture, null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidQuery_ReadsCompletion()
    {
        var expected = true;

        var fixture = FixtureFactory.Create<IQuery>();

        fixture.CompletionReaderMock.Setup(static (handler) => handler.Handle(It.IsAny<IIsProcessArgumentAssociationsCompletedQuery>())).Returns(expected);

        var result = Target(fixture, Mock.Of<IQuery>());

        Assert.Equal(expected, result);
    }

    private static bool Target<TQuery>(
        IFixture<TQuery> fixture,
        TQuery query)
        where TQuery : IQuery
    {
        return fixture.Sut.Handle(query);
    }
}
