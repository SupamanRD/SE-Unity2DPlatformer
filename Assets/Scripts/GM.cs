using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour {
    [SerializeField]
    private GameObject gameOverUI;

    public void GameOver()
    {
        gameOverUI.SetActive(true);
    }
}
