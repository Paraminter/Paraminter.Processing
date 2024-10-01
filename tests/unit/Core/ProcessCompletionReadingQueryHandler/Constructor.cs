namespace Paraminter.Processing;

using Moq;

using Paraminter.Cqs;
using Paraminter.Processing.Queries;

using System;

using Xunit;

public sealed class Constructor
{
    [Fact]
    public void NullCompletionReader_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target<IQuery, object>(null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidArguments_ReturnsHandler()
    {
        var result = Target<IQuery, object>(Mock.Of<IQueryHandler<IIsProcessCompletedQuery, object>>());

        Assert.NotNull(result);
    }

    private static ProcessCompletionReadingQueryHandler<TQuery, TResponse> Target<TQuery, TResponse>(
        IQueryHandler<IIsProcessCompletedQuery, TResponse> completionReader)
        where TQuery : IQuery
    {
        return new ProcessCompletionReadingQueryHandler<TQuery, TResponse>(completionReader);
    }
}
