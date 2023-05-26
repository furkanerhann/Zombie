using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
    public AudioSource walkingSound, walkingFastSound;
    void Update()
    {
        
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            if(Input.GetKey(KeyCode.LeftShift))
            {
                walkingSound.enabled = false;
                walkingFastSound.enabled = true;
            }
            else{
                walkingSound.enabled = true;
                walkingFastSound.enabled = false;
            }
        }
        else
        {
            walkingSound.enabled = false;
            walkingFastSound.enabled = false;
        }
    }
}
