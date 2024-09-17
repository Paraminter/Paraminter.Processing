namespace Paraminter.Processors;

using Moq;

using Paraminter.Cqs;
using Paraminter.Processors.Commands;

using System;

using Xunit;

public sealed class Constructor
{
    [Fact]
    public void NullInitiationResetter_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target<ICommand>(null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidArguments_ReturnsHandler()
    {
        var result = Target<ICommand>(Mock.Of<ICommandHandler<IResetProcessArgumentAssociationsInitiationCommand>>());

        Assert.NotNull(result);
    }

    private static InitiationResettingCommandHandler<TCommand> Target<TCommand>(
        ICommandHandler<IResetProcessArgumentAssociationsInitiationCommand> initiationResetter)
        where TCommand : ICommand
    {
        return new InitiationResettingCommandHandler<TCommand>(initiationResetter);
    }
}
