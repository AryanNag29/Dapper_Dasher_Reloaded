using UnityEngine;
using UnityEngine.UI;

public class LogicManager : MonoBehaviour
{
    public int playerScore;
    [SerializeField] private Text scoreText; //reference to the text under ui

    //functions
    [ContextMenu("Increase Score")] //add another context menu to run anything below it like the addScore function
    //addScore to he UI
    public void addScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
    }
}
