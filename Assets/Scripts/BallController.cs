using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BallController : MonoBehaviour
{

    public Rigidbody rb;
    public ParticleSystem moveEffect;
    private AudioClip moveSound;
    public AudioSource playerAudio;
   
   
    public float speed = 15;

    private bool isMoving;
    private Vector3 moveDirection;
    private Vector3 nextCollisionPosition;

    public int minSwipeRecognition = 500;
    private Vector2 swipePositionLastFrame;
    private Vector2 swipePositionCurrentFrame;
    private Vector2 currentSwipe;

    private Color solveColor;

    private void Start()
    {
        solveColor = Random.ColorHSV(0.5f, 1);
        GetComponent<MeshRenderer>().material.color = solveColor;
        playerAudio = GetComponent<AudioSource>();
       
        

    }



    private void FixedUpdate()
    {
        if (isMoving)
        {
            rb.velocity = moveDirection * speed;
           
           

        }
        Collider[] hitColliders = Physics.OverlapSphere(transform.position - (Vector3.up /2), 0.05f);
        int i = 0;
        while (i < hitColliders.Length)
        {
            GroundPiece ground = hitColliders[i].transform.GetComponent<GroundPiece>();
            if(ground && !ground.isColored)
            {
                ground.ChangeColor(solveColor);
            }
            i++;
        }

        if (nextCollisionPosition != Vector3.zero)
        {
            if (Vector3.Distance(transform.position, nextCollisionPosition) < 1)
            {
                isMoving = false;
                StopMoveEffect();
                moveDirection = Vector3.zero;
                nextCollisionPosition = Vector3.zero;

            }

        }

        if (isMoving)
        
            return;
       
        // Swipe mechanism

        if (Input.GetMouseButton(0))
        {
            swipePositionCurrentFrame = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            if (swipePositionLastFrame != Vector2.zero)
            {
                currentSwipe = swipePositionCurrentFrame - swipePositionLastFrame;

                if (currentSwipe.sqrMagnitude < minSwipeRecognition)
         
                    return;
                

                currentSwipe.Normalize();

                // Up/Down

                if (currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
                {
                    // Go up/down
                    SetDestination(currentSwipe.y > 0 ? Vector3.forward : Vector3.back);
                 
                   
                    
                  
                }

                if (currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
                {
                    // Go left/right
                    SetDestination(currentSwipe.x > 0 ? Vector3.right : Vector3.left);
                    
                }
            }

            swipePositionLastFrame = swipePositionCurrentFrame;
        }

        if (Input.GetMouseButtonUp(0))
        {
            swipePositionLastFrame = Vector2.zero;
            currentSwipe = Vector2.zero;
            
        }

        
    }



    private void SetDestination(Vector3 direction)
    {
        moveDirection = direction;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, direction, out hit, 100f))
        {
            nextCollisionPosition = hit.point;
        }

        isMoving = true;
        StartMoveEffect();
        
       


    }

    //void Explode()
    //{
    //Instantiate(explosionFx, transform.position, explosionFx.transform.rotation);

    //}

    

    void StartMoveEffect()
    {
        moveEffect.Play();
        playerAudio.Play();
        
        
    }

    void StopMoveEffect()
    {
        moveEffect.Stop();
    }
}
