namespace Paraminter.Processing;

using Paraminter.Cqs;
using Paraminter.Processing.Commands;

using System.Threading;
using System.Threading.Tasks;

/// <summary>Handles commands by setting the initiation status.</summary>
/// <typeparam name="TQuery">The type of the handled commands.</typeparam>
public sealed class ProcessInitiationSettingCommandHandler<TQuery>
    : ICommandHandler<TQuery>
    where TQuery : ICommand
{
    private readonly ICommandHandler<ISetProcessInitiationCommand> InitiationSetter;

    /// <summary>Instantiates a command-handler which sets the initiation status.</summary>
    /// <param name="initiationSetter">Sets the initiation status.</param>
    public ProcessInitiationSettingCommandHandler(
        ICommandHandler<ISetProcessInitiationCommand> initiationSetter)
    {
        InitiationSetter = initiationSetter ?? throw new System.ArgumentNullException(nameof(initiationSetter));
    }

    async Task ICommandHandler<TQuery>.Handle(
        TQuery command,
        CancellationToken cancellationToken)
    {
        if (command is null)
        {
            throw new System.ArgumentNullException(nameof(command));
        }

        await InitiationSetter.Handle(SetProcessInitiationCommand.Instance, cancellationToken).ConfigureAwait(false);
    }
}
