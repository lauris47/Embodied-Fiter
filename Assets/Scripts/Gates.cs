using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gates : MonoBehaviour
{
    public Transform scoreBoard;
    public int ballHits = 0;
    public bool opponentsGate;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            ballHits++;
            scoreBoard.GetComponent<ScoreBoard>().ChangeScore(scoreBoard.GetComponent<ScoreBoard>().playerScore + 1);
            other.gameObject.tag = "Untagged";
        }
    }
}