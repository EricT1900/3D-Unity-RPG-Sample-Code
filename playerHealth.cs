using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    //variables for player
    public int health;
    public int maxHealth;
    public bool respawning = false;
    private playerMovement movement;
    public Vector3 respawnPoint;

    // Start is called before the first frame update
    //set starting values for player health and respawn point
    void Start()
    {
        health = 10;
        maxHealth = 100;
        movement = GetComponent<playerMovement>();
        respawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //respawn player when health has reached 0
        if(health <= 0 && respawning == false)
        {
            Debug.Log("Player died");
            StartCoroutine(respawn());
        }
    }

    //respawn player at respawn point
    IEnumerator respawn()
    {
        respawning = true;
        transform.position = respawnPoint;
        health = maxHealth;
        movement.stop = true;
        yield return new WaitForSeconds(5);
        movement.stop = false;
        respawning = false;
    }
}
