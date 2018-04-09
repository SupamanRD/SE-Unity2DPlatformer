using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSUI : MonoBehaviour {

    [SerializeField]
    public MainMenu mm;
	public void LevelOne()
    {
        mm.PlayGame();
    }
    public void LevelTwo()
    {
        mm.LevelTwo();
    }
    public void LevelThree()
    {
        mm.LevelThree();
    }
    public void Back()
    {
        mm.Back();
    }
}
