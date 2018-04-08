using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    [SerializeField]
    public int health;
    


    [SerializeField]
    private EdgeCollider2D attackCollider;
    [SerializeField]
    public bool takingdam = false;
    [SerializeField]
    private List<string> damageSources;

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (damageSources.Contains(other.tag))
        {
            takingdam = true;
            TakeDamage();
        }
    }

    public void TakeDamage()
    {
        Debug.Log("Enemy Taking Damage");
        
        health -= 1;
        if(health <= 0)
        {
            Destroy(this.gameObject);
        }
       
    }

}
