using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class ButtonFunctions : MonoBehaviour
{

    [SerializeField] TMP_Text playerNameInput;
    private Vector2 soundPos = new Vector2(0.0f, 0.0f);

    private const float TIMEDELAY = 0.1f;

    private const string MAINMENU = "MainMenu";

    public void PlayGame()
    {
        string s = playerNameInput.text;
        PersistentData.Instance.SetName(s);
        PersistentData.Instance.SetHasLevelReset(false);
        PersistentData.Instance.SetScore(0);
        SceneManager.LoadScene("Level1");
    }

    public void PlayAgain()
    {
        PersistentData.Instance.SetHasLevelReset(false);
        PersistentData.Instance.SetScore(0);
        SceneManager.LoadScene("Level1");
    }

    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void SaveSettings()
    {
        SceneManager.LoadScene(MAINMENU);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ResetHighScores()
    {
        PlayerPrefs.DeleteAll();
        PersistentData.Instance.SetScore(0);
        SceneManager.LoadScene("HighScores");
    }

    public void Instructions()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(MAINMENU);
    }

    public void HighScores()
    {
        SceneManager.LoadScene("HighScores");
    }
}
