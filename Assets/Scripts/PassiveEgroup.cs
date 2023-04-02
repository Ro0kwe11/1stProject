using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveEgroup : MonoBehaviour
{
    public EnemyShip Ship1;
    public EnemyShip Ship2;
    public EnemyShip Ship3;
    public bool Dead = false;
    private float speed = 0.2f;
    private List<EnemyShip> Ships = new List<EnemyShip>();
    private bool isMovingLeft = true;
    private System.Random randomDegenerator = new System.Random();
    void Start()
    {
        Ships.Add(Ship1);
        Ships.Add(Ship2);
        Ships.Add(Ship3);
        InvokeRepeating("GroupShoot", 1.0f, 1.0f);
    }

    void FixedUpdate()
    {
        Ships.RemoveAll(item => item == null);
        if (Ships.Count == 0){
          Dead = true;
          CancelInvoke();
          return;
        }

       if (isMovingLeft == true){
          float minX = MixX();
          float stepX = minX - speed;
          if(stepX<-12.39){
               isMovingLeft = false;
            }else{
                transform.position = new Vector3(
                transform.position.x - speed,
                transform.position.y,
                0
                );
          
         }

       } else {
           float maxX = MaxX();
           float stepx = maxX + speed;
           if(stepx > 12.39){
            isMovingLeft = true;
           }else{
                transform.position = new Vector3(
                transform.position.x + speed,
                transform.position.y,
                0
                );
           }
       }
    } 


    float MaxX() {
        int i = 0;
        float max= float.MinValue;
        while(i<Ships.Count){
            if(Ships[i].transform.position.x > max){
                max = Ships[i].transform.position.x;
            }
            i++;
        }
        return max;
    }

    float MixX()
    {
        int i = 0;
        float min= float.MaxValue;
        while(i<Ships.Count){
            if(Ships[i].transform.position.x < min){
                min = Ships[i].transform.position.x;
            }
            i++;
        }
        return min;
    }

    void GroupShoot(){
        int randomIndex = randomDegenerator.Next(Ships.Count);
        Ships[randomIndex].shoot();
    }
}


