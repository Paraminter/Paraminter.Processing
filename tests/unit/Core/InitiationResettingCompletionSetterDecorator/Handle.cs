namespace Paraminter.Processors;

using Moq;

using Paraminter.Processors.Commands;

using System;

using Xunit;

public sealed class Handle
{
    private readonly IFixture Fixture = FixtureFactory.Create();

    [Fact]
    public void NullCommand_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidCommand_ResetsInitiationAndSetsCompletion()
    {
        var command = Mock.Of<ISetProcessArgumentAssociationsCompletionCommand>();

        var sequence = new MockSequence();

        Fixture.InitiationResetterMock.InSequence(sequence).Setup(static (handler) => handler.Handle(It.IsAny<IResetProcessArgumentAssociationsInitiationCommand>()));
        Fixture.DecorateeMock.InSequence(sequence).Setup((handler) => handler.Handle(command));

        Target(command);

        Fixture.InitiationResetterMock.Verify(static (handler) => handler.Handle(It.IsAny<IResetProcessArgumentAssociationsInitiationCommand>()), Times.Once());
        Fixture.DecorateeMock.Verify((handler) => handler.Handle(command), Times.Once());
    }

    private void Target(
        ISetProcessArgumentAssociationsCompletionCommand command)
    {
        Fixture.Sut.Handle(command);
    }
}
