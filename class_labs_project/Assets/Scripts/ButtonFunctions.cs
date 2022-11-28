using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ButtonFunctions : MonoBehaviour
{

    [SerializeField] TMP_Text playerNameInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        string s = playerNameInput.text;
        PersistentData.Instance.SetName(s);
        SceneManager.LoadScene("Level1");
    }

    public void saveSettings()
    {
        GameObject.FindGameObjectWithTag("VolumeSlider").GetComponent<Volume>().SetLevel();
    }
}
