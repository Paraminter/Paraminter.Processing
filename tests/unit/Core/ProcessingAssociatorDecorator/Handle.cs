namespace Paraminter.Processors;

using Moq;

using Paraminter.Commands;
using Paraminter.Models;
using Paraminter.Processors.Commands;

using System;

using Xunit;

public sealed class Handle
{
    [Fact]
    public void NullCommand_ThrowsArgumentNullException()
    {
        var fixture = FixtureFactory.Create<IAssociateArgumentsData>();

        var result = Record.Exception(() => Target(fixture, null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidCommand_ResetsInitiationAndSetsCompletion()
    {
        var fixture = FixtureFactory.Create<IAssociateArgumentsData>();

        var command = Mock.Of<IAssociateArgumentsCommand<IAssociateArgumentsData>>();

        var sequence = new MockSequence();

        fixture.InitiationSetterMock.InSequence(sequence).Setup(static (handler) => handler.Handle(It.IsAny<ISetProcessArgumentAssociationsInitiationCommand>()));
        fixture.DecorateeMock.InSequence(sequence).Setup((handler) => handler.Handle(command));
        fixture.CompletionSetterMock.InSequence(sequence).Setup(static (handler) => handler.Handle(It.IsAny<ISetProcessArgumentAssociationsCompletionCommand>()));

        Target(fixture, command);

        fixture.InitiationSetterMock.Verify(static (handler) => handler.Handle(It.IsAny<ISetProcessArgumentAssociationsInitiationCommand>()), Times.Once());
        fixture.DecorateeMock.Verify((handler) => handler.Handle(command), Times.Once());
        fixture.CompletionSetterMock.Verify(static (handler) => handler.Handle(It.IsAny<ISetProcessArgumentAssociationsCompletionCommand>()), Times.Once());
    }

    private static void Target<TData>(
        IFixture<TData> fixture,
        IAssociateArgumentsCommand<TData> command)
        where TData : IAssociateArgumentsData
    {
        fixture.Sut.Handle(command);
    }
}
