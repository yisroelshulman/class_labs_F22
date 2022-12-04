using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScores : MonoBehaviour
{
    const int NUM_HIGH_SCORES = 5;
    const string NAME_KEY = "Player";
    const string SCORE_KEY = "Score";

    private string playerName;
    private int playerScore;
 
    [SerializeField] TMP_Text[] nameTexts;
    [SerializeField] TMP_Text[] scoreTexts;


    // Start is called before the first frame update
    void Start()
    {
        playerName = PersistentData.Instance.GetName();
        playerScore = PersistentData.Instance.GetScore();
        if (playerScore > 0)
        {
            SaveHighScores();
        }
        ShowHighScores();
    }

    public void SaveHighScores()
    {
        for (int i = 1; i <= NUM_HIGH_SCORES; i++)
        {
            string currentNameKey = NAME_KEY + i;
            string currentScoreKey = SCORE_KEY + i;

            if (PlayerPrefs.HasKey(currentScoreKey))
            {
                int currentScore = PlayerPrefs.GetInt(currentScoreKey);
                if (playerScore > currentScore)
                {
                    int tempScore = currentScore;
                    string tempName = PlayerPrefs.GetString(currentNameKey);

                    PlayerPrefs.SetString(currentNameKey, playerName);
                    PlayerPrefs.SetInt(currentScoreKey, playerScore);

                    playerName = tempName;
                    playerScore = tempScore;

                }
            }
            else
            {
                PlayerPrefs.SetString(currentNameKey, playerName);
                PlayerPrefs.SetInt(currentScoreKey, playerScore);
                return;
            }
        }
    }

    public void ShowHighScores()
    {
        for (int i = 0; i < NUM_HIGH_SCORES; i++)
        {
            nameTexts[i].text = PlayerPrefs.GetString(NAME_KEY + (i + 1), "Player " + (i + 1));
            scoreTexts[i].text = PlayerPrefs.GetInt(SCORE_KEY + (i + 1)).ToString();
        }
    }
}
