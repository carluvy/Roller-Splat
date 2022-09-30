using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager singleton;
    private AudioSource playerAudio;
    public AudioClip  loseSound;
    public AudioClip winSound;
    public ParticleSystem winEffect;
    public TextMeshProUGUI timerText;
    public static bool gameiIsPaused;
    public Button restartButton;
    //public Button resumeButton;
    public Button pauseButton;
    public Button menuButton;
    public Button hazardButton;
    public Sprite pauseSprite;
    public Sprite playSprite;
    private int startScene = 0;


    private float gameTime;

    private GroundPiece[] allGroundPieces;
    // Start is called before the first frame update
    void Start()
    {

          gameiIsPaused = false;


        if (gameiIsPaused)
        {
            pauseButton.GetComponent<Image>().sprite = playSprite;

        }
        else
        {
            pauseButton.GetComponent<Image>().sprite = pauseSprite;
        }


        playerAudio = GetComponent<AudioSource>();
        SetupNewLevel();
        
        
        
        

    }

    private void SetupNewLevel()
    {
        allGroundPieces = FindObjectsOfType<GroundPiece>();
        
      
        gameTime = 30;
        timerText.text = "Time: " + gameTime;
        gameiIsPaused = false;
        

    }

    private void Awake()
    {
        if(singleton == null)
        {
            singleton = this;
        } else if(singleton != this)
        {
            Destroy(gameObject);
            DontDestroyOnLoad(gameObject);
            

        }
        
    }

    private void OnEnable()
    {
        
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
        



    }

    private void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        SetupNewLevel();
        

    }

    public void CheckComplete()
    {
        bool isFinished = true;
       
        //gameiIsPaused = false;


        for (int i = 0; i < allGroundPieces.Length; i++)
        {

            if (allGroundPieces[i].isColored == false)
            {
                isFinished = false;
                break;
            }
        }

        if (isFinished)
        
           /* playerAudio.PlayOneShot(winSound);
            winEffect.Play();*/



            NextLevel();
        







            

        
            

        



    }



   

    private void Update()
    {
        
        //pauseButton.gameObject.SetActive(true);
        //restartButton.gameObject.SetActive(true);
        



        gameTime -= Time.deltaTime;
        if (gameTime <= 0)
        {
            timerText.text = "Time Over!";
            playerAudio.PlayOneShot(loseSound);
            
            hazardButton.gameObject.SetActive(true);

            pauseButton.gameObject.SetActive(false);
            
            
           
          





  


        }
        else
        {
            
         
            timerText.gameObject.SetActive(true);
            timerText.text = "Time: " + Mathf.FloorToInt(gameTime % 60);
            
        }

        /*if (winEffect.time <= 1f)
        {
            playerAudio.PlayOneShot(winSound);
        }
*/
        

        







    }

    public void PauseController()
    {
        if (gameiIsPaused)
        {
            gameiIsPaused = false;
            pauseButton.GetComponent<Image>().sprite = pauseSprite;
            Time.timeScale = 1;
            AudioListener.pause = false;
            //cameraController.MusicController();



        }
        else
        {
            gameiIsPaused = true;
            pauseButton.GetComponent<Image>().sprite = playSprite;
            Time.timeScale = 0f;
            AudioListener.pause = true;
            //cameraController.MusicController();

        }

    }

    public void PauseGame()
    {
        gameiIsPaused = true;
        Time.timeScale = 0f;
        AudioListener.pause = true;
        

     }

    public void ResumeGame() 
    {
        AudioListener.pause = false;
        gameiIsPaused = false;
        
        Time.timeScale = 1;
        






    }





    public void RestartGame()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        hazardButton.gameObject.SetActive(false);
        



    }

    public void QuitGame()
    {
       
        SceneManager.LoadScene(startScene);
    }

   
    private void NextLevel()
    {
        
      



        int last_level = 6;
        int firstLevel = 1;
       if (SceneManager.GetActiveScene().buildIndex == last_level)
        {
            

            SceneManager.LoadScene(firstLevel);
            


        }
        else
       
        {
         
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            

        }

    }







}
