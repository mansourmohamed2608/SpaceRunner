using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;
    private Vector3 direction;
    public float forwardSpeed;
    private int desiredLane = 1;
    public float laneDistance = 10;
    public bool isInvincibility=false;
    public float maxSpeed;
    // Start is called before the first frame update
    void Start()
    {
       
        characterController = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerManager.isGameStarted)
        {
            return;
        }
        if (forwardSpeed < maxSpeed)
        {
            forwardSpeed += 0.1f * Time.deltaTime;
        }
        direction.z = forwardSpeed;
        Scene scene= SceneManager.GetActiveScene();
        Debug.Log(scene.name);
        
        if (Input.GetKeyDown(KeyCode.Escape) && scene.name=="Game" && !PlayerManager.isPaused)
        {
            
            PlayerManager.isPaused=true;
            FindObjectOfType<AudioManager>().PauseSound("InGame");
            FindObjectOfType<AudioManager>().PlaySound("Pause");
            Time.timeScale = 0;
        }
       else if (Input.GetKeyDown(KeyCode.Escape) && scene.name == "Game" && PlayerManager.isPaused)
        {
           
            PlayerManager.isPaused = false;
            FindObjectOfType<AudioManager>().PauseSound("Pause");
            FindObjectOfType<AudioManager>().PlaySound("InGame");
            Time.timeScale = 1;

        }
       
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            desiredLane++;
            if (desiredLane == 3) {
                desiredLane = 2;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            desiredLane--;
            if (desiredLane == -1)
            {
                desiredLane = 0;
            }
            
        }
        if (Input.GetKeyDown(KeyCode.J) && PlayerManager.RedEnergyPoints == 5)
        {
            FindObjectOfType<AudioManager>().PlaySound("Transform");
            PlayerManager.form=("red");
            PlayerManager.isShield = false;
            PlayerManager.RedEnergyPoints--;
           


        }
        else if(Input.GetKeyDown(KeyCode.J) && PlayerManager.RedEnergyPoints< 5)
        {
            FindObjectOfType<AudioManager>().PlaySound("Error");
        }
        if (Input.GetKeyDown(KeyCode.K) && PlayerManager.GreenEnergyPoints == 5)
        {
            FindObjectOfType<AudioManager>().PlaySound("Transform");
            PlayerManager.form=("green");
            PlayerManager.GreenEnergyPoints--;
            PlayerManager.isShield = false;
            

        }
        else if(Input.GetKeyDown(KeyCode.K) && PlayerManager.GreenEnergyPoints< 5)
        {
            FindObjectOfType<AudioManager>().PlaySound("Error");
        }
        if (Input.GetKeyDown(KeyCode.L) && PlayerManager.BlueEnergyPoints == 5)
        {
            FindObjectOfType<AudioManager>().PlaySound("Transform");
            PlayerManager.form=("blue");
            PlayerManager.BlueEnergyPoints--;
            

        }
        else if( Input.GetKeyDown(KeyCode.L) && PlayerManager.RedEnergyPoints < 5)
        {
            FindObjectOfType<AudioManager>().PlaySound("Error");
        }
        if (Input.GetKeyDown(KeyCode.I) && PlayerManager.RedEnergyPoints<5)
        {
            PlayerManager.RedEnergyPoints++;
        }
        if (Input.GetKeyDown(KeyCode.O) && PlayerManager.GreenEnergyPoints<5)
        {
            PlayerManager.GreenEnergyPoints++;
        }
        if (Input.GetKeyDown(KeyCode.P) && PlayerManager.BlueEnergyPoints<5)
        {
            PlayerManager.BlueEnergyPoints++;
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            isInvincibility = true;
        }
        if (Input.GetKeyDown(KeyCode.Space) && PlayerManager.Orb == 0 && PlayerManager.form=="green")
        {
            if (PlayerManager.GreenEnergyPoints == 0 && PlayerManager.Orb == 0)
            {
                
                PlayerManager.form = "white";
                return;
            }
            PlayerManager.GreenEnergyPoints--;
            PlayerManager.Orb++;
            FindObjectOfType<AudioManager>().PlaySound("PowerUp");
        }
        if (Input.GetKeyDown(KeyCode.Space) && PlayerManager.form == "blue" && !PlayerManager.isShield)
        {
            if (PlayerManager.BlueEnergyPoints == 0)
            {
                PlayerManager.form = "white";
                return;
            }
            PlayerManager.BlueEnergyPoints--;
            PlayerManager.isShield=true;
            FindObjectOfType<AudioManager>().PlaySound("PowerUp");
        }
        if (Input.GetKeyDown(KeyCode.Space) && PlayerManager.form == "red")
        {
            PlayerManager.RedEnergyPoints--;
            FindObjectOfType<AudioManager>().PlaySound("PowerUp");

            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Obstacle");
            foreach (GameObject target in gameObjects)
            {
                Destroy(target);
            }
            if (PlayerManager.RedEnergyPoints == 0)
            {
                PlayerManager.form = "white";
                return;
            }
           


        }
        if(Input.GetKeyDown(KeyCode.Space) && PlayerManager.form == "white")
        {
            FindObjectOfType<AudioManager>().PlaySound("Error");
        }
        if (SwipeManager.swipeRight)
        {
            desiredLane++;
            if (desiredLane == 3)
                desiredLane = 2;
        }
        if (SwipeManager.swipeLeft)
        {
            desiredLane--;
            if (desiredLane == -1)
                desiredLane = 0;
        }
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;

        }
        else if (desiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }
        if (transform.position != targetPosition)
        {
            Vector3 diff = targetPosition - transform.position;
            Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;
            if (moveDir.sqrMagnitude < diff.sqrMagnitude)
            {
                characterController.Move(moveDir);

            }
            else
            {
                characterController.Move(diff);
            }
        }
        characterController.Move(direction * Time.deltaTime);
    } 
   
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "Obstacle" && PlayerManager.form.Equals("white") && !isInvincibility)
        {
            PlayerManager.gameOver = true;
            FindObjectOfType<AudioManager>().PlaySound("Crash");
            FindObjectOfType<AudioManager>().PauseSound("InGame");
            FindObjectOfType<AudioManager>().PlaySound("GameOver");
        }
        if (hit.transform.tag == "Obstacle" && PlayerManager.form.Equals("red"))
        {
            FindObjectOfType<AudioManager>().PlaySound("Transform");

            Destroy(hit.gameObject);
            PlayerManager.form = "white";
        }
        if (hit.transform.tag == "Obstacle" && PlayerManager.form.Equals("green"))
        {
            FindObjectOfType<AudioManager>().PlaySound("Transform");

            Destroy(hit.gameObject);
            PlayerManager.form = "white";

        }
        if (hit.transform.tag == "Obstacle" && PlayerManager.form.Equals("blue") && PlayerManager.isShield)
        {
            PlayerManager.isShield = false;
            if (PlayerManager.BlueEnergyPoints == 0)
            {
                PlayerManager.form = "white";
            }
            Destroy(hit.gameObject);
            FindObjectOfType<AudioManager>().PlaySound("Error");

        }
        else if (hit.transform.tag == "Obstacle" && PlayerManager.form.Equals("blue") && !PlayerManager.isShield)
        {

            FindObjectOfType<AudioManager>().PlaySound("Transform");

            Destroy(hit.gameObject);
            PlayerManager.form = "white";

        }

    }
  

}
