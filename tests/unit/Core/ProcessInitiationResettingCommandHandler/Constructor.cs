namespace Paraminter.Processing;

using Moq;

using Paraminter.Cqs;
using Paraminter.Processing.Commands;

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
        var result = Target<ICommand>(Mock.Of<ICommandHandler<IResetProcessInitiationCommand>>());

        Assert.NotNull(result);
    }

    private static ProcessInitiationResettingCommandHandler<TCommand> Target<TCommand>(
        ICommandHandler<IResetProcessInitiationCommand> initiationResetter)
        where TCommand : ICommand
    {
        return new ProcessInitiationResettingCommandHandler<TCommand>(initiationResetter);
    }
}
