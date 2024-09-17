namespace Paraminter.Processors;

using Moq;

using Paraminter.Cqs;
using Paraminter.Processors.Commands;

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
        var result = Target<ICommand>(Mock.Of<ICommandHandler<ISetProcessArgumentAssociationsCompletionCommand>>());

        Assert.NotNull(result);
    }

    private static CompletionSettingCommandHandler<TCommand> Target<TCommand>(
        ICommandHandler<ISetProcessArgumentAssociationsCompletionCommand> completionSetter)
        where TCommand : ICommand
    {
        return new CompletionSettingCommandHandler<TCommand>(completionSetter);
    }
}
