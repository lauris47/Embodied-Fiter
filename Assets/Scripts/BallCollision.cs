using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour {
    public AudioClip [] _sounds;
    private AudioSource soundSource;

	void Start () {
        soundSource = GetComponent<AudioSource>();
    }
    void OnCollisionEnter(Collision col)
    {
        if(transform.GetComponent<Rigidbody>().velocity.magnitude > 5)
        {
            PlaySound((int)Random.Range(0, _sounds.Length-1), 26 / transform.GetComponent<Rigidbody>().velocity.magnitude);
            //Debug.Log(transform.GetComponent<Rigidbody>().velocity.magnitude);
        }
    }

    void PlaySound(int _index, float _volume)
    {
        soundSource.clip = _sounds[_index];
        soundSource.volume = _volume;
        soundSource.Play();
    }
}
