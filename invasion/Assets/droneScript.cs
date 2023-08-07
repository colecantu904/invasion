using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class droneScript : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    [SerializeField]
    Rigidbody2D rb;
    private float droneDistance = 1.2f;
    public float droneDamp = 2f;
    
    


    private void Awake()
    {
        Vector2 playerlocation = new Vector2(player.transform.position.x + droneDistance, player.transform.position.y + droneDistance);
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {

        //transform.position = playerlocation;
        move();
    }

    private void move()
    {
        Vector2 playerlocation = new Vector2(player.transform.position.x + droneDistance, player.transform.position.y + droneDistance);
 
        if (player.GetComponent<Transform>().rotation.z > 0)
        {
            droneDistance *= -1;
        }
        rb.position = Vector2.MoveTowards(rb.position, playerlocation, droneDamp);
    }

}
