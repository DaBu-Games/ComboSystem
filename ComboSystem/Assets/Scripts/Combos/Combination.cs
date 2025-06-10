using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "CombinationAttack", menuName = "Combat/CombinationAttack")]
public class Combination : ScriptableObject
{
    [SerializeField]private List<Attack> attacks = new List<Attack>();
    [SerializeField]private Attack execute;
    
    public List<Attack> GetAttacks() => attacks;
    public Attack GetExecute() => execute;
}
