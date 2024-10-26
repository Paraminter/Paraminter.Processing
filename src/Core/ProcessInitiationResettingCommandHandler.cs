namespace Paraminter.Processing;

using Paraminter.Cqs;
using Paraminter.Processing.Commands;

using System.Threading;
using System.Threading.Tasks;

/// <summary>Handles commands by resetting the initiation status.</summary>
/// <typeparam name="TQuery">The type of the handled commands.</typeparam>
public sealed class ProcessInitiationResettingCommandHandler<TQuery>
    : ICommandHandler<TQuery>
    where TQuery : ICommand
{
    private readonly ICommandHandler<IResetProcessInitiationCommand> InitiationResetter;

    /// <summary>Instantiates a command-handler which resets the initiation status.</summary>
    /// <param name="initiationResetter">Resets the initiation status.</param>
    public ProcessInitiationResettingCommandHandler(
        ICommandHandler<IResetProcessInitiationCommand> initiationResetter)
    {
        InitiationResetter = initiationResetter ?? throw new System.ArgumentNullException(nameof(initiationResetter));
    }

    async Task ICommandHandler<TQuery>.Handle(
        TQuery command,
        CancellationToken cancellationToken)
    {
        if (command is null)
        {
            throw new System.ArgumentNullException(nameof(command));
        }

        await InitiationResetter.Handle(ResetProcessInitiationCommand.Instance, cancellationToken).ConfigureAwait(false);
    }
}
