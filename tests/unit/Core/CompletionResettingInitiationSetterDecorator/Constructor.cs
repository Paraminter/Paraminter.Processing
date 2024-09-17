namespace Paraminter.Processors;

using Moq;

using Paraminter.Cqs;
using Paraminter.Processors.Commands;

using System;

using Xunit;

public sealed class Constructor
{
    [Fact]
    public void NullDecoratee_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(null!, Mock.Of<ICommandHandler<IResetProcessArgumentAssociationsCompletionCommand>>()));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void NullCompletionResetter_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(Mock.Of<ICommandHandler<ISetProcessArgumentAssociationsInitiationCommand>>(), null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidArguments_ReturnsDecorator()
    {
        var result = Target(Mock.Of<ICommandHandler<ISetProcessArgumentAssociationsInitiationCommand>>(), Mock.Of<ICommandHandler<IResetProcessArgumentAssociationsCompletionCommand>>());

        Assert.NotNull(result);
    }

    private static CompletionResettingInitiationSetterDecorator Target(
        ICommandHandler<ISetProcessArgumentAssociationsInitiationCommand> decoratee,
        ICommandHandler<IResetProcessArgumentAssociationsCompletionCommand> completionResetter)
    {
        return new CompletionResettingInitiationSetterDecorator(decoratee, completionResetter);
    }
}
