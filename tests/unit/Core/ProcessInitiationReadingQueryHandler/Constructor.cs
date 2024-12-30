namespace Paraminter.Processing;

using Moq;

using Paraminter.Processing.Queries;

using System;

using Xunit;

public sealed class Constructor
{
    [Fact]
    public void NullInitiationReader_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target<IQuery, object>(null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidArguments_ReturnsHandler()
    {
        var result = Target<IQuery, object>(Mock.Of<IQueryHandler<IIsProcessInitiatedQuery, object>>());

        Assert.NotNull(result);
    }

    private static ProcessInitiationReadingQueryHandler<TQuery, TResponse> Target<TQuery, TResponse>(
        IQueryHandler<IIsProcessInitiatedQuery, TResponse> initiationReader)
        where TQuery : IQuery
    {
        return new ProcessInitiationReadingQueryHandler<TQuery, TResponse>(initiationReader);
    }
}
