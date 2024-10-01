namespace Paraminter.Processing;

using Paraminter.Cqs;
using Paraminter.Processing.Commands;

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

    void ICommandHandler<TQuery>.Handle(
        TQuery command)
    {
        if (command is null)
        {
            throw new System.ArgumentNullException(nameof(command));
        }

        InitiationSetter.Handle(SetProcessInitiationCommand.Instance);
    }
}
