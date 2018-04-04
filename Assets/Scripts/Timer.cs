using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public float startTime;
	private Text theText;
	public PlayerMovement player;
    [SerializeField]
    public GameObject gameover;
    public GM gm;


	int countDownSeconds;


	void Start(){
		theText = GetComponent<Text>();
		player = FindObjectOfType<PlayerMovement>();
	}

	void Update(){
		startTime -= Time.deltaTime;
		if (startTime <= 0) {
            gm.GameOver();
			player.gameObject.SetActive(false);
		}
		theText.text = "" + Mathf.Round(startTime);
	}

}