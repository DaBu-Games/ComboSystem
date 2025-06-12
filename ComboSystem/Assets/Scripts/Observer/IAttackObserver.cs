using UnityEngine;

public interface IAttackObserver
{
   void Update(IAttackSubject attackSubject, float dmg); 
}
