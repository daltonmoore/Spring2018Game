using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public static PlayerController singleton;

    public GameObject activeDoor, weaponColliderLeft, weaponColliderRight, weaponColliderUp, weaponColliderDown;
    public Animator anim;
    public SpriteRenderer spriteRenderer;
    public bool enteredDoor, hit;
    public string doorLoc = " ";
    public float health;
    public GameObject[] enemies;

    Rigidbody2D rigid;
    string northScene, southScene, eastScene, westScene;
    float attackTimer, speed = 2;
    bool right, attacking;
    Vector3 northPos = new Vector3(0, .5f, 0), southPos = new Vector3(0, -.5f, 0), eastPos = new Vector3(2.25f, 0, 0), westPos = new Vector3(-2.25f, 0, 0);
    Scene currentScene;
    int lastInput;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        singleton = this;
    }
    
    void Start ()
    {
        rigid = GetComponent<Rigidbody2D>();
        currentScene = SceneManager.GetActiveScene();
        setConnectedScenes();
    }

	void Update ()
    {
        if(hit)
        {
            health--;
            hit = false;
        }
        getLastInput();
        if(enteredDoor && Input.GetKeyDown(KeyCode.Q))
        {
            currentScene = SceneManager.GetActiveScene();
            StartCoroutine(doorAnim());
            currentScene = SceneManager.GetActiveScene();
            setConnectedScenes();
            enteredDoor = false;
        }
        if(attacking)
        {
            anim.SetBool("moving", false);
        }
        if(attackTimer + .75f < Time.time)
        {
            attacking = false;
        }
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        if (!attacking)
        {
            anim.SetFloat("Horizontal", x);
            anim.SetFloat("Vertical", y);
            anim.SetBool("moving", x != 0 || y != 0);
            transform.position += new Vector3(x, y, 0) * Time.deltaTime * speed;
        }

        if (x < 0)
            right = false;
        else if (x > 0)
            right = true;
            
        if(!anim.GetBool("moving") && !attacking)
        {
            if (right)
                anim.Play("idleRight");
            if (!right)
                anim.Play("idleLeft");
        }

        if(Input.GetKeyDown(KeyCode.E) && !attacking)
        {
            attackTimer = Time.time;
            attacking = true;
            if(right)
                anim.Play("rightAttack");
            if(!right)
                anim.Play("leftAttack");
        }
    }

    void getLastInput()
    {
        if (Input.GetKeyDown(KeyCode.W))
            lastInput = 0;
        else if (Input.GetKeyDown(KeyCode.S))
            lastInput = 1;
        else if (Input.GetKeyDown(KeyCode.A))
            lastInput = 2;
        else if (Input.GetKeyDown(KeyCode.D))
            lastInput = 3;
    }

    IEnumerator doorAnim ()
    {
        activeDoor.GetComponent<Animator>().Play("doorOpening");
        yield return new WaitForSeconds(1);
        setConnectedScenes();
        if (doorLoc == "NORTH")
        {
            SceneManager.LoadSceneAsync(northScene);
            transform.position = southPos;
        }
        else if (doorLoc == "SOUTH")
        {
            SceneManager.LoadScene(southScene);
            transform.position = northPos;
        }
        else if (doorLoc == "EAST")
        {
            SceneManager.LoadScene(eastScene);
            transform.position = westPos;
        }
        else if (doorLoc == "WEST")
        {
            SceneManager.LoadScene(westScene);
            transform.position = eastPos;
        }
    }

    void setConnectedScenes()
    {
        switch (currentScene.name)
        {
            case "homeScene":
                northScene = "scene1";
                southScene = null;
                eastScene = null;
                westScene = null;
                break;
            case "scene1":
                northScene = null;
                southScene = "homeSceneCopy";
                eastScene = null;
                westScene = null;
                break;
            case "homeSceneCopy":
                northScene = "scene1";
                southScene = null;
                eastScene = null;
                westScene = null;
                break;
        }
    }

    void OpenDamageCollider()
    {
        switch (lastInput)
        {
            case 0:
                weaponColliderUp.SetActive(true);
                break;
            case 1:
                weaponColliderDown.SetActive(true);
                break;
            case 2:
                weaponColliderLeft.SetActive(true);
                break;
            case 3:
                weaponColliderRight.SetActive(true);
                break;
        }
        StartCoroutine("AttackClose");
    }

    IEnumerator AttackClose()
    {
        yield return new WaitForSeconds(.2f);
        weaponColliderUp.SetActive(false);
        weaponColliderDown.SetActive(false);
        weaponColliderLeft.SetActive(false);
        weaponColliderRight.SetActive(false);
    }

    public void enemyHit(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                if (enemies[i].name == collision.name)
                {
                    var e = enemies[i].GetComponent<SlimeController>();
                    if (e != null)
                    {
                        e.health--;
                    }
                }
            }
        }
    }
}
