using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxManager : MonoBehaviour {

	public int damage;
	public int knockback;
	BoxCollider2D hb;


	void OnTrigger2DEnter(Collider2D other)
	{
		if (other.tag == "Enemy") {
			damage (other);
		}
		else if (other.tag == "Player") {
			damage (other);
		}
	}

}
