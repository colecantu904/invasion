using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrolTargetScript : MonoBehaviour
{
    [SerializeField] Vector2 first;
    [SerializeField] Vector2 second;
    [SerializeField] Vector2 third;
    [SerializeField] Vector2 fourth;

    int i = 0;

    private void Awake()
    {
        transform.position = first;
    }


    public void rotateTarget()
    {
        i++;
        if (i > 3)
        {
            i = 0;
        }

        // can mpdify to take a specific int to set the position accordingly
        Vector2[] spot = { first, second, third, fourth };
        transform.position = spot[i];
    }


    
}
