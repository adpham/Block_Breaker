using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    //parameters

    [SerializeField] int totalBlocks;
    int currentBlocks;

    //cached reference

    SceneLoader sceneloader;

    private void Start()
    {
        sceneloader = FindObjectOfType<SceneLoader>(); 
    }

    public void CountBlocks()
    {
        totalBlocks++;
    }

    public void BlockDestroyed()
    {
       totalBlocks--;
        Ball ball = FindObjectOfType<Ball>();
        if (totalBlocks <= 0)
        {
            ball.BallStop();
            ball.NextStageSound();
            Invoke("LoadNext", 1f);
        }
    }

    public void LoadNext()
    {
        sceneloader.LoadNextScene();
    }

  
}
