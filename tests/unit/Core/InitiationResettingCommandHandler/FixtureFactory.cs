namespace Paraminter.Processors;

using Moq;

using Paraminter.Cqs;
using Paraminter.Processors.Commands;

internal static class FixtureFactory
{
    public static IFixture<TCommand> Create<TCommand>()
        where TCommand : ICommand
    {
        Mock<ICommandHandler<IResetProcessArgumentAssociationsInitiationCommand>> initiationResetterMock = new();

        var sut = new InitiationResettingCommandHandler<TCommand>(initiationResetterMock.Object);

        return new Fixture<TCommand>(sut, initiationResetterMock);
    }

    private sealed class Fixture<TCommand>
        : IFixture<TCommand>
        where TCommand : ICommand
    {
        private readonly ICommandHandler<TCommand> Sut;

        private readonly Mock<ICommandHandler<IResetProcessArgumentAssociationsInitiationCommand>> InitiationResetterMock;

        public Fixture(
            ICommandHandler<TCommand> sut,
            Mock<ICommandHandler<IResetProcessArgumentAssociationsInitiationCommand>> initiationResetterMock)
        {
            Sut = sut;

            InitiationResetterMock = initiationResetterMock;
        }

        ICommandHandler<TCommand> IFixture<TCommand>.Sut => Sut;

        Mock<ICommandHandler<IResetProcessArgumentAssociationsInitiationCommand>> IFixture<TCommand>.InitiationResetterMock => InitiationResetterMock;
    }
}
