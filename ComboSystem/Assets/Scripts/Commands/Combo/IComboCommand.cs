using System.Collections.Generic;
using UnityEngine;

public interface IComboCommand : IAttackCommand
{
    List<IAttackCommand> GetAttackCommands();
}
