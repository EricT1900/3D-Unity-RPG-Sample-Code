using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firstSword : MonoBehaviour
{
    //variables for player
    public GameObject player;
    public Animator pAnimator;
    bool attacking = false;
    bool hit = false;
    // Start is called before the first frame update
    //get components for player
    void Start()
    {
        player = GameObject.Find("Player");
        pAnimator = player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //make player attack when mouse is clicked
        if (attacking == false && Input.GetMouseButtonDown(0))
        {
            
            StartCoroutine(attackAnimation());
            //Debug.Log("ok");
        }
    }

    //run attack animation
    IEnumerator attackAnimation()
    {
        //GetComponent<Animator>().Play("Attack1");
        hit = false;
        attacking = true;
        //pAnimator.SetLayerWeight(1, 1f);
        pAnimator.Play("Attack1");
        yield return new WaitForSeconds(1);
        attacking = false;
        //pAnimator.SetLayerWeight(1, 0f);
    }

    //remove hp from enemy when hit
    public void OnTriggerEnter(Collider target)
    {
        //Debug.Log("attacl" + attacking);
        //Debug.Log("hit" + hit);
        //Debug.Log(target.gameObject.tag);
        if (target.gameObject.tag == "Enemy" && attacking == true  && hit == false)
        {
            Debug.Log(attacking);
            target.GetComponent<enemyHealth>().health -= 3;
            hit = true;
            
        }
    }
}
