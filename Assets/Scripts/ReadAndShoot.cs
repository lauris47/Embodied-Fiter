using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadAndShoot : MonoBehaviour
{
    public TextAsset readThisFile;
    private bool stopShooting;
    string reaString;
    int initialFileLenght;
    float currentWaitTime;
    int waitTimeInc = 0;
    string[] waitTimes; // will read from text file

    // Use this for initialization
    void Start()
    {
        reaString = readThisFile.ToString();
        initialFileLenght = reaString.Length / 2;

        if (GetComponent<ShootPrefab>())
        {
            StartCoroutine(_ReadAndShoot(float.Parse(readThisFile.ToString().Substring(0, 1))));
        }
        else
        {
            Debug.Log("No ShootPrefab is attached to the game object");
        }

        waitTimes = readThisFile.ToString().Split(","[0]); // Will separate numbers, detected by commas

        for (int i = 0; i < waitTimes.Length; i ++){
            //Debug.Log(waitTimes[i]); // print all detected shooting times
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator _ReadAndShoot(float _waitTime)
    {


        yield return new WaitForSeconds(_waitTime); // will wait before shooting, even after it is called the first time

        if (!stopShooting)
        {
            GetComponent<ShootPrefab>().shootAgain = true;

            if (waitTimeInc < waitTimes.Length)
            {
                _waitTime = float.Parse(waitTimes[waitTimeInc]);
                //Debug.Log(_waitTime);
                waitTimeInc++;
            }
            else
            {
                waitTimeInc = 0;
            }

            StartCoroutine(_ReadAndShoot(_waitTime));
        }
        else
        {
            StopCoroutine(_ReadAndShoot(_waitTime));
        }
    }
}
