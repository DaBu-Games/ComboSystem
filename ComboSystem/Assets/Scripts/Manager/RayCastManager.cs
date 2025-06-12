using UnityEngine;

public class RayCastManager
{
   private Vector3 direction;
   private LayerMask layerMask;
   private Color raycastColor = Color.red;

   private Vector3 position; 

   public RayCastManager(Vector3 direction, LayerMask layerMask)
   {
      this.direction = direction;
      this.layerMask = layerMask;
   }

   public void SetPosition(Transform transform)
   {
      this.position = transform.position;
   }

   public void Raycast(float range)
   {
      Debug.DrawRay(position, direction * range, raycastColor, 1.0f);

      if (Physics.Raycast(position, direction, range, layerMask))
      {
         Debug.Log("Hit");
      }
   }
}
