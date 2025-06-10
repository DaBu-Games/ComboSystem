using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCharacter", menuName = "Combat/Character")]
public class Character : ScriptableObject
{
    [SerializeField] private List<Combination> combinations = new List<Combination>();
    [SerializeField] private List<Attack> allAttacks = new List<Attack>(); 
    
    public List<Combination> GetCombinations() => combinations;
    public List<Attack> GetAllAttacks() => allAttacks;
}
