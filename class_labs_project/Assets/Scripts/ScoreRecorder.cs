using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreRecorder : MonoBehaviour
{
    [SerializeField] int score;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text sceneText;

    const int DEFAULT_POINTS = 1;
    private int level;
    string playerName;
    // Start is called before the first frame update
    void Start()
    {
        score = PersistentData.Instance.GetScore();
        playerName = PersistentData.Instance.GetName();
        level = SceneManager.GetActiveScene().buildIndex;
        DisplayScoreAndLevel();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddPoints(int pointsToAdd)
    {
        score += pointsToAdd;
        PersistentData.Instance.SetScore(score);
        DisplayScoreAndLevel();
        //AdvanceLevel();
    }

    public void AddPoints()
    {
        AddPoints(DEFAULT_POINTS);
    }

    public void AdvanceLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void DisplayScoreAndLevel()
    {
        scoreText.text = "Score: " + score;
        sceneText.text = "Level " + level;
    }
}
