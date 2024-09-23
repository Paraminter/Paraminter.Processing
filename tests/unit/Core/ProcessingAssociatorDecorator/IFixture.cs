namespace Paraminter.Processors;

using Moq;

using Paraminter.Commands;
using Paraminter.Cqs;
using Paraminter.Models;
using Paraminter.Processors.Commands;

internal interface IFixture<TData>
    where TData : IAssociateArgumentsData
{
    public abstract ICommandHandler<IAssociateArgumentsCommand<TData>> Sut { get; }

    public abstract Mock<ICommandHandler<IAssociateArgumentsCommand<TData>>> DecorateeMock { get; }

    public abstract Mock<ICommandHandler<ISetProcessInitiationCommand>> InitiationSetterMock { get; }
    public abstract Mock<ICommandHandler<ISetProcessCompletionCommand>> CompletionSetterMock { get; }
}
