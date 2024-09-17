namespace Paraminter.Processors;

using Moq;

using Paraminter.Cqs;
using Paraminter.Processors.Commands;

internal interface IFixture
{
    public abstract ICommandHandler<ISetProcessArgumentAssociationsCompletionCommand> Sut { get; }

    public abstract Mock<ICommandHandler<ISetProcessArgumentAssociationsCompletionCommand>> DecorateeMock { get; }
    public abstract Mock<ICommandHandler<IResetProcessArgumentAssociationsInitiationCommand>> InitiationResetterMock { get; }
}
