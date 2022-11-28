using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreRecorder : MonoBehaviour
{
    [SerializeField] int score;
    [SerializeField] TMP_Text scoreText;
    //[SerializeField] Text sceneText;

    const int DEFAULT_POINTS = 1;
    //int level;
    string playerName;
    // Start is called before the first frame update
    void Start()
    {
        score = PersistentData.Instance.GetScore();
        playerName = PersistentData.Instance.GetName();
        DisplayScore();
        
        //level = SceneManager.GetActiveScene().buildIndex - 1;
        //sceneText.text = "Level " + (level);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddPoints(int pointsToAdd)
    {
        score += pointsToAdd;
        PersistentData.Instance.SetScore(score);
        DisplayScore();
        //if (score >= (level) * SCORE_TO_ADVANCE)
        //{
            //move to the next level
            //AdvanceLevel();
        //}
    }

    public void AddPoints()
    {
        AddPoints(DEFAULT_POINTS);
    }

    public void AdvanceLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void DisplayScore()
    {
        scoreText.text = "Score: " + score;
    }
}
