using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHurtboxManager : MonoBehaviour {

    [SerializeField]
    private Enemy enemy;

    void OnTrigger2DEnter(Collider2D other)
    {

        if (other.tag == "Player")
        {
            enemy.TakeDamage();
        }
        else if (other.tag == "Enemy")
        {
            //ignore
            return;
        }

    }
}
