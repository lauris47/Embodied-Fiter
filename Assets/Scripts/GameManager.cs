using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public GameObject obstacleHolder;
    private GameObject [] obstacles;
    private int obstalceCount;
    public int obstacleTravelLength;
    public bool gameStarted = true;
    int currentObstacle;
    public float obstacleMoveSpeed = 0.01f;
    private Vector3 initialObstaclePos;
   


    void Start () {
        obstacles = new GameObject [obstacleHolder.transform.childCount];

        foreach (Transform _obstacles in obstacleHolder.GetComponent<Transform>())
        {
            obstacles[obstalceCount] = _obstacles.gameObject;
            obstacles[obstalceCount].SetActive(false);
            obstalceCount++;
            initialObstaclePos = _obstacles.transform.position;
        }
	}

    // Update is called once per frame
    void Update()
    {
        if (gameStarted && obstacles != null) { }

        ObstacleMover();
    }

    void ObstacleMover()
    {
        if (!obstacles[currentObstacle].activeSelf)
        {
            obstacles[currentObstacle].SetActive(true);
        }

        if (obstacleTravelLength > obstacles[currentObstacle].transform.position.x)
        {
            obstacles[currentObstacle].transform.position += new Vector3(obstacleMoveSpeed, 0, 0);


        }else
        {
            //GameObject tempObstacle = obstacles[obstacleHolder.transform.childCount]
            //obstacles[currentObstacle] = 
            obstacles[currentObstacle].transform.position = initialObstaclePos;
            obstacles[currentObstacle].SetActive(false);
            currentObstacle++;

        }

        if(currentObstacle >= obstacleHolder.transform.childCount)
        {
            currentObstacle = 0;
            
        }
        //if (obstacles[])
        //obstacles[]
    }
}
