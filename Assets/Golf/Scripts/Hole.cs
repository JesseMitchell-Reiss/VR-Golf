using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hole : MonoBehaviour
{
    StartPoint start;
    int pointValue;

    // Start is called before the first frame update
    void Start()
    {
        
        start = FindObjectOfType<StartPoint>();
        float distance = Mathf.Abs(start.transform.position.x - transform.position.x);
        pointValue = (int)Mathf.Round((distance * distance) / 16);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            collision.gameObject.SetActive(false);
            //start.AddPoints(pointValue);
            LevelManager.nextLevel();
        }
    }

    void EndLevel()
    {
        Debug.Log("you win");
    }
}
