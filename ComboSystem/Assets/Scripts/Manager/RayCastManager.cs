using System.Collections.Generic;
using UnityEngine;

public class RayCastManager : ISubject
{
   private readonly Vector3 _direction;
   private readonly LayerMask _layerMask;
   private Vector3 _position; 
   private List<IObserver> _observers = new List<IObserver>();
   private float _currentDmg = 0f;

   public RayCastManager(Vector3 direction, LayerMask layerMask)
   {
      this._direction = direction;
      this._layerMask = layerMask;
   }

   public void SetPosition(Transform transform)
   {
      this._position = transform.position;
   }

   public void Raycast(float range, float dmg)
   {
      if (Physics.Raycast(_position, _direction, range, _layerMask))
      {
         _currentDmg = dmg;
         Notify();
      }
   }

   public void Attach(IObserver observer)
   {
      _observers.Add(observer);
   }

   public void Detach(IObserver observer)
   {
      _observers.Remove(observer);
   }

   public void Notify()
   {
      foreach (IObserver observer in _observers)
      {
         observer.Update(this, _currentDmg);
      }
   }
}
