using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    //variables for player movement
    private CharacterController controller;
    private Animator pAnimator;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 2.0f;
    private float jumpHeight = 4.0f;
    private float gravityValue = 20f;
    private Vector3 direction;
    private GameObject camera;
    //private playerHealth pHealth;
    public bool stop = false;

    // Start is called before the first frame update
    void Start()
    {
        //get components for player like the CharacterController, Animator, and camera
        controller = GetComponent<CharacterController>();
        pAnimator = GetComponent<Animator>();
        camera = GameObject.Find("Camera");
        //pHealth = GetComponent<playerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!stop)
        {
            //groundedPlayer = controller.isGrounded;
            if (controller.isGrounded)
            {
                direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                direction = transform.TransformDirection(direction);
                direction *= playerSpeed;
                //running animation if character is moving
                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
                {
                    pAnimator.Play("Walk");
                    transform.rotation = Quaternion.Euler(0, camera.transform.eulerAngles.y, 0); //make character face camera angle
                }
                else
                {
                    pAnimator.Play("IdleLegs"); //idle animation
                }
                if (Input.GetButton("Jump"))
                {
                    direction.y = jumpHeight; //make character jump
                }
            }
            direction.y -= gravityValue * Time.deltaTime;
            controller.Move(direction * Time.deltaTime);
        }
    }
}
