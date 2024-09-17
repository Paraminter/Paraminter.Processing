namespace Paraminter.Processors;

using Moq;

using Paraminter.Cqs;
using Paraminter.Processors.Commands;

internal interface IFixture<in TCommand>
    where TCommand : ICommand
{
    public abstract ICommandHandler<TCommand> Sut { get; }

    public abstract Mock<ICommandHandler<ISetProcessArgumentAssociationsCompletionCommand>> CompletionSetterMock { get; }
}
