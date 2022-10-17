using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * script for all menu buttons
 * planning on webgl so don't need quit button in menu
 * 
 */

public class MenuButtons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startButton()
    {
        //start the player from the beginning of the game
        SceneManager.LoadScene(1);
        Debug.Log("loaded scene: " + SceneManager.GetSceneAt(1).name);


        //note: reset all player prefs
    }

    public void loadButton()
    {
        //get popup, load if load button is then pressed
        Debug.Log("load pressed");


    }

}
