using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class enemyMove : MonoBehaviour
{
    private float speed = 600f;
    public float wayPointDist = 3f;
    private int currWay = 0;
    private bool reachedWay = false;


    Path path;


    public Transform target;
    [SerializeField]
    private Seeker seeker;
    [SerializeField]
    private Rigidbody2D rb;
    Vector2 force;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        seeker = GetComponent<Seeker>();


        InvokeRepeating("updatePath", 0f, 2f);

    }

    private void updatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(transform.position, target.position, OnPathSet);
        }
    }


    void OnPathSet(Path pat)
    {
        if (!pat.error)
        {
            path = pat;
            currWay = 0;
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (path == null)
        {
            return;
        }

        if (currWay >= path.vectorPath.Count)
        {
            reachedWay = true;
            return;
        } else
        {
            reachedWay = false;
        }

        Vector2 destination = ((Vector2)path.vectorPath[currWay] - rb.position).normalized;

        Vector2 force = destination * speed * Time.deltaTime;
        rb.AddForce(force);
        //rb.position = Vector2.MoveTowards(rb.position, destination, speed);
        //rb.AddForce(destination);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currWay]);

        if (distance < wayPointDist)
        {
            currWay++;
        }

        

    }
    private void Update()
    {
        //Face Player
        Vector2 direction = new Vector2(target.position.x - transform.position.x, target.position.y - transform.position.y);
        transform.right = direction;
    }

}
