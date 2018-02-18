//Tests that the player object spawns and comes to a rest
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class NewPlayModeTest {

	[UnityTest]
	public IEnumerator TestSpawn() {
        SetupScene();
       
        yield return new WaitForSeconds(5);
        if(GameObject.Find("Player(Clone)").GetComponent<Rigidbody2D>().velocity.magnitude < .0001)
        {
            yield break;     
        }
        
        Assert.Fail();

	}

    void SetupScene()
    {
        MonoBehaviour.Instantiate(Resources.Load<GameObject>("Scenery"));
        MonoBehaviour.Instantiate(Resources.Load<GameObject>("Player"));
    }
}

