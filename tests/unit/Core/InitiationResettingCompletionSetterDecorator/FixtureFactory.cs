namespace Paraminter.Processors;

using Moq;

using Paraminter.Cqs;
using Paraminter.Processors.Commands;

internal static class FixtureFactory
{
    public static IFixture Create()
    {
        Mock<ICommandHandler<ISetProcessArgumentAssociationsCompletionCommand>> decorateeMock = new(MockBehavior.Strict);
        Mock<ICommandHandler<IResetProcessArgumentAssociationsInitiationCommand>> initiationResetterMock = new(MockBehavior.Strict);

        var sut = new InitiationResettingCompletionSetterDecorator(decorateeMock.Object, initiationResetterMock.Object);

        return new Fixture(sut, decorateeMock, initiationResetterMock);
    }

    private sealed class Fixture
        : IFixture
    {
        private readonly ICommandHandler<ISetProcessArgumentAssociationsCompletionCommand> Sut;

        private readonly Mock<ICommandHandler<ISetProcessArgumentAssociationsCompletionCommand>> DecorateeMock;
        private readonly Mock<ICommandHandler<IResetProcessArgumentAssociationsInitiationCommand>> InitiationResetterMock;

        public Fixture(
            ICommandHandler<ISetProcessArgumentAssociationsCompletionCommand> sut,
            Mock<ICommandHandler<ISetProcessArgumentAssociationsCompletionCommand>> decorateeMock,
            Mock<ICommandHandler<IResetProcessArgumentAssociationsInitiationCommand>> initiationResetterMock)
        {
            Sut = sut;

            DecorateeMock = decorateeMock;
            InitiationResetterMock = initiationResetterMock;
        }

        ICommandHandler<ISetProcessArgumentAssociationsCompletionCommand> IFixture.Sut => Sut;

        Mock<ICommandHandler<ISetProcessArgumentAssociationsCompletionCommand>> IFixture.DecorateeMock => DecorateeMock;
        Mock<ICommandHandler<IResetProcessArgumentAssociationsInitiationCommand>> IFixture.InitiationResetterMock => InitiationResetterMock;
    }
}
