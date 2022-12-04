using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

    [SerializeField] GameObject PauseMenu;
    [SerializeField] bool paused;


    // Start is called before the first frame update
    void Start()
    {
        paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && !paused)
        {
            PauseGame();
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0.0f;
        Vector2 pos = new Vector2(558.8197f, 274.1418f);
        Instantiate(PauseMenu, pos, Quaternion.identity);
        paused = true;
    }

    public void Unpause()
    {
        Time.timeScale = 1.0f;
        Destroy(GameObject.FindWithTag("Pause"));
        paused = false;
    }
}
