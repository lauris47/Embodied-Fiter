using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPrefab : MonoBehaviour
{
    private bool shotsFired;
    public Transform player;
    public GameObject[] shootThesePrefabs;
    public int _shootForce = 10;
    public int shootUpForce = 2;
    private int shootForce;
    public bool shootAgain;
    private string[] lastKnownNames;
    private bool shootReady, stopShooting;
    public int shootInterval = 1;
    private int prefabID = 0;
    public bool stopAfterAllObjectsShot;
    public bool destroyShooterAfterAllShot;
    public bool makeANewCopyOfObject;

    public bool startWhenPlayerIsCloser;
    public int startWhenPlayerIsCloserThan;

    public int stopAfterPlayerDistanceIsLessThan = 20, stopAfterPlayerDistanceIsMoreThan = 60; // will stop shooting after player is too close
    public int stopShootingAfterAmountOfPrefabs = 100;
    private int prefabsShot = 0;
    public bool _startShooting;
    private bool autoShootingStarted;
    private bool realocatingRan;

    private float lastShotTime;

    public Transform _container;
    // Use this for initialization
    void Start()
    {
        if (player == null)
        {
            player = GameObject.Find("Player").transform;
        }
        lastKnownNames = new string[shootThesePrefabs.Length];
        for (int i = 0; i < shootThesePrefabs.Length; i++)
        {
            lastKnownNames[i] = shootThesePrefabs[i].name;
        }
    }


    private void FixedUpdate()
    {
        
        //Debug.Log(Vector3.Distance(player.position, transform.position));
        if (startWhenPlayerIsCloserThan > Vector3.Distance(player.position, transform.position) && startWhenPlayerIsCloser && !autoShootingStarted)
        {
            _startShooting = true;
            autoShootingStarted = true;
        }

        if (!stopShooting && _startShooting || _startShooting)
        {
            // if objects are null (changed style)
            if (shootThesePrefabs[0] == null && !realocatingRan)
            {
                for (int i = 0; i < shootThesePrefabs.Length; i++)
                {
                    shootThesePrefabs[i] = GameObject.Find(lastKnownNames[i]);//+"(Clone)");
                }
                realocatingRan = true;
            }
            else
            {
                // Shoot automatical yafter set time
                if (lastShotTime + shootInterval < Time.time && !shootReady)
                {
                    //Debug.Log("Shoot ready " + shootReady);
                    shootReady = true;
                    //shootAgain = true;
                }

                if (_startShooting && shootReady || shootAgain)
                {
                    ShootPrefabs(shootThesePrefabs[prefabID]);

                    if (prefabID < shootThesePrefabs.Length - 1)
                    {
                        prefabID++;
                    }
                    else
                    {
                        if (stopAfterAllObjectsShot)
                        {
                            stopShooting = true;
                        }
                        if (destroyShooterAfterAllShot)
                        {
                            Destroy(transform.gameObject);
                        }
                        prefabID = 0;
                    }
                    shootReady = false;
                }
                //Stop shooting
                if (!stopShooting)
                {
                    int playerDistance = (int)Vector3.Distance(player.transform.position, transform.position);
                        if (playerDistance < stopAfterPlayerDistanceIsLessThan || playerDistance > stopAfterPlayerDistanceIsMoreThan || prefabsShot >= stopAfterPlayerDistanceIsMoreThan || prefabsShot >= stopShootingAfterAmountOfPrefabs)
                        {
                            stopShooting = true;
                            _startShooting = false;
                            shootReady = false;
                            if (destroyShooterAfterAllShot && prefabsShot >= stopShootingAfterAmountOfPrefabs)
                            {
                                Destroy(transform.gameObject);
                            }
                        } 
                }
            }
        }
    }
    public void ShootPrefabs(GameObject _shootPrefab)
    {
        //Debug.Log("Shooting");
        if (_shootPrefab != null)
        {
            if (makeANewCopyOfObject)
            {
                _shootPrefab = Instantiate(_shootPrefab);
            }
            prefabsShot++;
            _shootPrefab.SetActive(true);
            _shootPrefab.GetComponent<Rigidbody>().useGravity = true;
            _shootPrefab.GetComponent<Rigidbody>().isKinematic = false;
            shootForce = 0;
            shootForce = _shootForce * (int)_shootPrefab.GetComponent<Rigidbody>().mass;
            _shootPrefab.transform.position = transform.position;
            _shootPrefab.GetComponent<Rigidbody>().AddForce(((player.position - transform.position) + new Vector3(0, Vector3.Distance(player.position, transform.position) / shootForce * shootUpForce, 0)) * shootForce);
            //Debug.Log("Shooting " + _shootPrefab.name);
            lastShotTime = Time.time;
            shotsFired = true;
            shootAgain = false;

            if(_container != null)
            {
                _shootPrefab.transform.parent = _container;
                _shootPrefab.name = "Ball" + "_" + prefabID + "_" + prefabsShot;
            }
            //Destroy(transform.gameObject);
        }
    }

}
