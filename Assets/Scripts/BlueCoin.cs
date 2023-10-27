using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueCoin : MonoBehaviour
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
        if (other.tag == "Player"  && PlayerManager.form == "white")
        {
            if (PlayerManager.BlueEnergyPoints < 5)
            {
                PlayerManager.BlueEnergyPoints += 1;
            }
            PlayerManager.Score += 1;
            Destroy(gameObject);

        }
        if (other.tag == "Player" && PlayerManager.form == "green" && PlayerManager.Orb == 1)
        {
            PlayerManager.Score += 10;
            if (PlayerManager.BlueEnergyPoints <= 3)
            {
                PlayerManager.BlueEnergyPoints += 2;
            }
            PlayerManager.Orb = 0;
            Destroy(gameObject);
           
            if (PlayerManager.GreenEnergyPoints == 0)
            {
                PlayerManager.form = "white";
            }


        }
        else if (other.tag == "Player" && PlayerManager.form == "green" && PlayerManager.Orb == 0)
        {
            PlayerManager.Score += 2;
            if (PlayerManager.BlueEnergyPoints < 5)
            {
                PlayerManager.BlueEnergyPoints += 1;


            }
            Destroy(gameObject);
           
        }
        else if (other.tag == "Player" && PlayerManager.form == "red")
        {
            PlayerManager.Score += 2;
            if (PlayerManager.BlueEnergyPoints < 5)
            {
                PlayerManager.BlueEnergyPoints += 1;
            }
            Destroy(gameObject);
            
        }
        else if (other.tag == "Player" && PlayerManager.form == "blue")
        {
            PlayerManager.Score += 2;
            Destroy(gameObject);
            
        }

        FindObjectOfType<AudioManager>().PlaySound("PickUpStars");




    }

}
