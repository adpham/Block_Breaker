using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    //[SerializeField] AudioClip breakSound;
    
     AudioSource audioSource;
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameOverSound();
        Invoke("GameOverScene", 3f);
    }

    private void GameOverSound()
    {
        
        GetComponent<AudioSource>().Play();
        Camera.main.GetComponent<AudioSource>().mute = true;
    }

    public void GameOverScene()
    {
        SceneManager.LoadScene(3);
    }
}
