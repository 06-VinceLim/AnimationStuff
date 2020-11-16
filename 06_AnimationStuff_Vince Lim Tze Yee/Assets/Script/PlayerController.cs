using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    float movementspeed = 5.0f;
    float Jump = 5.0f;
    bool InAir;
    float Health = 10.0f;
    bool DeathState;

    public GameObject HealthText;
    //public declartion for rigidbody
    public Rigidbody playerRb;
    //public declartion for animator
    public Animator PlayerAnimator;

    // Start is called before the first frame update
    void Start()
    {


        HealthText.GetComponent<Text>().text = "Start Function";

        //For private declartion
        //playerRb = GetComponent<Rigidbody>();
        //private declartion animator
        //PlayerAnimator = GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) && DeathState == false) //go forward and face forward
        {
            transform.Translate(Vector3.forward * Time.deltaTime * movementspeed);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetKey(KeyCode.S) && DeathState == false) //go backwards and face backwards
        {
            transform.Translate(Vector3.forward * Time.deltaTime * movementspeed);
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (Input.GetKey(KeyCode.A) && DeathState == false) //go left and face left
        {
            transform.Translate(Vector3.forward * Time.deltaTime * movementspeed);
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        if (Input.GetKey(KeyCode.D) && DeathState == false) //go right and face right
        {
            transform.Translate(Vector3.forward * Time.deltaTime * movementspeed);
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }

        if (Input.GetKey(KeyCode.W) && DeathState == false || Input.GetKey(KeyCode.S) && DeathState == false || Input.GetKey(KeyCode.A) && DeathState == false || Input.GetKey(KeyCode.D) && DeathState == false)
        {
            PlayerAnimator.SetBool("MoveState", true);
        }
        else
        {
            PlayerAnimator.SetBool("MoveState", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && InAir == false && DeathState == false)
        {
            playerRb.AddForce(Vector3.up * Jump, ForceMode.Impulse);

            PlayerAnimator.SetTrigger("JumpState");

            InAir = true;
        }

        if(Input.GetKeyDown(KeyCode.K) && DeathState == false)
        {
            --Health;
            Debug.Log("Health : " + Health);
        }

        if (Health <= 0 && DeathState == false)
        {
            DeathState = true;
            PlayerAnimator.SetTrigger("TriggerDeath");
        }

        HealthText.GetComponent<Text>().text = "Health : " + Health.ToString();

        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            InAir = false;
        }
    }
}
