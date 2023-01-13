using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("hite", 3);
    }

    void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Screen.SetResolution(2340, 1080, true);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickExit()
    {
        Application.Quit();
        Debug.Log("OnClickExit");
    }

    public void StartNewGame()
    {
        Debug.Log("StartNewGame");
        SceneManager.LoadScene(1);
    }

    public void ReLoadGame()
    {
        Debug.Log("ReLoadGame");
        int saveStage = PlayerPrefs.GetInt("saveStage");
        SceneManager.LoadScene(saveStage);
    }

    public void Score()
    {
        Debug.Log("Score");
        SceneManager.LoadScene(0);
    }

    public void Background()
    {
        Debug.Log("Background");
        SceneManager.LoadScene(0);
    }
}
