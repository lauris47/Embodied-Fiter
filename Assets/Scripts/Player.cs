using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private string obstacle = "Obstacle";
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Collided");
        if (collision.gameObject.tag == obstacle)
        {
            Debug.Log("Collided");
        }
    }
}
