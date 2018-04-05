using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour {

    private Text theText;
    [SerializeField]
    public GameObject gameover;
    public GM gm;

    void Start()
    {
        theText = GetComponent<Text>();
    }

    public void UpdateHealth(int health)
    {
        theText.text = "" + health;
    }

}
