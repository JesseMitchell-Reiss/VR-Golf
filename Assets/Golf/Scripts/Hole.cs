using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hole : MonoBehaviour
{
    StartPoint start;

    // Start is called before the first frame update
    void Start()
    {
        start = FindObjectOfType<StartPoint>();
        float distance = Mathf.Abs(start.transform.position.x - transform.position.x);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            collision.gameObject.SetActive(false);
            GameObject.FindObjectOfType<LevelManager>().score++;
        }
    }

    void EndLevel()
    {
        GameObject.FindObjectOfType<LevelManager>().nextLevel();
    }
}
