using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterMover : MonoBehaviour {
    public float sideSwingDistance;
    private Vector3 initialPosition;
    public float movingSpeed;
    bool movingLeft = true, movingRight;
    // Use this for initialization
    Vector3 positionRight, positionLeft;


	void Start () {
        initialPosition = transform.position;
        positionRight = initialPosition - new Vector3(0, 0, sideSwingDistance);
        positionLeft = initialPosition + new Vector3(0, 0, sideSwingDistance);
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if (Vector3.Distance(initialPosition, transform.position) < sideSwingDistance && movingLeft)
        {
            transform.position = Vector3.Slerp(transform.position, positionLeft + new Vector3(0, 0, sideSwingDistance / 10), movingSpeed);
            movingLeft = true;
            movingRight = false;
        }
        else
        {
            movingLeft = false;
            movingRight = true;
        }

        if (movingRight)
        {
            transform.position = Vector3.Slerp(transform.position, positionRight - new Vector3(0, 0, sideSwingDistance / 10), movingSpeed);
            if (Vector3.Distance(transform.position, positionRight) < sideSwingDistance / 10)
            {
                movingLeft = true;
                movingRight = false;
            }
        }
    }
}
