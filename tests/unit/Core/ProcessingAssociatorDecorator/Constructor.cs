namespace Paraminter.Processors;

using Moq;

using Paraminter.Commands;
using Paraminter.Cqs;
using Paraminter.Models;
using Paraminter.Processors.Commands;

using System;

using Xunit;

public sealed class Constructor
{
    [Fact]
    public void NullDecoratee_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target<IAssociateArgumentsData>(
            null!,
            Mock.Of<ICommandHandler<ISetProcessInitiationCommand>>(),
            Mock.Of<ICommandHandler<ISetProcessCompletionCommand>>()));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void NullInitiationSetter_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(
            Mock.Of<ICommandHandler<IAssociateArgumentsCommand<IAssociateArgumentsData>>>(),
            null!,
            Mock.Of<ICommandHandler<ISetProcessCompletionCommand>>()));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void NullCompletionSetter_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(
            Mock.Of<ICommandHandler<IAssociateArgumentsCommand<IAssociateArgumentsData>>>(),
            Mock.Of<ICommandHandler<ISetProcessInitiationCommand>>(),
            null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidArguments_ReturnsHandler()
    {
        var result = Target(
            Mock.Of<ICommandHandler<IAssociateArgumentsCommand<IAssociateArgumentsData>>>(),
            Mock.Of<ICommandHandler<ISetProcessInitiationCommand>>(),
            Mock.Of<ICommandHandler<ISetProcessCompletionCommand>>());

        Assert.NotNull(result);
    }

    private static ProcessingAssociatorDecorator<TData> Target<TData>(
        ICommandHandler<IAssociateArgumentsCommand<TData>> decoratee,
        ICommandHandler<ISetProcessInitiationCommand> initiationSetter,
        ICommandHandler<ISetProcessCompletionCommand> completionSetter)
        where TData : IAssociateArgumentsData
    {
        return new ProcessingAssociatorDecorator<TData>(decoratee, initiationSetter, completionSetter);
    }
}
