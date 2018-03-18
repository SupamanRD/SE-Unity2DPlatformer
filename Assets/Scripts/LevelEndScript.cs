using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEndScript : MonoBehaviour {
    public string sceneName;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Scene Change triggered");
        if (other.CompareTag("Player"))
        {
            Debug.Log("It was the player!");
            SceneManager.LoadScene(sceneName);
        }
    }
    
}
