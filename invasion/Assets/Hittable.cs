using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hittable : MonoBehaviour
{
    
    public GameObject mark;
    // Start is called before the first frame update

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void isHit(RaycastHit2D _spot)
    {
        
        
        Instantiate(mark, _spot.point, Quaternion.identity);
        var enemy = GetComponent<enemyScript>();
        enemy?.takeDamage();


    }


}
