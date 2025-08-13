using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicManager : MonoBehaviour
{
    public int playerScore;


    [SerializeField] private Text scoreText; //reference to the text under ui
    [SerializeField] private GameObject gameOverScreen;


    //functions
    [ContextMenu("Increase Score")] //add another context menu to run anything below it like the addScore function
    //addScore to he UI
    public void addScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString(); // we use to string keyword to convert int into string;
    }

    //To reset the game whenever you hit playAgain(make sure in ui you have event system)
    public void restartGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }

    public void quit()
    {
        Application.Quit();
    }
    
}
