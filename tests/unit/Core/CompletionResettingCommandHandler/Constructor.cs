namespace Paraminter.Processors;

using Moq;

using Paraminter.Cqs;
using Paraminter.Processors.Commands;

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
        var result = Target<ICommand>(Mock.Of<ICommandHandler<IResetProcessArgumentAssociationsCompletionCommand>>());

        Assert.NotNull(result);
    }

    private static CompletionResettingCommandHandler<TCommand> Target<TCommand>(
        ICommandHandler<IResetProcessArgumentAssociationsCompletionCommand> completionResetter)
        where TCommand : ICommand
    {
        return new CompletionResettingCommandHandler<TCommand>(completionResetter);
    }
}
