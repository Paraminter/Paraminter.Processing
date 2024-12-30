namespace Paraminter.Processing;

using Moq;

using Paraminter.Processing.Commands;

internal interface IFixture<in TCommand>
    where TCommand : ICommand
{
    public abstract ICommandHandler<TCommand> Sut { get; }

    public abstract Mock<ICommandHandler<IResetProcessInitiationCommand>> InitiationResetterMock { get; }
}
