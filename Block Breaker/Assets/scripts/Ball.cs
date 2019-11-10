using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour 
{
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float Randomness = 0.2f;
    bool hasStarted= false;

    // cahces component references
    AudioSource MyAudioSource;
    Vector2 paddleToBallVector;
    Rigidbody2D myRigidBody;
    // Start is called before the first frame update
    void Start()
    {
       
        paddleToBallVector = transform.position - paddle1.transform.position;
         LockBallToPaddle();
        MyAudioSource = GetComponent<AudioSource>();
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
if(!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
     }


public void LockBallToPaddle()
    {
Vector2 paddlePos = new Vector2(paddle1.transform.position.x,paddle1.transform.position.y);
        transform.position = paddleToBallVector + paddlePos;

    }
public void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush,yPush);
            hasStarted = true;

        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(Random.Range(0f,Randomness),Random.Range(0f,Randomness));


        if (hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)] ;
            MyAudioSource.PlayOneShot(clip);
            myRigidBody.velocity += velocityTweak;
        }
        
    }
}
