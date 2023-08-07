using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comandMenuScript : MonoBehaviour
{
    public static bool gameisPaused = false;


    //[SerializeField]
    //droneMenuScript droneCommands;
    [SerializeField]
    GameObject buttons;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (gameisPaused)
            {
                resume();
            }
            else
            {
                Time.timeScale = 0f;
                buttons.SetActive(true);
                gameisPaused = true;
            }
        }
    }

    public void resume()
    {
        gameisPaused = false;
        buttons.SetActive(false);
        Time.timeScale = 1f;
    }
}
