using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Menu : MonoBehaviour
{
    public AudioSource clip;

    public void ChangeScene()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void PlaySoundButoon()
    {
        clip.Play();
    }
}
