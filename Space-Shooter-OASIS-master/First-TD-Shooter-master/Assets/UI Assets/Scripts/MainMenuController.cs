using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public string gameplayScene;
    public GameObject optionsMenu;

    private void Start()
    {

    }

    public void PlayButton()
    {
        //scene 1 is level 1
        SceneManager.LoadScene("First Level");
    }

    public void QuitButton()
    {
        Debug.Log("Quittted");
        Application.Quit();
    }
    public void OptionsButton()
    {
        Instantiate(optionsMenu);
    }

}
