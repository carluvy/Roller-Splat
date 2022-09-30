using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    
    private GameObject pauseMenu;
    public Button playButton;
    public Button exitButton;
    private int startScene = 0;



    public void QuitGame()
    {

        //SceneManager.LoadScene(startScene);
        Application.Quit();
    }
    // Update is called once per frame
    
    public void LoadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
