namespace Paraminter.Processors;

using Moq;

using Paraminter.Commands;
using Paraminter.Cqs;
using Paraminter.Models;
using Paraminter.Processors.Commands;

internal static class FixtureFactory
{
    public static IFixture<TData> Create<TData>()
        where TData : IAssociateAllArgumentsData
    {
        Mock<ICommandHandler<IAssociateAllArgumentsCommand<TData>>> decorateeMock = new(MockBehavior.Strict);

        Mock<ICommandHandler<ISetProcessArgumentAssociationsInitiationCommand>> initiationSetterMock = new(MockBehavior.Strict);
        Mock<ICommandHandler<ISetProcessArgumentAssociationsCompletionCommand>> completionSetterMock = new(MockBehavior.Strict);

        var sut = new ProcessingAssociatorDecorator<TData>(decorateeMock.Object, initiationSetterMock.Object, completionSetterMock.Object);

        return new Fixture<TData>(sut, decorateeMock, initiationSetterMock, completionSetterMock);
    }

    private sealed class Fixture<TData>
        : IFixture<TData>
        where TData : IAssociateAllArgumentsData
    {
        private readonly ICommandHandler<IAssociateAllArgumentsCommand<TData>> Sut;

        private readonly Mock<ICommandHandler<IAssociateAllArgumentsCommand<TData>>> DecorateeMock;

        private readonly Mock<ICommandHandler<ISetProcessArgumentAssociationsInitiationCommand>> InitiationSetterMock;
        private readonly Mock<ICommandHandler<ISetProcessArgumentAssociationsCompletionCommand>> CompletionSetterMock;

        public Fixture(
            ICommandHandler<IAssociateAllArgumentsCommand<TData>> sut,
            Mock<ICommandHandler<IAssociateAllArgumentsCommand<TData>>> decorateeMock,
            Mock<ICommandHandler<ISetProcessArgumentAssociationsInitiationCommand>> initiationSetterMock,
            Mock<ICommandHandler<ISetProcessArgumentAssociationsCompletionCommand>> completionSetterMock)
        {
            Sut = sut;

            DecorateeMock = decorateeMock;

            InitiationSetterMock = initiationSetterMock;
            CompletionSetterMock = completionSetterMock;
        }

        ICommandHandler<IAssociateAllArgumentsCommand<TData>> IFixture<TData>.Sut => Sut;

        Mock<ICommandHandler<IAssociateAllArgumentsCommand<TData>>> IFixture<TData>.DecorateeMock => DecorateeMock;

        Mock<ICommandHandler<ISetProcessArgumentAssociationsInitiationCommand>> IFixture<TData>.InitiationSetterMock => InitiationSetterMock;
        Mock<ICommandHandler<ISetProcessArgumentAssociationsCompletionCommand>> IFixture<TData>.CompletionSetterMock => CompletionSetterMock;
    }
}
