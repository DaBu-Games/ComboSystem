using UnityEngine;

public interface IAttackSubject
{
    void Attach(IAttackObserver attackObserver);
    void Detach(IAttackObserver attackObserver);
    void Notify();
}
