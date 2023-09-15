using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public GameObject instructions;
    public GameObject settings;
    public GameObject mainMenu;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    
    public void ShowInstructions()
    {
        instructions.SetActive(true);
        mainMenu.SetActive(false);
    }
    
    public void ShowSettings()
    {
        settings.SetActive(true);
        mainMenu.SetActive(false);
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
        mainMenu.SetActive(true);
    }
    
    public void BackFromSettings()
    {
        settings.SetActive(false);
        mainMenu.SetActive(true);
    }



}
