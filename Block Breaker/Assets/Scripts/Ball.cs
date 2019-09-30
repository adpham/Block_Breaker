using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //config parameters

    [SerializeField] Paddle paddle1;
    [SerializeField] AudioClip[] ballSounds;
    float randomFactor = 1f;
    float randomFactorX = 5f;
    float randomFactorY = 20f;
   

    //state

    Vector2 paddleToBallVector;
    bool hasStarted = false;

    //cached component references
    AudioSource myAudioSource;
    Rigidbody2D myRigidBody2D;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockBalltoPaddle();
            LaunchOnMouseClick();
        }
        
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            myRigidBody2D.velocity = new Vector2(UnityEngine.Random.Range(-randomFactorX, randomFactorX), 
                                            UnityEngine.Random.Range(randomFactorY / 2, randomFactorY));
            hasStarted = true;
        }
    }

    private void LockBalltoPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(
            UnityEngine.Random.Range(-randomFactor / 2, randomFactor),
            UnityEngine.Random.Range(-randomFactor / 2, randomFactor)
            );

        if (hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            myRigidBody2D.velocity += velocityTweak;
        }
    }

    public void BallStop()
    {
        myRigidBody2D.velocity = new Vector2(myRigidBody2D.velocity.x * .1f, myRigidBody2D.velocity.y * .1f);
        
    }

    public void NextStageSound()
    {
        myAudioSource.Play();
    }
}
