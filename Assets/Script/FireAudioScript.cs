using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class FireAudioScript : MonoBehaviour
{
    AudioSource himself;
    bool playsound = true;

    // Start is called before the first frame update
    void Start()
    {
        himself = gameObject.GetComponent<AudioSource>();
        PlaySound();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void PlaySound()
    {
        himself.Play();
        himself.loop = true;
    }
}