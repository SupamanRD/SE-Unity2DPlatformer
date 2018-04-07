using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour {

    private Text theText;
    [SerializeField]
    public GameObject gameover;
    public GM gm;
    public PlayerMovement player;

    void Start()
    {
        theText = GetComponent<Text>();
    }

    public void UpdateHealth()
    {
        Debug.Log("Updating health");
        theText.text = "" + player.health;
    }

}
