using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCharacter", menuName = "Combat/Character")]
public class Character : ScriptableObject
{
    [SerializeField] private List<InterfaceReference<IComboCommand>> combinations = new List<InterfaceReference<IComboCommand>>();
    [SerializeField]private List<InterfaceReference<IAttackCommand>> attackCommands = new List<InterfaceReference<IAttackCommand>>(); 
    
    public List<IComboCommand> GetCombinations() => combinations.Select(x => x.Value).ToList();
    public List<IAttackCommand> GetAttackCommands() => attackCommands.Select(x => x.Value).ToList();
}
