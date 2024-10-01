namespace Paraminter.Processing.Commands;

internal sealed class SetProcessCompletionCommand
    : ISetProcessCompletionCommand
{
    public static ISetProcessCompletionCommand Instance { get; } = new SetProcessCompletionCommand();

    private SetProcessCompletionCommand() { }
}
