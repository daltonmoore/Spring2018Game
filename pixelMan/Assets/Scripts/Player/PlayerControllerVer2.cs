﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerVer2 : MonoBehaviour
{
    public Animator anim;
    public String[] animStates = new String[4];
    public static PlayerControllerVer2 playerController;

    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    String facing = "forwards";

    private void Awake()
    {
        playerController = GetComponent<PlayerControllerVer2>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start ()
    {
        try
        {
            if (anim == null)
                anim = GetComponent<Animator>();
            if (rigid == null)
                rigid = GetComponent<Rigidbody2D>();
        }
        catch(Exception e)
        {
            print(e.StackTrace);
        }
	}

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        move(x, y);
        if (!anim.GetBool("Moving"))
        {
            setSpriteFacing();
        }
    }

    void setSpriteFacing()
    {
        if (facing == "left")
        {
            anim.Play(animStates[0]);
        }
        else if (facing == "right")
        {
            anim.Play(animStates[1]);
        }
        else if (facing == "towards")
        {
            anim.Play(animStates[2]);
        }
        else if (facing == "forwards")
        {
            anim.Play(animStates[3]);
        }
    }

    void setLastDirection(float x, float y)
    {
        if (anim.GetFloat("Horizontal") > 0)
        {
            facing = "right";
        }
        else if (anim.GetFloat("Horizontal") < 0)
        {
            facing = "left";
        }
        else if(anim.GetFloat("Vertical") < 0)
        {
            facing = "towards";
        }
        else if (anim.GetFloat("Vertical") > 0)
        {
            facing = "forwards";
        }
    }

    void move(float x, float y)
    {
        anim.SetFloat("Horizontal", x);
        anim.SetFloat("Vertical", y);
        anim.SetBool("Moving", x != 0 || y != 0);

        rigid.velocity = new Vector2(x, y);

        if(x == 0 && y == 0)
        {
            rigid.velocity = Vector2.zero;
        }
        setLastDirection(x, y);
    }
}
