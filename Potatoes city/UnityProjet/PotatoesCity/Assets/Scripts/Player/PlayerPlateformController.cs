﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlateformController :  PhysicsObject{

    public float jumpTakeOffSpeed = 7;
    public float maxSpeed = 7;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown ("Jump") && grounded)
        {
            velocity.y = jumpTakeOffSpeed;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            if (velocity.y > 0)
            {
                velocity.y = velocity.y * .5f;
            }
            targetVelocity = move * maxSpeed;
        }
    }
}
 