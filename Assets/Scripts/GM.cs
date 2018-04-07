using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour {
    [SerializeField]
    private GameObject gameOverUI;
    [SerializeField]
    private GameObject gameWinUI;
    [SerializeField]
    private PlayerMovement player;
    

    public void GameWin()
    {
        gameWinUI.SetActive(true);
    }
    public void GameOver()
    {
        DestroyObject(player);
        gameOverUI.SetActive(true);
    }
    public void KillEnemy(Enemy enemy)
    {
        Debug.Log("Enemy should die");
        DestroyObject(enemy);
    }
    //used to stall the hurtbox activation so that the player doesn't take continuous damage each frame
    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
    }
   public IEnumerator WaitForEnemyDam()
    {
        yield return new WaitForSeconds((float).75);
    }
    public IEnumerator WaitForAttack()
    {
        yield return new WaitForSeconds((float).75);
    }
}
