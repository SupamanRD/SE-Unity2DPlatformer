using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour {

    private Vector2 startPos;
    private Vector2 posA;
    private Vector2 posB;
    private Vector2 nextPos;
    [SerializeField]
    private Transform childTransform;
    [SerializeField]
    private Transform transformB;
    [SerializeField]
    private Transform transformA;
    [SerializeField]
    private float speed;
	// Use this for initialization
	void Start () {
        startPos = transform.position;
        posB = transformB.localPosition;
        posA = transformA.localPosition;
        nextPos = posA;
	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    private void Move()
    {
        if(Vector2.Distance(childTransform.localPosition,nextPos)<=0.1)
        {
            ChangeDestination();
        }
        childTransform.localPosition = Vector2.MoveTowards(childTransform.localPosition, nextPos, speed * Time.deltaTime);
    }

    private void ChangeDestination()
    {
        nextPos = nextPos != posA ? posA : posB;
    }
}
