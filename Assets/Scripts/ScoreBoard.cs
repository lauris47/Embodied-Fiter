using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour {
    public bool opponentBoard;
    public Vector3 numberspositionOffset;
    public GameObject[] numbers;
    public Transform [] numberSlots;
    private GameObject[] numberObjects;
    public Quaternion numRot = new Quaternion(0,0,0,0);
    int scoreInt ;


	// Use this for initialization
    public int playerScore = 0;
	void Start () {
        //Rotate numbers
        if (!opponentBoard)
        {
            numRot = new Quaternion(0, 0.7071f, 0, 0.7071f);
        }
        else
        {
            numRot = new Quaternion(0, -0.7071068f, 0, 0.7071068f);
        }
        for (int i = 0; i < numberSlots.Length; i++)
        {
            numberSlots[i].GetComponent<MeshRenderer>().enabled = false;
        }

        numberObjects = new GameObject[3];
        ChangeScore(0);


    }
	
	// Update is called once per frame
	void FixedUpdate () { 
        //if(numberObjects[0] !=null)
        //numRot = numberObjects[0].transform.rotation;
    }

    public void ChangeScore(int _score)
    {
        if(playerScore < 10)
        {
            Destroy(numberObjects[0]);
            numberObjects[0] = GameObject.Instantiate(numbers[playerScore], numberSlots[0].position, numRot);
            numberObjects[0].transform.parent = transform;


        }
        else if (playerScore > 9 && playerScore < 100)
        {
            for(int i = 0; i < 2; i++)
            {
                Destroy(numberObjects[i]);
                if(i == 0)
                {
                    scoreInt = int.Parse(playerScore.ToString().Substring(0, 1));
                }
                else
                {
                    scoreInt = int.Parse(playerScore.ToString().Substring(i));
                }
                //Debug.Log(scoreInt);
                numberObjects[i] = GameObject.Instantiate(numbers[scoreInt], numberSlots[i + 1].position, numRot);
                numberObjects[i].transform.parent = transform;
            }
        }
        playerScore += 1;
    }
}
