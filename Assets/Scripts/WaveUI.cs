using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveUI : MonoBehaviour {

    private Text text;
    

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
	}

    public void UpdateWave(int wave)
    {
        text.text = "" + wave;
    }
}
