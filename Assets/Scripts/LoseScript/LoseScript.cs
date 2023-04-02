using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScript : MonoBehaviour
{
    public void CloseGame(){
        Application.Quit();
   }
   public void ReplayLevel(){
       SceneManager.LoadSceneAsync(SceneID.gameSceneID);
   }
}
