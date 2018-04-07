using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHurtboxManager : MonoBehaviour {

    [SerializeField]
    public Enemy enemy;   


    void OnTrigger2DEnter(Collider2D other)
    {

        if (other.tag == "PlayerAttack")
        {
            Debug.Log("Enemy hit by attack");
           enemy.TakeDamage();
        }
        
        else if (other.tag == "Enemy")
        {
            //ignore
            return;
        }

    }
}
