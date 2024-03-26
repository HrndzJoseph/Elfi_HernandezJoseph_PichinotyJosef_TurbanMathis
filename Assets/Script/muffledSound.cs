using System.Collections;
using System.Collections.Generic;
using System.Media;
using UnityEngine;

public class muffledSound : MonoBehaviour
{
    [SerializeField] AudioSource sound;
    [SerializeField] AudioSource mufledSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        sound.mute = true;
        mufledSound.mute = false;
    }
    private void OnTriggerExit(Collider other)
    {
        mufledSound.mute = true;
        sound.mute = true;
    }
}
