using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawnerLevel2 : MonoBehaviour
{

    [SerializeField] GameObject Bird;

    private int startDelay = 0;
    private int spawnDelay = 3;

    private const float RIGHTB = 10.2f;
    private const float LEFTB = -10.2f;
    private const float UPPERB = 5.64f;
    private const float LOWERB = -3.55f;

    private bool isEasyMode;

    // Start is called before the first frame update
    void Start()
    {
        isEasyMode = PersistentData.Instance.GetGameModeEasy();
        if (!isEasyMode)
        {
            InvokeRepeating("Spawn", startDelay, spawnDelay);
        }
    }

    void Spawn()
    {
        if (PersistentData.Instance.GetBirdCount() < 1)
        {
            Vector2 pos = new Vector2(Random.Range(LEFTB, RIGHTB), Random.Range(LOWERB, UPPERB));
            Instantiate(Bird, pos, Quaternion.identity);
            PersistentData.Instance.SetBirdCount(PersistentData.Instance.GetBirdCount() + 1);
        }
    }
}
