using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class pausemenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool paused = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!paused)
            {
                pauseMenu.SetActive(true);
                paused = true;
            }
            else if (paused)
            {
                pauseMenu.SetActive(false);
                paused = false;
            }
        }
    }
    
    public void mainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void exit()
    {
        Application.Quit();
    }
}
