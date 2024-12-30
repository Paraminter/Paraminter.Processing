namespace Paraminter.Processing;

using Moq;

using Paraminter.Processing.Commands;

internal static class FixtureFactory
{
    public static IFixture<TCommand> Create<TCommand>()
        where TCommand : ICommand
    {
        Mock<ICommandHandler<ISetProcessInitiationCommand>> initiationSetterMock = new();

        var sut = new ProcessInitiationSettingCommandHandler<TCommand>(initiationSetterMock.Object);

        return new Fixture<TCommand>(sut, initiationSetterMock);
    }

    private sealed class Fixture<TCommand>
        : IFixture<TCommand>
        where TCommand : ICommand
    {
        private readonly ICommandHandler<TCommand> Sut;

        private readonly Mock<ICommandHandler<ISetProcessInitiationCommand>> InitiationSetterMock;

        public Fixture(
            ICommandHandler<TCommand> sut,
            Mock<ICommandHandler<ISetProcessInitiationCommand>> initiationSetterMock)
        {
            Sut = sut;

            InitiationSetterMock = initiationSetterMock;
        }

        ICommandHandler<TCommand> IFixture<TCommand>.Sut => Sut;

        Mock<ICommandHandler<ISetProcessInitiationCommand>> IFixture<TCommand>.InitiationSetterMock => InitiationSetterMock;
    }
}
