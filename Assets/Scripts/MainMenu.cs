using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public audioManager audio;
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void quit()
    {
        Application.Quit();
    }
    void Start()
    {
        audio = GameObject.FindGameObjectWithTag("Audio").GetComponent<audioManager>();
        audio.musicSource.clip = audio.mainMenu;
        audio.musicSource.Play();
    }
}
