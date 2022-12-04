using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentData : MonoBehaviour
{
    [SerializeField] string playerName;
    [SerializeField] int playerScore;
    [SerializeField] bool isGameModeEasy;
    [SerializeField] bool hasLevelReset;
    [SerializeField] int birdCount;

    public static PersistentData Instance;

    public void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(this);
            Instance = this;
        }
        else
            Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        playerName = "";
        playerScore = 0;
        isGameModeEasy = true;
        hasLevelReset = false;
        birdCount = 0;
    }

    public void SetName(string name)
    {
        playerName = name;
    }
    public void SetScore (int score)
    {
        playerScore = score;
    }

    public void SetGameModeEasy(bool easy)
    {
        isGameModeEasy = easy;
    }

    public void SetHasLevelReset(bool reset)
    {
        hasLevelReset = reset;
    }

    public void SetBirdCount(int count)
    {
        birdCount = count;
    }

    public string GetName()
    {
        return playerName;
    }

    public int GetScore()
    {
        return playerScore;
    }

    public bool GetGameModeEasy()
    {
        return isGameModeEasy;
    }

    public bool GetHasLevelReset()
    {
        return hasLevelReset;
    }

    public int GetBirdCount()
    {
        return birdCount;
    }
}