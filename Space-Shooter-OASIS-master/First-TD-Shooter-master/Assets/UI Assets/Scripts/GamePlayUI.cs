using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GamePlayUI : MonoBehaviour
{
    [SerializeField] int score = 0;

    //Health and Lives
    public static GamePlayUI instance { get; private set; }

    //Health Bar
    public Image healthMask;
    float originalSizeHealth;

    //Lives
    public Text livesText;

    //Scoring
    public Text scoreText;

    //Pausing
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    //Scenes
    public string mainMenuScene;
    public GameObject optionsMenu;

    void Awake()
    {
        instance = this;
        Resume();
    }

    // Start is called before the first frame update
    void Start()
    {
        originalSizeHealth = healthMask.rectTransform.rect.width;
        SetScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        //Pausing
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

    }
     public void SetScore(float value)
    {
        scoreText.text = "Score: " + value.ToString("0");
    }
    /////////////////R CODE
    public void AddToScore(int scoreValue)
    {
        score += scoreValue;
        scoreText.text = "Score: " + score.ToString("0");
    }
    public int returnScore()
    {
        return score;
    }
    public void SetValueHealth(float value)
    {
        healthMask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSizeHealth * value);
    }
    ////////////////R CODE
    public void UpdateHealth(float currentHealth, float maxHealth)
    {
        float trueHealth = currentHealth / maxHealth;
        GamePlayUI.instance.SetValueHealth(trueHealth);
    }

    public void SetValueLives(int value)
    {
        livesText.text = "Lives: " + value.ToString("0");
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(mainMenuScene);
    }
    public void OptionsButton()
    {
        Instantiate(optionsMenu);
    }
}
