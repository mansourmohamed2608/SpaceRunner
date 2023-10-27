using Cinemachine;
using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool gameOver;
    public GameObject Player;
    public GameObject PlayerTrail;
    public GameObject gameOverPanel;
    public GameObject shield;
    public  GameObject pause;
    public static bool isPaused;
    public static bool isShield;
    public static bool isGameStarted;
    public static int Score;
    public TMP_Text scoreText;
    public TMP_Text scoreText1;
    public static int RedEnergyPoints;
    public TMP_Text RedEnergyPointsText;
    public static int GreenEnergyPoints;
    public TMP_Text GreenEnergyPointsText;
    public static int BlueEnergyPoints;
    public TMP_Text BlueEnergyPointsText;
    public static string form;
    public static int Orb=0;
  
   
   



    void Start()
    {
        gameOver = false;
        Time.timeScale = 1;
        isGameStarted = false;
        Score = 0;
        BlueEnergyPoints = 0;
        GreenEnergyPoints = 0;
        RedEnergyPoints = 0;
        form = "white";
        isShield = false;
        
        isPaused = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
           
        }
        if (isPaused)
        {
            pause.SetActive(true);
        }
        else
        {
            pause.SetActive(false);
        }
        if (form == "white")
        {
            var Playerrenderer = Player.GetComponent<Renderer>();
            Playerrenderer.material.SetColor("_Color", Color.white);

            var PlayerTrailrenderer = PlayerTrail.GetComponent<Renderer>();
            PlayerTrailrenderer.material.SetColor("_TintColor", Color.white);
        }
       else if (form == "red")
        {
            var Playerrenderer = Player.GetComponent<Renderer>();
            Playerrenderer.material.SetColor("_Color", Color.red);
            var PlayerTrailrenderer = PlayerTrail.GetComponent<Renderer>();
            PlayerTrailrenderer.material.SetColor("_TintColor", Color.red);
        }
       else if (form == "green")
        {
            var Playerrenderer = Player.GetComponent<Renderer>();
            Playerrenderer.material.SetColor("_Color", Color.green);
            var PlayerTrailrenderer = PlayerTrail.GetComponent<Renderer>();
            PlayerTrailrenderer.material.SetColor("_TintColor", Color.green);
        }
      else  if (form == "blue")
        {
            var Playerrenderer = Player.GetComponent<Renderer>();
            Playerrenderer.material.SetColor("_Color", Color.blue);
            var PlayerTrailrenderer = PlayerTrail.GetComponent<Renderer>();
            PlayerTrailrenderer.material.SetColor("_TintColor", Color.blue);
        }
        if(isShield)
        {
            shield.SetActive(true);
        }
        else
        {
            shield.SetActive(false);

        }
       
        scoreText.text="Score: "+ Score;
        scoreText1.text = "Final Score: " + Score;
        RedEnergyPointsText.text = "Red Points: "+ RedEnergyPoints +"/5";
        GreenEnergyPointsText.text = "Green Points: " + GreenEnergyPoints + "/5";
        BlueEnergyPointsText.text = "Blue Points: " + BlueEnergyPoints + "/5";

    }
   
    
}
