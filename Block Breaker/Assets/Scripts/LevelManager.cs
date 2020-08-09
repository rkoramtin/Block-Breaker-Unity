using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void LoadLevel (string name)
	{
	Debug.Log("level load requestet for:"+name);
	SceneManager.LoadScene(name);
	}
	public void OuitRequest ()
	{
	Debug.Log("I wanna QUIT!");
	Application.Quit();
	}
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1 ); 
    }
    public void BrickDestroyed()
    {
        if (Bricks.breakableCount<=0)
        {
            //load Win Video Here
            LoadNextLevel();
        }
    }
}
