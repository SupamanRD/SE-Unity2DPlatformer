using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurtBoxManager : MonoBehaviour {

    public PlayerMovement player;

    void OnTrigger2DEnter(Collider2D other)
    {
       
            if (other.tag == "Enemy")
            {
            Debug.Log("Player touched enemy");
                player.TakeDamage();
            }
            else if (other.tag == "Player")
            {
                //ignore
                return;
            }
        
    }
}
