namespace Paraminter.Processors;

using Moq;

using Paraminter.Cqs;
using Paraminter.Processors.Queries;

using System;

using Xunit;

public sealed class Constructor
{
    [Fact]
    public void NullCompletionReader_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target<IQuery>(null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidArguments_ReturnsHandler()
    {
        var result = Target<IQuery>(Mock.Of<IQueryHandler<IIsProcessArgumentAssociationsCompletedQuery, bool>>());

        Assert.NotNull(result);
    }

    private static CompletionReadingQueryHandler<TQuery> Target<TQuery>(
        IQueryHandler<IIsProcessArgumentAssociationsCompletedQuery, bool> completionReader)
        where TQuery : IQuery
    {
        return new CompletionReadingQueryHandler<TQuery>(completionReader);
    }
}
