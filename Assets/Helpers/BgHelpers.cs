using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgHelpers : MonoBehaviour
{
   public Renderer backRenderer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (backRenderer != null){
            backRenderer.material.mainTextureOffset=new Vector2(0.0f, 0.1f*Time.time);
        }
    }
}
