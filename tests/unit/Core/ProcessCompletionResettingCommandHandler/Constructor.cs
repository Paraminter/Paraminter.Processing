namespace Paraminter.Processing;

using Moq;

using Paraminter.Processing.Commands;

using System;

using Xunit;

public sealed class Constructor
{
    [Fact]
    public void NullCompletionResetter_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target<ICommand>(null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidArguments_ReturnsHandler()
    {
        var result = Target<ICommand>(Mock.Of<ICommandHandler<IResetProcessCompletionCommand>>());

        Assert.NotNull(result);
    }

    private static ProcessCompletionResettingCommandHandler<TCommand> Target<TCommand>(
        ICommandHandler<IResetProcessCompletionCommand> completionResetter)
        where TCommand : ICommand
    {
        return new ProcessCompletionResettingCommandHandler<TCommand>(completionResetter);
    }
}
