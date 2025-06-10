using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AttackHistory
{
    private List<Combination> _combinations;
    private Dictionary<IState, AttackType> _attackHistory = new(); 

    AttackHistory(Character combinations)
    {
        _combinations = combinations.GetCombinations();
    }
    public void AddAttack(IState state, AttackType attackType)
    {
        _attackHistory[state] = attackType;
    }

    public void ResetHistory()
    {
        _attackHistory.Clear();
    }

    public Attack CheckForCombo()
    {
        List<IState> stateHistory = _attackHistory.Keys.ToList();
        List<AttackType> attackTypesHistory = _attackHistory.Values.ToList();
        
        foreach (Combination combination in _combinations)
        {
            List<Attack> attacks = combination.GetAttacks();
            
            if(attacks.Count != _attackHistory.Count)
                continue;

            for (int i = 0; i < attacks.Count; i++)
            {
                if (attacks[i].GetAttackType() != attackTypesHistory[i] || attacks[i].GetState() != stateHistory[i] )
                {
                    return null; 
                }
            }

            return combination.GetExecute(); 
        }

        return null; 
    }
}
