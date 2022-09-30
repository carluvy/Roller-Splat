using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{

    public Button musicButton;
    public Sprite musicOnSprite;
    public Sprite musicOffSprite;

   

    public void MusicController()
    {
        if (AudioListener.pause == true)
        {
            AudioListener.pause = false;
            musicButton.GetComponent<Image>().sprite = musicOnSprite;

        }
        else
        {
            AudioListener.pause = true;
            musicButton.GetComponent<Image>().sprite = musicOffSprite;
        }

    }
    
    // Start is called before the first frame update
    void Start()
    {
        if (AudioListener.pause == true)
        {
            musicButton.GetComponent<Image>().sprite = musicOffSprite;

        }
        else
        {
            musicButton.GetComponent<Image>().sprite = musicOnSprite;
        }
    }

    // Update is called once per frame
    void Update()
    {

        
        
    }
}
