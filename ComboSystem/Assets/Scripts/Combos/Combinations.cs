using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCombinations", menuName = "Combat/Combinations")]
public class Combinations : ScriptableObject
{
    [SerializeField] private List<Combination> combinations = new List<Combination>();
    
    public List<Combination> GetCombinations() => combinations;
}
