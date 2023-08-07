using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class markerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(die());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator die()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
