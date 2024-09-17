namespace Paraminter.Processors;

using Moq;

using Paraminter.Cqs;
using Paraminter.Processors.Commands;

internal static class FixtureFactory
{
    public static IFixture<TCommand> Create<TCommand>()
        where TCommand : ICommand
    {
        Mock<ICommandHandler<ISetProcessArgumentAssociationsInitiationCommand>> initiationSetterMock = new();

        var sut = new InitiationSettingCommandHandler<TCommand>(initiationSetterMock.Object);

        return new Fixture<TCommand>(sut, initiationSetterMock);
    }

    private sealed class Fixture<TCommand>
        : IFixture<TCommand>
        where TCommand : ICommand
    {
        private readonly ICommandHandler<TCommand> Sut;

        private readonly Mock<ICommandHandler<ISetProcessArgumentAssociationsInitiationCommand>> InitiationSetterMock;

        public Fixture(
            ICommandHandler<TCommand> sut,
            Mock<ICommandHandler<ISetProcessArgumentAssociationsInitiationCommand>> initiationSetterMock)
        {
            Sut = sut;

            InitiationSetterMock = initiationSetterMock;
        }

        ICommandHandler<TCommand> IFixture<TCommand>.Sut => Sut;

        Mock<ICommandHandler<ISetProcessArgumentAssociationsInitiationCommand>> IFixture<TCommand>.InitiationSetterMock => InitiationSetterMock;
    }
}
