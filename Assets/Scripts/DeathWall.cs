using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathWall : MonoBehaviour
{
    public float speed = 3f;

    public Transform[] waypoints;
    private int ArrayIndex;

    void Start()
    {
        ArrayIndex = 0;
    }


    void Update()
    {
        if (ArrayIndex == 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[ArrayIndex].transform.position, speed * Time.deltaTime);
            CheckWayPoint();
        }
    }

    void CheckWayPoint()
    {
        int test = ArrayIndex + 1;

        if (Vector2.Distance(transform.position, waypoints[ArrayIndex].transform.position) < 0.1f)
        {
            if (test > 1)
            {
                ArrayIndex = 0;
            }
            else
            {
                ArrayIndex++;
            }

        }
    }
}

