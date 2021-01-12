using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    //variables for enemy health
    public int health;
    public int maxHealth;
    public bool respawning = false;
    public enemyMovement movement;
    public Vector3 respawnPoint;
    // Start is called before the first frame update
    //set start values for enemy health and respawn point
    void Start()
    {
        health = 10;
        maxHealth = 10;
        movement = GetComponent<enemyMovement>();
        respawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //respawn enemy when health reaches 0
        if (health <= 0 && respawning == false)
        {
            Debug.Log("Goblin died");
            StartCoroutine(respawn());
        }
    }

    //respawn enemy at respawn point
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
