namespace Paraminter.Processors;

using Moq;

using Paraminter.Cqs;
using Paraminter.Processors.Commands;

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
        var result = Target<ICommand>(Mock.Of<ICommandHandler<ISetProcessArgumentAssociationsInitiationCommand>>());

        Assert.NotNull(result);
    }

    private static InitiationSettingCommandHandler<TCommand> Target<TCommand>(
        ICommandHandler<ISetProcessArgumentAssociationsInitiationCommand> initiationSetter)
        where TCommand : ICommand
    {
        return new InitiationSettingCommandHandler<TCommand>(initiationSetter);
    }
}
