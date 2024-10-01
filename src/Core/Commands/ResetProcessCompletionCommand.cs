﻿namespace Paraminter.Processing.Commands;

internal sealed class ResetProcessCompletionCommand
    : IResetProcessCompletionCommand
{
    public static IResetProcessCompletionCommand Instance { get; } = new ResetProcessCompletionCommand();

    private ResetProcessCompletionCommand() { }
}
