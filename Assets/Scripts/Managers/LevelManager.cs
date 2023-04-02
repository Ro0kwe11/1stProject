using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
   private AudioSource musicSources;
   private PassiveEgroup CarentGroup;
   private int maxGroupavaount = 4;
   private int destroydGroupCounts = 0;
     EnemyGroupManager groupManager;
    public void Start()
    {
       destroydGroupCounts = 0;
       groupManager = GetComponent<EnemyGroupManager>();
       CarentGroup =  groupManager.CreateEnemyGroup();
       musicSources = GetComponent <AudioSource> ();
       musicSources.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (CarentGroup.Dead == true){
           Destroy(CarentGroup);
            destroydGroupCounts += 1;
           if (destroydGroupCounts == maxGroupavaount) {
              SceneManager.LoadSceneAsync(SceneID.winSceneID);
           } else {
               CarentGroup =  groupManager.CreateEnemyGroup();
           }
           
        }
    }
}
