using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootLocScript : MonoBehaviour
{
    [SerializeField] float flashDelay;
    public void flash()
    {
        this.GetComponent<SpriteRenderer>().color = Color.red;
        StartCoroutine(undo());
    }

    private IEnumerator undo()
    {
        yield return new WaitForSeconds (flashDelay);
        this.GetComponent<SpriteRenderer>().color = Color.white;

    }
}
