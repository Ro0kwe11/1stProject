using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    // Start is called before the first frame update
   public int damage = 5;
   public float speed = 0.1f;

   void FixedUpdate()
   {
    Vector3 objectPosition = transform.position;
    objectPosition.y -= speed;
    transform.position = objectPosition;
    if(ScreenHelper.IsPositionOnScreen(transform.position) == false){
        Destroy(gameObject);
    }
   }
}
