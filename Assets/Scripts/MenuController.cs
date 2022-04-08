using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Main menu controller script
/// </summary>
public class MenuController : MonoBehaviour
{
    // getting the button gameObject
    [SerializeField]
    private GameObject[] _mainMenuBtn;
    
    
    // Loading the scene
    public void LoadScene()
    {
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    }
    //quitting the game
    public void quitGame()
    {
        Application.Quit();
    }
}
