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
    public GameObject giraffeControler, humanControler, thirdPersonCharacter, humanFirstPersonCamera;
    public int perspective = 0;

    bool firstPersonHuman, thirdPersonHuman = true, thirdPersonGiraffe;
   
    void Start () {
        obstacles = new GameObject [obstacleHolder.transform.childCount];

        foreach (Transform _obstacles in obstacleHolder.GetComponent<Transform>())
        {
            obstacles[obstalceCount] = _obstacles.gameObject;
            obstacles[obstalceCount].SetActive(false);
            obstalceCount++;
            initialObstaclePos = _obstacles.transform.position;
        }
        giraffeControler.SetActive(false);
	}

    // Update is called once per frame
    void Update()
    {
        if (gameStarted && obstacles != null) { }

        ObstacleMover();

        if (Input.GetKeyDown(KeyCode.Return))
        {
            SwitchPerspective();
        }
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
            obstacles[currentObstacle].transform.position = initialObstaclePos;
            obstacles[currentObstacle].SetActive(false);
            currentObstacle++;

        }

        if(currentObstacle >= obstacleHolder.transform.childCount)
        {
            currentObstacle = 0;
            
        }
    }

    public void SwitchPerspective()
    {
        if(perspective < 2)
        {
            perspective++;
        }
        else
        {
            perspective = 0;
        }

        //Human third person
        if (perspective == 0)
        {
            thirdPersonCharacter.SetActive(true);
            giraffeControler.SetActive(false);
            humanFirstPersonCamera.SetActive(false);
            humanControler.SetActive(true);
        }
        //Human first perspective
        if (perspective == 1)
        {
            thirdPersonCharacter.SetActive(false);
            giraffeControler.SetActive(false);
            humanControler.SetActive(true);
            humanFirstPersonCamera.SetActive(true);
        }
        //Girafee, third perspective
        if (perspective == 2)
        {
            thirdPersonCharacter.SetActive(true);
            giraffeControler.SetActive(true);
            humanControler.SetActive(false);
            humanFirstPersonCamera.SetActive(false);
        }
    }
}
