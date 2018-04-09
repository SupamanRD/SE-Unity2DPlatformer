//Implemented by Cameron and Rutherford//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    [SerializeField]
    public GameObject lsui;

    public void PlayGame() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);


    }

    public void LevelTwo()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);

    }

    public void LevelThree()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);

    }

    public void LevelFour()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);

    }

    public void Back()
    {
       lsui.SetActive(false);
    }

    public void LevelSelect()
    {
       lsui.SetActive(true);
    }
    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();

    }

}
