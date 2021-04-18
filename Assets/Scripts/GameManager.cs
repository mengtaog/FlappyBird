using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject tutorial;
    public GameObject scoreBar;
    public GameObject player;
    public GameObject pipesManager;
    public GameObject pauseScreen;
    public GameObject gameover;
    public GameObject newScore;
    public Text scoreText;
    public Text finalText;
    public Text bestScoreText;
    public GameObject background;
    public GameObject pipes;
    public GameObject land;
    public GameObject medal;
    private GameProcedure _procedure = 0;

    public List<Sprite> medals;

    public void PlayBtnClick()
    {
        _procedure = GameProcedure.onTutorial;
        Tools.Instance.HideUIObj(mainMenu);
        Tools.Instance.ShowUIObj(tutorial);
        Tools.Instance.ShowUIObj(scoreBar);
        player.GetComponent<PlayerController>().setStartedFlag(true);
        player.GetComponent<PlayerController>().StateTransition(1);

    }

    
    public void setProcedure(GameProcedure procedure)
    {
        _procedure = procedure;
    }

    public void GamePause()
    {
        Time.timeScale = 0f;
        Tools.Instance.ShowUIObj(pauseScreen);
        
    }

    public void GameContinune()
    {
        Time.timeScale = 1f;
        Tools.Instance.HideUIObj(pauseScreen);
    }

    public GameProcedure getProcedure()
    {
        return _procedure;
    }

    public void GameOver()
    {
        if (_procedure == GameProcedure.gameover) return;
        Time.timeScale = 0f;
        _procedure = GameProcedure.gameover;
        background.GetComponent<BackgroundController>().Stop();
        pipes.GetComponent<PipesManager>().Stop();
        land.GetComponent<BackgroundController>().Stop();
        Tools.Instance.ShowUIObj(gameover, 0f);
        int score = int.Parse(scoreText.text);
        if(score < 5)
        {
            medal.SetActive(false);
        }
        else if(score < 10)
        {
            medal.GetComponent<Image>().sprite = medals[0];
        }
        else if(score < 30)
        {
            medal.GetComponent<Image>().sprite = medals[1];
        }
        else if(score < 60)
        {
            medal.GetComponent<Image>().sprite = medals[2];
        }
        else medal.GetComponent<Image>().sprite = medals[3];

        if (score > PlayerPrefs.GetInt("bestScore"))
        {
            PlayerPrefs.SetInt("bestScore", score);
        }
        else
        {
            Tools.Instance.HideUIObj(newScore);
        }
        finalText.text = score.ToString();
        bestScoreText.text = PlayerPrefs.GetInt("bestScore").ToString();


    }

    public void Restart()
    {
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1.0f;
    }

    public void GainScore()
    {
        scoreText.text = (int.Parse(scoreText.text) + 1).ToString();
    }    

    private void Update()
    {
        switch (_procedure)
        {
            case GameProcedure.onMenu:
                {
                    break;
                }
            case GameProcedure.onTutorial:
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        Tools.Instance.HideUIObj(tutorial);
                        player.GetComponent<PlayerController>().StateTransition(2);
                        _procedure = GameProcedure.started;
                        pipesManager.GetComponent<PipesManager>().setStarted(true);
                    }
                    break;
                }
            case GameProcedure.started:
                {
                    break;
                }
            case GameProcedure.gameover:
                {
                    break;
                }
        }
    }

    public enum GameProcedure{
        onMenu = 0,
        onTutorial = 1,
        started,
        gameover
    };

    
}
