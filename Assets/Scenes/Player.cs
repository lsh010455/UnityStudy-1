using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody playerRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float xinput = Input.GetAxis("Horizontal");
        float zinput = Input.GetAxis("Vertical");

        float xSpeed = xinput * speed;
        float zSpeed = zinput * speed;

        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        playerRigidbody.velocity = newVelocity;
        //if(Input.GetKey(KeyCode.UpArrow))
        //{
        //    //transform.Translate(0f, 0f, speed * Time.deltaTime);
        //    playerRigidbody.AddForce(0f, 0f, speed);
        //}
        //if (Input.GetKey(KeyCode.DownArrow))
        //{
        //    //transform.Translate(0f, 0f, -speed * Time.deltaTime);
        //    playerRigidbody.AddForce(0f, 0f, -speed);
        //}
        //if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    //transform.Translate(speed * Time.deltaTime, 0f, 0f);
        //    playerRigidbody.AddForce(speed, 0f, 0f);
        //}
        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    //transform.Translate(-speed * Time.deltaTime, 0f, 0f);
        //    playerRigidbody.AddForce(-speed, 0f, 0f);
        //}
    }
    public void Die()
    {
        gameObject.SetActive(false);
        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.EndGame();
    }
}
