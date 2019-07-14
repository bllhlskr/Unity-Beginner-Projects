using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
 //parameters
    [SerializeField]int breakableBlocks;// serialized for debugging purposes


    //cached referanse
    sceneloader sceneloader;
        private void Start()
    {
        sceneloader = FindObjectOfType<sceneloader>();
    }
    public void CountBlocks()
    {
        breakableBlocks++;
      
    }
    public void BlockDestroyed()
    {
        breakableBlocks--;
        if(breakableBlocks <= 0)
        {
            sceneloader.LoadNextScene();
            
        }
    }
    
}
