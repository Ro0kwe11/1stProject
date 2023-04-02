using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour

{
   private float speed = 0.2f;
   public int damage = 4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 objectPosition  = transform.position;
        objectPosition.y += speed;
        transform.position = objectPosition;
        if(ScreenHelper.IsPositionOnScreen(transform.position) == false){
           Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D otherCollider){
        GameObject othrtObject = otherCollider.gameObject;
        EnemyShip enemyScript = othrtObject.GetComponent<EnemyShip>();
        if(enemyScript != null){
            enemyScript.hp -= damage;
            Destroy(gameObject);
            if (enemyScript.hp <= 0){
                 enemyScript.DestroyEnemyShip();
            }
        }
    }

}
