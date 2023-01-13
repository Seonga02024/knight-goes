using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HpManager : MonoBehaviour
{
    public GameObject h1;
    public GameObject h2;
    public GameObject h3;
    public GameObject GameOver;
    public int hpcount;

    // Start is called before the first frame update
    void Start()
    {
        hpcount = PlayerPrefs.GetInt("hite");
        DeleteHP();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(Time.timeScale == 0)
            {
                GameObject.Find("player").GetComponent<Player>().saveStage();
                Time.timeScale = 1;
                SceneManager.LoadScene(0);
            }
        }
    }

    public void MinusHp()
    {
        hpcount--;
        DeleteHP();
    }

    public void DeleteHP()
    {
        if(hpcount == 2)
        {
            Destroy(h3);
            PlayerPrefs.SetInt("hite", 2);
        }
        else if(hpcount == 1)
        {
            Destroy(h2);
            if (h3 != null)
                Destroy(h3);
            PlayerPrefs.SetInt("hite", 1);
        }
        else if (hpcount == 0)
        {
            Destroy(h1);
            if (h2 != null)
                Destroy(h2);
            if (h3 != null)
                Destroy(h3);
            //Time.timeScale = 0;
            StartCoroutine("FadeIn");
            PlayerPrefs.SetInt("hite", 3);
        }
    }

    IEnumerator FadeIn()
    {
        Image spr = GameOver.GetComponent<Image>();
        Color color = spr.color;
        color.a = 0.0f;
        spr.color = color;
        GameObject BackgroundMusic = GameObject.Find("Main Camera");
        AudioSource backmusic = BackgroundMusic.GetComponent<AudioSource>(); //배경음악 저장해둠
        backmusic.Stop();
        yield return new WaitForSeconds(2f);
        GameOver.SetActive(true);
        for (int i = 0; i < 11; i++)
        {
            float f = i / 10.0f;
            color.a = f;
            spr.color = color;
            yield return new WaitForSeconds(0.1f);
        }
        Time.timeScale = 0;
    }
}
