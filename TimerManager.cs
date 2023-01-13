using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerManager : MonoBehaviour
{
    public Image timer;
    public Image clear;
    public Image save;
    private float set_timer = 30;
    private float time;
    public int nextgoal;
    int a = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("saveM");
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(timer.fillAmount != 0)
        {
            float h = 1 - (time / 30);
            timer.fillAmount = Mathf.Lerp(timer.fillAmount, h, Time.deltaTime * 0.5f);
        }
        if (timer.fillAmount == 0 && a == 0 && GameObject.Find("hites").GetComponent<HpManager>().hpcount > 0)
        {
            StartCoroutine("nextTime");
        }
    }

    IEnumerator saveM()
    {
        save.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        save.gameObject.SetActive(false);
    }

    IEnumerator nextTime()
    {
        a++;
        Image spr = clear.GetComponent<Image>();
        Color color = spr.color;
        color.a = 0.0f;
        spr.color = color;
        clear.gameObject.SetActive(true);
        for (int i = 0; i < 11; i++)
        {
            float f = i / 10.0f;
            color.a = f;
            spr.color = color;
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(1f);
        clear.gameObject.SetActive(false);
        SceneManager.LoadScene(nextgoal);
        Debug.Log("goal");
    }

    IEnumerator FadeIn(GameObject game)
    {
        SpriteRenderer spr = game.GetComponent<SpriteRenderer>();
        Color color = spr.color;
        color.a = 0.0f;
        spr.color = color;
        for (int i = 0; i < 11; i++)
        {
            float f = i / 10.0f;
            color.a = f;
            spr.color = color;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
