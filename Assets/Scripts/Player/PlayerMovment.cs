using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{

    //private CharacterController controller;
    public Rigidbody rb;
   // public GameObject des;
    //private Vector3 playerVelocity;
    //private bool groundedPlayer;
    private float playerSpeed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        //controller = gameObject.GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        float y = Input.GetAxis("Jump");
        Vector3 movement = new Vector3(x, y * playerSpeed, z);
        rb.transform.Translate(movement * Time.deltaTime * playerSpeed);


    }
  /*  private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Destroy"))
        {
            Destroy(gameObject);

        }

    }*/
}