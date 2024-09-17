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
    public void ValidCommand_ResetsCompletionAndSetsInitiation()
    {
        var command = Mock.Of<ISetProcessArgumentAssociationsInitiationCommand>();

        var sequence = new MockSequence();

        Fixture.CompletionResetterMock.InSequence(sequence).Setup(static (handler) => handler.Handle(It.IsAny<IResetProcessArgumentAssociationsCompletionCommand>()));
        Fixture.DecorateeMock.InSequence(sequence).Setup((handler) => handler.Handle(command));

        Target(command);

        Fixture.CompletionResetterMock.Verify(static (handler) => handler.Handle(It.IsAny<IResetProcessArgumentAssociationsCompletionCommand>()), Times.Once());
        Fixture.DecorateeMock.Verify((handler) => handler.Handle(command), Times.Once());
    }

    private void Target(
        ISetProcessArgumentAssociationsInitiationCommand command)
    {
        Fixture.Sut.Handle(command);
    }
}
