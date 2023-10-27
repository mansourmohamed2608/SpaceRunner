using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class RedCoin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 50 * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && PlayerManager.form == "white")
        {
            PlayerManager.Score += 1;
            if (PlayerManager.RedEnergyPoints < 5)
            {
                PlayerManager.RedEnergyPoints += 1;
            }
            Destroy(gameObject);

        }

        if (other.tag == "Player" && PlayerManager.form == "green" && PlayerManager.Orb == 1)
        {
            PlayerManager.Score += 10;
            if (PlayerManager.RedEnergyPoints <= 3)
            {
                PlayerManager.RedEnergyPoints += 2;
            }
            PlayerManager.Orb = 0;
            Destroy(gameObject);
            FindObjectOfType<AudioManager>().PlaySound("PickUpStars");
            if (PlayerManager.GreenEnergyPoints == 0)
            {
                PlayerManager.form = "white";
            }


        }
        else if (other.tag == "Player" && PlayerManager.form == "green" && PlayerManager.Orb == 0)
        {
            PlayerManager.Score += 2;
            if (PlayerManager.RedEnergyPoints < 5)
            {
                PlayerManager.RedEnergyPoints += 1;
                

            }
            Destroy(gameObject);
            FindObjectOfType<AudioManager>().PlaySound("PickUpStars");
        }
        else if (other.tag == "Player" && PlayerManager.form == "blue")
        {
            PlayerManager.Score += 2;
            if (PlayerManager.RedEnergyPoints < 5)
            {
                PlayerManager.RedEnergyPoints += 1;
            }
            Destroy(gameObject);
            FindObjectOfType<AudioManager>().PlaySound("PickUpStars");
        }
        else if (other.tag == "Player" && PlayerManager.form == "red")
        {
            PlayerManager.Score += 2;
            Destroy(gameObject);
            FindObjectOfType<AudioManager>().PlaySound("PickUpStars");
        }

        FindObjectOfType<AudioManager>().PlaySound("PickUpStars");

    }

}
