using UnityEngine;

public class audioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] public AudioSource musicSource;

    [Header("Audio Clip")]
    public AudioClip beforeDeath;
    public AudioClip afterDeath;
    public AudioClip mainMenu;

}
