using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class droneScript : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    private float droneDistance = -1.2f;


    private void Awake()
    {
        Vector2 playerlocation = new Vector2(player.transform.position.x + droneDistance, player.transform.position.y + droneDistance);
    }

    private void FixedUpdate()
    {
        Vector2 playerlocation = new Vector2(player.transform.position.x + droneDistance, player.transform.position.y + droneDistance);
        transform.position = playerlocation;
    }
}
