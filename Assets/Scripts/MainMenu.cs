using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button quitButton;
    private void Awake()
    {
        playButton.onClick.AddListener(PlayButton);
        quitButton.onClick.AddListener(QuitButton);
    }

    private void PlayButton()
    {
        SceneManager.LoadScene(1);
    }

    private void QuitButton()
    {
        Application.Quit();
    }
}
