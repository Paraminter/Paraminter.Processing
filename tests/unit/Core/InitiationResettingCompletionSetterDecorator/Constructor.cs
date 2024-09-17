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
        var result = Record.Exception(() => Target(null!, Mock.Of<ICommandHandler<IResetProcessArgumentAssociationsInitiationCommand>>()));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void NullInitiationResetter_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(Mock.Of<ICommandHandler<ISetProcessArgumentAssociationsCompletionCommand>>(), null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidArguments_ReturnsDecorator()
    {
        var result = Target(Mock.Of<ICommandHandler<ISetProcessArgumentAssociationsCompletionCommand>>(), Mock.Of<ICommandHandler<IResetProcessArgumentAssociationsInitiationCommand>>());

        Assert.NotNull(result);
    }

    private static InitiationResettingCompletionSetterDecorator Target(
        ICommandHandler<ISetProcessArgumentAssociationsCompletionCommand> decoratee,
        ICommandHandler<IResetProcessArgumentAssociationsInitiationCommand> initiationResetter)
    {
        return new InitiationResettingCompletionSetterDecorator(decoratee, initiationResetter);
    }
}
