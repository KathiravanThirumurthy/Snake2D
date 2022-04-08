using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Uimanager : MonoBehaviour
{
    // Intializing score for collectable
    private int _score = 0;
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Image _gameOver;
    // Intializing Test mesh pro component
    //private TextMeshProUGUI _scoreText;
    void Awake()
    {
        // Getting the Component
        // _scoreText = GetComponent<TextMeshProUGUI>();

    }
    void Start()
    {
        //Calling for intialstate of the score
        RefreshUI();
    }
    //function to refresh the score in UI
    private void RefreshUI()
    {
        //  _scoreText.text = "Score : " + _score;
        _scoreText.text = "Score : " + _score.ToString();


    }
    // Method to get the score for each collectables
    public void incrementScore(int incrementScore)
    {
        // incrementing the score on collection of objects
        _score += incrementScore;
        //Debug.Log("Score:" + _score);
        //updating the UI after the key is collected
        RefreshUI();
    }
    public void gameOver(bool value)
    {
        _gameOver.gameObject.SetActive(value);

    }
    public void restartLevel()
    {

        // Debug.Log("Restart");
       /* PlayerController.isDead = false;
        SceneManager.LoadScene("Scene1", LoadSceneMode.Single);*/

    }
}
