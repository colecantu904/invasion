using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class playerHealth : MonoBehaviour
{
    [SerializeField] public int health= 5;
    [SerializeField] private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //damages player preiodically
    private IEnumerator takeDamage(int dam, float pace)
    {
        yield return new WaitForSeconds(pace);

    }

    //Starts damage loop
    public void hit(int dam)
    {
        //StartCoroutine(takeDamage(dam,pace));
        sr.color = Color.red;
        StartCoroutine(colorReset());
        health -= dam;
        if (health <= 0) SceneManager.LoadScene(0);
        Debug.Log("hit");
    }

    //resets player color
    private IEnumerator colorReset()
    {
        yield return new WaitForSeconds(0.2f);
        sr.color = Color.white;
    }
}
