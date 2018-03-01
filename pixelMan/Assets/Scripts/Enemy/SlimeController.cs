using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : MonoBehaviour
{
    public GameObject slimeBallPrefab;
    public float health;

    Animator anim;
    GameObject player;
    float speed = 0.8f, shootDelay;
    bool inRange;
    
	void Start ()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	void Update ()
    {
        if (!inRange)
        {
            anim.Play("slimeMove");
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
        else if(shootDelay + .3f < Time.time)
        {
            shootDelay = Time.time;
            var slimeBall = Instantiate(slimeBallPrefab, transform.position, transform.rotation);
            slimeBall.GetComponent<Rigidbody2D>().velocity = (player.transform.position - transform.position).normalized * .6f;
            Destroy(slimeBall, 2);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            inRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            inRange = false;
    }
}
