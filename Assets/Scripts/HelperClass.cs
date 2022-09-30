using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HelperClass : MonoBehaviour
{
   //public Button restartButton;
    public void RestartGame()
    {
        //restartButton.gameObject.SetActive(true);
        GameManager.singleton.RestartGame();
    }

    public void QuitGame()
    {
        GameManager.singleton.QuitGame();
    }

    public void PauseGame()
    {
        
        GameManager.singleton.PauseController();
    }

    public void ResumeGame()
    {
        GameManager.singleton.ResumeGame();
    }

    
    

   
   
}
