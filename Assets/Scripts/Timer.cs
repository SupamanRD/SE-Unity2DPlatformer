using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public float startTime;
	private Text theText;
	//public GameObject gameOverScreen;
	public PlayerMovement player;


	int countDownSeconds;


	void Start(){
		theText = GetComponent<Text>();
		player = FindObjectOfType<PlayerMovement>();
	}

	void Update(){
		startTime -= Time.deltaTime;
		if (startTime <= 0) {
			//gameOverScreen.SetActive (true);
			player.gameObject.SetActive(false);
		}
		theText.text = "" + Mathf.Round(startTime);
	}

}