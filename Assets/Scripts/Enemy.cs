using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    [SerializeField]
    public int health;
    public GM gm;
    public GameObject hurtbox;

	public void TakeDamage()
    {
        hurtbox.SetActive(false);
        health -= 1;
        if(health <= 0)
        {
            gm.KillEnemy(this);
        }
        gm.WaitForEnemyDam();
        hurtbox.SetActive(true);
    }

}
