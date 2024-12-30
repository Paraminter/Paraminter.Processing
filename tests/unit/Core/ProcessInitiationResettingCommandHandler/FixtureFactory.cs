namespace Paraminter.Processing;

using Moq;

using Paraminter.Processing.Commands;

internal static class FixtureFactory
{
    public static IFixture<TCommand> Create<TCommand>()
        where TCommand : ICommand
    {
        Mock<ICommandHandler<IResetProcessInitiationCommand>> initiationResetterMock = new();

        var sut = new ProcessInitiationResettingCommandHandler<TCommand>(initiationResetterMock.Object);

        return new Fixture<TCommand>(sut, initiationResetterMock);
    }

    private sealed class Fixture<TCommand>
        : IFixture<TCommand>
        where TCommand : ICommand
    {
        private readonly ICommandHandler<TCommand> Sut;

        private readonly Mock<ICommandHandler<IResetProcessInitiationCommand>> InitiationResetterMock;

        public Fixture(
            ICommandHandler<TCommand> sut,
            Mock<ICommandHandler<IResetProcessInitiationCommand>> initiationResetterMock)
        {
            Sut = sut;

            InitiationResetterMock = initiationResetterMock;
        }

        ICommandHandler<TCommand> IFixture<TCommand>.Sut => Sut;

        Mock<ICommandHandler<IResetProcessInitiationCommand>> IFixture<TCommand>.InitiationResetterMock => InitiationResetterMock;
    }
}
