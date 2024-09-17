namespace Paraminter.Processors;

using Moq;

using Paraminter.Cqs;
using Paraminter.Processors.Queries;

using System;

using Xunit;

public sealed class Constructor
{
    [Fact]
    public void NullInitiationReader_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target<IQuery>(null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidArguments_ReturnsHandler()
    {
        var result = Target<IQuery>(Mock.Of<IQueryHandler<IIsProcessArgumentAssociationsInitiatedQuery, bool>>());

        Assert.NotNull(result);
    }

    private static InitiationReadingQueryHandler<TQuery> Target<TQuery>(
        IQueryHandler<IIsProcessArgumentAssociationsInitiatedQuery, bool> initiationReader)
        where TQuery : IQuery
    {
        return new InitiationReadingQueryHandler<TQuery>(initiationReader);
    }
}
