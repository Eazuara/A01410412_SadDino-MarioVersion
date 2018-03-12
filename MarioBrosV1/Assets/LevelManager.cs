using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    public void LoadLevel(string name)
    {
       
        //Debug.Log ("New Level load: " + name);
        //	Application.LoadLevel (name);    -- This method was deprecated a long time ago
        SceneManager.LoadScene(name);
    }

    public void EndGame()
    {
        Debug.Log("Quit requested");
        Application.Quit();
    }

    //  We added these functions to our previous LevelManager script.
    public void LoadNextLevel()
    {
        

        //  Load the next scene in the build order
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

   

}