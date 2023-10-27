using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
   

    // Start is called before the first frame update
  
    void Start()
    {
        foreach(Sound sound in sounds)
        {
            sound.source=gameObject.AddComponent<AudioSource>(); 
            sound.source.clip=sound.clip;
            sound.source.loop=sound.loop;
        }
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Game")
        {
           
            PlaySound("InGame");
        }
        else if (scene.name == "Paused")
        {
             
            PlaySound("Resume");
        }
      else if(scene.name =="Main Menu")
        {
            PlaySound("MainTheme");
        }
    }
    

    public void PlaySound(string name)
    {
        foreach (Sound sound in sounds) {
            if (sound.name == name)
                sound.source.Play();
        }
    }
    public void PauseSound(string name)
    {
        foreach(Sound sound in sounds) {
            if (sound.name == name)
                sound.source.Pause();
        }
    }
   


}
