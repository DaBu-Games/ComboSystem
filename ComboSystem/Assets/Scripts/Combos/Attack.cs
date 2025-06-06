using System;

[Serializable]
public class Attack
{
    public InterfaceReference<IState> state;
    public InterfaceReference<ICommand> command;
    
    public IState GetState() => state.Value;
    public ICommand GetCommand() => command.Value;
}
