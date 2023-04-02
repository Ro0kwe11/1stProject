using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{ 
    private AudioSource soundSource;
    public AudioClip boom;
    public int hp = 20;
    public GameObject bulletOriginal;
    public Animator spriteAnimator;
    public GameObject hpBonusOriginal;
    private System.Random Randomizator = new System.Random();
    void Start(){
        soundSource = GetComponent<AudioSource>();
    }
   public void shoot(){

    print(spriteAnimator.GetBool("isDead"));
       GameObject newBullet = Instantiate(bulletOriginal);
       newBullet.transform.position = transform.position;
   }
   public void DestroyEnemyShip(){
       soundSource.PlayOneShot(boom);
       transform.parent = null;
       spriteAnimator.SetBool("isDead", true);
       print(spriteAnimator.GetBool("isDead"));
   }

   public void OnDestroyAnimationEnd(){
    double hpDrop = Randomizator.NextDouble();
    if(hpDrop>0.5){
        GameObject newHPbonus = Instantiate(hpBonusOriginal);
        newHPbonus.transform.position = transform.position;
    }
    
    Destroy(gameObject);
   }
}