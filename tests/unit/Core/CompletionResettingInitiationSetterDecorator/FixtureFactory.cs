namespace Paraminter.Processors;

using Moq;

using Paraminter.Cqs;
using Paraminter.Processors.Commands;

internal static class FixtureFactory
{
    public static IFixture Create()
    {
        Mock<ICommandHandler<ISetProcessArgumentAssociationsInitiationCommand>> decorateeMock = new(MockBehavior.Strict);
        Mock<ICommandHandler<IResetProcessArgumentAssociationsCompletionCommand>> completionResetterMock = new(MockBehavior.Strict);

        var sut = new CompletionResettingInitiationSetterDecorator(decorateeMock.Object, completionResetterMock.Object);

        return new Fixture(sut, decorateeMock, completionResetterMock);
    }

    private sealed class Fixture
        : IFixture
    {
        private readonly ICommandHandler<ISetProcessArgumentAssociationsInitiationCommand> Sut;

        private readonly Mock<ICommandHandler<ISetProcessArgumentAssociationsInitiationCommand>> DecorateeMock;
        private readonly Mock<ICommandHandler<IResetProcessArgumentAssociationsCompletionCommand>> CompletionResetterMock;

        public Fixture(
            ICommandHandler<ISetProcessArgumentAssociationsInitiationCommand> sut,
            Mock<ICommandHandler<ISetProcessArgumentAssociationsInitiationCommand>> decorateeMock,
            Mock<ICommandHandler<IResetProcessArgumentAssociationsCompletionCommand>> completionResetterMock)
        {
            Sut = sut;

            DecorateeMock = decorateeMock;
            CompletionResetterMock = completionResetterMock;
        }

        ICommandHandler<ISetProcessArgumentAssociationsInitiationCommand> IFixture.Sut => Sut;

        Mock<ICommandHandler<ISetProcessArgumentAssociationsInitiationCommand>> IFixture.DecorateeMock => DecorateeMock;
        Mock<ICommandHandler<IResetProcessArgumentAssociationsCompletionCommand>> IFixture.CompletionResetterMock => CompletionResetterMock;
    }
}
