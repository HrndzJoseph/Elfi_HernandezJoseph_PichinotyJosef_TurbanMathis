using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSound : MonoBehaviour
{
    [SerializeField] GameObject fireSound;
    [SerializeField] AudioSource sound;
    [SerializeField] AudioSource muffledSound;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        fireSound.gameObject.SetActive(true);
        muffledSound.mute = true;
        sound.mute = true;
    }
    private void OnTriggerExit(Collider other)
    {
        fireSound.gameObject.SetActive(false);
    }
}
