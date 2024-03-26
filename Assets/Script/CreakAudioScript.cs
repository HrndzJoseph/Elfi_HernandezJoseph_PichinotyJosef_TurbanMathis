using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class CreakAudioScript : MonoBehaviour
{
    [SerializeField] List<AudioClip> creakList = new List<AudioClip>();

    AudioSource himself;
    bool playsound = true;

    // Start is called before the first frame update
    void Start()
    {
        himself = gameObject.GetComponent<AudioSource>();
        StartCoroutine(PlaySound());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator PlaySound()
    {
        while (playsound)
        {
            himself.PlayOneShot(creakList[Random.Range(0, creakList.Count)]);

            int timeToWait = Random.Range(5, 10);
            yield return new WaitForSeconds(timeToWait);
        }
    }
}
