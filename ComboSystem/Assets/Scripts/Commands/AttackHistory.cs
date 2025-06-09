using System.Collections.Generic;
using UnityEngine;

public class AttackHistory
{
    private List<Combination> _combinations;
    private List<Attack> _attackHistory = new List<Attack>();

    AttackHistory(Combinations combinations)
    {
        _combinations = combinations.GetCombinations();
    }

    public void AddAttack(Attack attack)
    {
        _attackHistory.Add(attack);
    }

    public void AddAttack(IState state, AttackType attackType)
    {
        Attack attack = new Attack(state, attackType);
        _attackHistory.Add(attack);
    }

    public void ResetHistory()
    {
        _attackHistory.Clear();
    }

    public ICommand CheckForCombo()
    {
        foreach (Combination combination in _combinations)
        {
            if (combination.GetAttacks() == _attackHistory)
            {
                return combination.GetExecute(); 
            }
        }

        return null; 
    }
}
