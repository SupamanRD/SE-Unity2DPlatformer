using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBoxManager : MonoBehaviour {

    public GameObject character;

    void OnTrigger2DEnter(Collider2D other)
    {
        if (character.tag == "Player")
        {
            if (other.tag == "Enemy")
            {

            }
            else if (other.tag == "Player")
            {
                //ignore
                return;
            }
        }
    }
}
