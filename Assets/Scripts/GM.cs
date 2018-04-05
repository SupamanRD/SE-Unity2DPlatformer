using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour {
    [SerializeField]
    private GameObject gameOverUI;
    [SerializeField]
    private GameObject gameWinUI;

    public void GameWin()
    {
        gameWinUI.SetActive(true);
    }
    public void GameOver()
    {
        gameOverUI.SetActive(true);
    }
}
