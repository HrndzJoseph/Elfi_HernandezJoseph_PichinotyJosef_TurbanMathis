using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    [SerializeField]
    private bool isFirst;

    private void OnTriggerEnter(Collider other)
    {
        if (isFirst)
        {
            other.gameObject.GetComponent<Character>().isNormal = GetOppositeBool(other.gameObject.GetComponent<Character>().isNormal);
            other.gameObject.GetComponent<Character>().isMud = GetOppositeBool(other.gameObject.GetComponent<Character>().isMud);
            print("other.gameObject.GetComponent<Character>().isReverb = " + other.gameObject.GetComponent<Character>().isReverb);
        }
        else
        {
            other.gameObject.GetComponent<Character>().isReverb = GetOppositeBool(other.gameObject.GetComponent<Character>().isReverb);
            print("other.gameObject.GetComponent<Character>().isReverb = " + other.gameObject.GetComponent<Character>().isReverb);
            other.gameObject.GetComponent<Character>().isNormal = GetOppositeBool(other.gameObject.GetComponent<Character>().isNormal);
        }
    }

    // Update is called once per frame
    private bool GetOppositeBool(bool currentBool)
    {
        if(currentBool)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
