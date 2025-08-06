using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicManager : MonoBehaviour
{
    public int playerScore;
    public bool isGameOver = false;

    [SerializeField] private Text scoreText; //reference to the text under ui
    [SerializeField] private GameObject gameOverScreen;


    //functions
    [ContextMenu("Increase Score")] //add another context menu to run anything below it like the addScore function
    //addScore to he UI
    public void addScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
    }
    //To reset the game whenever you hit playAgain(make sure in ui you have event system)
    public void restartGame()
    {
        Debug.Log("restart");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }
    
}
