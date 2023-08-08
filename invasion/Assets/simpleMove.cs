using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpleMove : MonoBehaviour
{

    Vector2 movement;
    public int speed = 6;
    public float rotSpeed = 5f;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Camera cam;

    [SerializeField] Transform _shootLocation;
    [SerializeField] public float _range;


    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.queriesHitTriggers = false;
    }

    // Update is called once per frame
    void Update()
    {
        movement.y = Input.GetAxisRaw("Vertical");
        movement.x = Input.GetAxisRaw("Horizontal");

        shoot();

    }

    private void FixedUpdate()
    {
        turn();
        move();
    }

    private void turn()
    {
        Vector3 mouse = Input.mousePosition;
        mouse = cam.ScreenToWorldPoint(mouse);
        Vector2 direction = new Vector2(mouse.x - transform.position.x, mouse.y - transform.position.y);
        transform.right = direction;
    }   

    private void move()
    {
        rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
        cam.GetComponent<Rigidbody2D>().MovePosition(rb.position + (Vector2)rb.transform.right * 2);
    }

    private void shoot()
    {
        if (Input.GetMouseButtonDown(0)){
            GetComponentInChildren<shootLocScript>().flash();
            var hit = Physics2D.Raycast(_shootLocation.position, rb.transform.right, _range);
            if (hit.collider != null&& !hit.collider.isTrigger)
            {
 
                var _hit = hit.collider.GetComponent<Hittable>();
                _hit?.isHit(hit);
            }
        }
    }

}
