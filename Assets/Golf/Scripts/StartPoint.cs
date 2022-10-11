using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPoint : MonoBehaviour
{
    public int numberOfBalls = 1;
    public int ballsRemaining;
    public float ballSpawn;
    public ClubHeadFollower club;


    public GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
        club = FindObjectOfType<ClubHeadFollower>();
        LoadNewGame();
    }

    void LoadBalls(int _numberOfBalls)
    {
        for (int i = 0; i < _numberOfBalls; i++)
        {
            Instantiate(ball, gameObject.transform.position + new Vector3(0, 0, ballSpawn), Quaternion.identity);
            ballSpawn += .2f;

        }
    }

    public void LoadNewGame()
    {
        club.strokeCount = 0;
        
        ballSpawn = -1.9f;
        LoadBalls(numberOfBalls);
    }
}
