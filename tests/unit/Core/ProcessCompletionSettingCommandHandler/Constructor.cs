namespace Paraminter.Processing;

using Moq;

using Paraminter.Cqs;
using Paraminter.Processing.Commands;

using System;

using Xunit;

public sealed class Constructor
{
    [Fact]
    public void NullCompletionSetter_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target<ICommand>(null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidArguments_ReturnsHandler()
    {
        var result = Target<ICommand>(Mock.Of<ICommandHandler<ISetProcessCompletionCommand>>());

        Assert.NotNull(result);
    }

    private static ProcessCompletionSettingCommandHandler<TCommand> Target<TCommand>(
        ICommandHandler<ISetProcessCompletionCommand> completionSetter)
        where TCommand : ICommand
    {
        return new ProcessCompletionSettingCommandHandler<TCommand>(completionSetter);
    }
}
