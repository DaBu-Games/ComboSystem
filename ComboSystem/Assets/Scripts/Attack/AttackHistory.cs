using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AttackHistory
{
    private List<IComboCommand> _combinations;
    private List<IAttackCommand> _attackHistory = new List<IAttackCommand>();

    private float _lastAttackTime = 0f;
    private readonly float _resetMargin = 3f; 

    public AttackHistory(Character combinations)
    {
        _combinations = combinations.GetCombinations();
    }
    
    public void AddAttack(IAttackCommand attackCommand)
    {
        float currentTime = Time.time;
        
        // reset the attack history if the last attack is longer ago then the reset margin
        if(currentTime - _lastAttackTime > _resetMargin && _lastAttackTime != 0f)
            ResetHistory();
        
        _attackHistory.Add(attackCommand);
        _lastAttackTime = currentTime;
    }

    public void ResetHistory()
    {
        Debug.Log("Reset history");
        _attackHistory.Clear();
    }

    public IComboCommand CheckForCombo()
    {
        if (_attackHistory.Count == 0)
            return null;
        
        foreach (IComboCommand combination in _combinations)
        {
            List<IAttackCommand> attackCommands = combination.GetAttackCommands();
            
            if (attackCommands.SequenceEqual(_attackHistory))
            {
                ResetHistory();
                return combination;
            }
            else if ( _attackHistory.Count < attackCommands.Count)
            {
                List<IAttackCommand> commands = attackCommands.GetRange(0, _attackHistory.Count);
                if (commands.SequenceEqual(_attackHistory))
                {
                    return null;
                }
            }
        }

        ResetHistory(); 
        return null; 
    }
}
