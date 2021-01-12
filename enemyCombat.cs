using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyCombat : MonoBehaviour
{
    public GameObject player;
    public Animator npcAnimator;
    private float distance;
    bool hit = false;
    bool attacking = false;
    // Start is called before the first frame update
    void Start()
    {
        //find where player is
        player = GameObject.Find("Player");
        npcAnimator = transform.parent.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //attack the player when close
        distance = Vector3.Distance(player.transform.position, transform.position);
        if(distance < 1.5 && attacking == false)
        {
            StartCoroutine(attackAnimation());
        }
    }

    //play attack animation
    IEnumerator attackAnimation()
    {
        hit = false;
        attacking = true;
        npcAnimator.Play("Attack1");
        yield return new WaitForSeconds(1);
        attacking = false;
    }

    public void OnTriggerEnter(Collider target)
    {
        //Debug.Log("triggered" + gameObject.tag);
        //subtract player health when hit
        if (target.gameObject.tag == "Player" && attacking == true && hit == false)
        {
            target.GetComponent<playerHealth>().health -= 2;
            hit = true;

        }
    }
}
