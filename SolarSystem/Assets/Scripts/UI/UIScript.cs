using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{

    public GameObject pauseMenu;
    public GameObject settings;
    public GameObject instructions;
    public SpaceShip player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ShowInstructions()
    {
        instructions.SetActive(true);
        pauseMenu.SetActive(false);
    }

    public void ShowSettings()
    {
        settings.SetActive(true);
        pauseMenu.SetActive(false);
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    public void BackFromInstructions()
    {
        instructions.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void BackFromSettings()
    {
        settings.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        player.pause = false;
        Cursor.lockState = CursorLockMode.Locked;
    }


}
