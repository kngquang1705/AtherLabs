using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int score;

    [SerializeField] private Text scoreText;

    [SerializeField] private Button pauseButton;
    [SerializeField] private Button continueButton;
    [SerializeField] private Button menuButton;
    [SerializeField] private GameObject pauseGamePanel;
    [SerializeField] private GameObject deathPanel;
    [SerializeField] private Button playAgainButton;
    [SerializeField] private Button deathToMenuButton;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            
        }
        else
        {
            Destroy(gameObject);
        }
        score = 0;
    }

    private void Start()
    {
        pauseButton.onClick.AddListener(PauseGame);
        continueButton.onClick.AddListener(ContinueButton);
        menuButton.onClick.AddListener(MenuButton);
        playAgainButton.onClick.AddListener(PlayAgain);
        deathToMenuButton.onClick.AddListener(MenuButton);
    }

    public void AddScore()
    {
        score++;
        scoreText.text ="Score: " + score.ToString();
    }
    
    private void PauseGame()
    {
        Time.timeScale = 0;
        pauseGamePanel.SetActive(true);
    }

    private void ContinueButton()
    {
        Time.timeScale = 1;
        pauseGamePanel.SetActive(false);
    }

    public void MenuButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void Death()
    {
        Time.timeScale = 0;
        deathPanel.SetActive(true);
    }

    private void PlayAgain()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
        deathPanel.SetActive(false);
    }
}
