using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Character : MonoBehaviour
{
    Camera cam;
    CharacterController characterController;
    float maxSpeed = 10, acceleration = 10, jumpForce = 5;
    float speed, verticalMovement;
    Vector3 direction, directionForward, directionRight, nextDir;
    Animator animator;
    [SerializeField]
    private AudioClip[] stepSounds;
    [SerializeField]
    private AudioClip[] reverbStepSounds;
    [SerializeField]
    private AudioClip[] dirtStepSounds;
    [SerializeField]
    AudioClip OpenDoorSound;
    [SerializeField]
    AudioClip CloseDoorSound;

    private TerrainDetector terrainDetector;
    private AudioSource player_audioSource;
    private AudioClip previousAudioClip;
    private AudioClip previousReverbAudioClip;
    private AudioClip previousMudAudioClip;

    public bool isReverb = false;
    public bool isNormal = false;
    public bool isMud = true;


    // Start is called before the first frame update
    void Awake()
    {
        cam = Camera.main;
        direction = transform.forward;
        nextDir = transform.forward;
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>(); 
        player_audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        gravity();

        Move();


        //apply the calculated movement to the character controller movement system
        characterController.Move((direction * speed + verticalMovement * Vector3.up) * Time.deltaTime);

        animator.SetFloat("Speed", speed / maxSpeed);
    }

    private void Move()
    {
        if ((Input.GetAxisRaw("Vertical")) != 0 || (Input.GetAxisRaw("Horizontal")) != 0)
        {
            //gets the inputs from keyboard arrows and defines the direction depending on the camera's orientation;

            directionForward = cam.transform.forward;
            directionForward.y = 0;
            directionForward *= Input.GetAxisRaw("Vertical");

            directionRight = cam.transform.right;
            directionRight.y = 0;
            directionRight *= Input.GetAxisRaw("Horizontal");

            nextDir = Vector3.Normalize(directionForward + directionRight);

            //Direction interpolation between the current direction and the inputed direction
            direction = Vector3.Lerp(direction, nextDir, Time.deltaTime * 2);

            //Calculate the speed increasement depending on the time spent pushing an arrow button;

            if (speed < maxSpeed)
            {
                speed += acceleration * Time.deltaTime;
            }
            else
            {
                speed = maxSpeed;
            }

        }
        else
        {
            //Calculate the speed decreasement depending on the time since no arrow button is pressed;

            if (speed != 0)
            {
                if (speed <= 2 * acceleration * Time.deltaTime)
                    speed = 0;
                else
                {
                    speed -= 2 * acceleration * Time.deltaTime;
                }
            }
        }

        //make the object rotate toward its movement;
        transform.rotation = Quaternion.LookRotation(direction, transform.up);
    }

    private void gravity()
    {
        if (verticalMovement <= 0 && characterController.isGrounded)
        {
            verticalMovement = -5;
        }
        else
        {
            verticalMovement -= jumpForce * 2 * Time.deltaTime;
        }
    }

    // Fonction appelée lors de chaque pas grâce à un animation event intégré dans le cycle de marche du personnage
    public void StepSound()
    {
        

        // À remplacer lorsque vous intégrerez les sons de pas
        if (isNormal)
        {
            int rnd = UnityEngine.Random.Range(0, stepSounds.Count());
            if (previousAudioClip == null || previousAudioClip != stepSounds[rnd])
            {
                GetComponent<AudioSource>().PlayOneShot(stepSounds[rnd]);
                previousAudioClip = stepSounds[rnd];
            }
            else if (previousAudioClip == stepSounds[rnd])
            {
                stepSounds = stepSounds.Where(e => e != stepSounds[rnd]).ToArray();

                int rnd2 = UnityEngine.Random.Range(0, stepSounds.Count());
                GetComponent<AudioSource>().PlayOneShot(stepSounds[rnd2]);

                stepSounds = stepSounds.Concat(new AudioClip[] { previousAudioClip }).ToArray();
                previousAudioClip = stepSounds[rnd2];
            }
        }        
        else if(isMud)
        {
            int rnd = UnityEngine.Random.Range(0, dirtStepSounds.Count());
            if (previousMudAudioClip == null || previousMudAudioClip != dirtStepSounds[rnd])
            {
                GetComponent<AudioSource>().PlayOneShot(dirtStepSounds[rnd]);
                previousMudAudioClip = dirtStepSounds[rnd];
            }
            else if (previousMudAudioClip == dirtStepSounds[rnd])
            {
                dirtStepSounds = dirtStepSounds.Where(e => e != dirtStepSounds[rnd]).ToArray();

                int rnd2 = UnityEngine.Random.Range(0, dirtStepSounds.Count());
                GetComponent<AudioSource>().PlayOneShot(dirtStepSounds[rnd2]);

                dirtStepSounds = dirtStepSounds.Concat(new AudioClip[] { previousMudAudioClip }).ToArray();
                previousMudAudioClip = dirtStepSounds[rnd2];
            }
        }
        else if (isReverb)
        {
            int rnd = UnityEngine.Random.Range(0, reverbStepSounds.Count());
            if (previousReverbAudioClip == null || previousReverbAudioClip != reverbStepSounds[rnd])
            {
                GetComponent<AudioSource>().PlayOneShot(reverbStepSounds[rnd]);
                previousReverbAudioClip = reverbStepSounds[rnd];
            }
            else if (previousReverbAudioClip == reverbStepSounds[rnd])
            {
                reverbStepSounds = reverbStepSounds.Where(e => e != reverbStepSounds[rnd]).ToArray();

                int rnd2 = UnityEngine.Random.Range(0, reverbStepSounds.Count());
                GetComponent<AudioSource>().PlayOneShot(reverbStepSounds[rnd2]);

                reverbStepSounds = reverbStepSounds.Concat(new AudioClip[] { previousReverbAudioClip }).ToArray();
                previousReverbAudioClip = reverbStepSounds[rnd2];
            }
        }
    }

}
