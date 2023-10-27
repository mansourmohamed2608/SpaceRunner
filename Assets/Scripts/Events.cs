using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Events : MonoBehaviour
{
   public GameObject isMute;
   public GameObject mainMenu;
   public GameObject options;
   public GameObject credits;
   public GameObject howToPlay;

    public void Start()
    {
         
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
         FindObjectOfType<AudioManager>().PlaySound("InGame");
    }
    
    public void Menu()
    {
       
        SceneManager.LoadScene("Main Menu");
       
    }
     public void HowToPlay()
    {

        howToPlay.SetActive(true);
        mainMenu.SetActive(false);
        options.SetActive(false);
        credits.SetActive(false);
    }
    
    public void MuteSound()
    {
        AudioListener.volume = 0;
        isMute.SetActive(true);
    }
    public void UnMuteSound()
    {
        AudioListener.volume = 1;
        isMute.SetActive(false);
    }
    public void Options()
    {

        options.SetActive(true);
        howToPlay.SetActive(false);
        mainMenu.SetActive(false);
        credits.SetActive(false);
    }
    public void Credits()
    {
        credits.SetActive(true);
        options.SetActive(false);
        howToPlay.SetActive(false);
        mainMenu.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Resume()
    {
        Time.timeScale = 1;
        PlayerManager.isPaused = false;
    }
    
  
}
