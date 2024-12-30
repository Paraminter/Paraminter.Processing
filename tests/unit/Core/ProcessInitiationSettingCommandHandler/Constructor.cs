namespace Paraminter.Processing;

using Moq;

using Paraminter.Processing.Commands;

using System;

using Xunit;

public sealed class Constructor
{
    [Fact]
    public void NullInitiationSetter_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target<ICommand>(null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidArguments_ReturnsHandler()
    {
        var result = Target<ICommand>(Mock.Of<ICommandHandler<ISetProcessInitiationCommand>>());

        Assert.NotNull(result);
    }

    private static ProcessInitiationSettingCommandHandler<TCommand> Target<TCommand>(
        ICommandHandler<ISetProcessInitiationCommand> initiationSetter)
        where TCommand : ICommand
    {
        return new ProcessInitiationSettingCommandHandler<TCommand>(initiationSetter);
    }
}
