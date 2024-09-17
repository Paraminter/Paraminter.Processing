namespace Paraminter.Processors;

using Moq;

using Paraminter.Commands;
using Paraminter.Cqs;
using Paraminter.Models;
using Paraminter.Processors.Commands;

internal interface IFixture<TData>
    where TData : IAssociateAllArgumentsData
{
    public abstract ICommandHandler<IAssociateAllArgumentsCommand<TData>> Sut { get; }

    public abstract Mock<ICommandHandler<IAssociateAllArgumentsCommand<TData>>> DecorateeMock { get; }

    public abstract Mock<ICommandHandler<ISetProcessArgumentAssociationsInitiationCommand>> InitiationSetterMock { get; }
    public abstract Mock<ICommandHandler<ISetProcessArgumentAssociationsCompletionCommand>> CompletionSetterMock { get; }
}
