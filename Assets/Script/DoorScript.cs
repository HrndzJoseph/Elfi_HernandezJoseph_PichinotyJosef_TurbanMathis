using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField] AudioSource door_audioSource;
    [SerializeField] AudioClip OpenDoorSound;
    [SerializeField] AudioClip CloseDoorSound;
    

    Animator animator;

    [SerializeField] bool isFirst;
        
    // Start is called before the first frame update
    void Start()
    {
        //Assignation de son propre animator en tant que variable pour pouvoir y accéder plus simplement
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //déclence l'animation d'ouverture des portes
    //Y intégrer le jeu d'un son ? Le lancement d'une corroutine ?
    private void OnTriggerEnter(Collider other)
    {
        animator.SetBool("In", true);
        //other.gameObject.GetComponent<Character>().OpenDoor();
        door_audioSource.PlayOneShot(OpenDoorSound);
        


    }

    //déclence l'animation de fermeture des portes
    //Y intégrer le jeu d'un son ? Le lancement d'une corroutine ?
    private void OnTriggerExit(Collider other)
    {
        animator.SetBool("In", false);
        //other.gameObject.GetComponent<Character>().CloseDoor();
        door_audioSource.PlayOneShot(OpenDoorSound);

    }

    //Créer une fonction publique à appeler lors d'un animation event ?

}
