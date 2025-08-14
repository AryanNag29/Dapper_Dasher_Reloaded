using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public audioManager audios;
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
        audios = GameObject.FindGameObjectWithTag("Audio").GetComponent<audioManager>();
        audios.musicSource.clip = audios.mainMenu;
        audios.musicSource.Play();
    }
}
