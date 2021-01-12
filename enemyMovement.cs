using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    //variables for enemy
    private CharacterController controller;
    private Animator npcAnimator;
    private GameObject player;
    private bool groundedEnemy;
    private float speed = 1f;
    private float gravityValue = 20f;
    private Vector3 direction;
    private float distance;
    //private enemyHealth npcHealth;
    public bool stop = false;
    // Start is called before the first frame update
    //get components for npc and player
    void Start()
    {
        controller = GetComponent<CharacterController>();
        player = GameObject.Find("Player");
        npcAnimator = GetComponent<Animator>();
        //npcHealth = GetComponent<enemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        //get distance from player
        distance = Vector3.Distance(player.transform.position, transform.position);
        //move npc towards player when distance is less than 6f
        if (distance < 6f && stop == false) {
            transform.LookAt(player.transform);
            transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);
            //groundedPlayer = controller.isGrounded;
            if (controller.isGrounded)
            {
                direction = Vector3.forward;
                direction = transform.TransformDirection(direction);
                direction *= speed;
            }
            direction.y -= gravityValue * Time.deltaTime;
            controller.Move(direction * Time.deltaTime);
            npcAnimator.Play("Walk"); //play animation
        }
        else
        {
            npcAnimator.Play("IdleLegs"); //idle animation for when not moving
        }
        
    }
}
