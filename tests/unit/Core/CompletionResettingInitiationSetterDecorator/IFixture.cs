namespace Paraminter.Processors;

using Moq;

using Paraminter.Cqs;
using Paraminter.Processors.Commands;

internal interface IFixture
{
    public abstract ICommandHandler<ISetProcessArgumentAssociationsInitiationCommand> Sut { get; }

    public abstract Mock<ICommandHandler<ISetProcessArgumentAssociationsInitiationCommand>> DecorateeMock { get; }
    public abstract Mock<ICommandHandler<IResetProcessArgumentAssociationsCompletionCommand>> CompletionResetterMock { get; }
}
