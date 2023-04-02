using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceShip : MonoBehaviour
{
    private AudioSource soundsSources;
     private static float MAX_HEALTH = 50; 
     private float speed = 0.1f;
     private float health = MAX_HEALTH;
     private int hitCount = 0;
     public GameObject BulletO;
     public GameObject hp1;
     public GameObject hp2;
     public GameObject hp3;
     public GameObject hp4;
     public GameObject hp5;
     public GameObject hp6;
     public GameObject hp7;
     public GameObject hp8;
     public GameObject hp9;
     public GameObject hp10;
     public AudioClip shootSound;
     private List<GameObject> hpList = new List<GameObject>();

     void Start(){
        hpList.Add(hp1);
        hpList.Add(hp2);
        hpList.Add(hp3);
        hpList.Add(hp3);
        hpList.Add(hp4);
        hpList.Add(hp5);
        hpList.Add(hp6);
        hpList.Add(hp7);
        hpList.Add(hp8);
        hpList.Add(hp9);
        hpList.Add(hp10);
        soundsSources = GetComponent <AudioSource>();
     }
    
    void Update()
    {
        bool KeyUp = Input.GetKeyUp(KeyCode.Space);
        if (KeyUp)
        {
            GameObject BulletC;
            BulletC = Instantiate(BulletO);
            BulletC.transform.position = transform.position;
            soundsSources.PlayOneShot(shootSound);
        }
    }
    void FixedUpdate()
    {
        bool KeyUp = Input.GetKey(KeyCode.A);
        if (KeyUp)
        {
            Vector3 ObjectPosition = transform.position;
            ObjectPosition.x -= speed;
            transform.position = ObjectPosition;
        }
        bool KeyDown = Input.GetKey(KeyCode.D);
        if (KeyDown)
        {
             Vector3 ObjectPosition = transform.position;
            ObjectPosition.x += speed;
            transform.position = ObjectPosition;
        }
        
    }

    void OnTriggerEnter2D(Collider2D otherCollider) {
        GameObject otherObject = otherCollider.gameObject;
        EnemyBullet bulletScript = otherObject.GetComponent<EnemyBullet>();
        if (bulletScript != null){
            health = health - bulletScript.damage;
            onHit();
            Destroy(otherObject);
            if (health <= 0)
            {
                SceneManager.LoadSceneAsync(SceneID.loseSceneID);
                Destroy(gameObject);
            
            }
        }
        HealthsBonus bonusHPscript = otherObject.GetComponent<HealthsBonus>();
        if (bonusHPscript != null){
           Destroy(otherObject); 
           RestoreHealth();
        }
    }
    void RestoreHealth(){
        print("Collecting health, comrat");
        health = MAX_HEALTH;
        hitCount = 0;
        foreach(GameObject curentItem in hpList){
           curentItem.SetActive(true);
        } 
    }

void onHit(){
    hpList[hitCount].SetActive(false);
    hitCount += 1;
}
}




