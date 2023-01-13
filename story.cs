using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Video;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class story : MonoBehaviour
{
    public GameObject chat;
    public Text ChatText;
    public GameObject choose;
    public Text chooseText1;
    public Text chooseText2;
    string writwerText;
    int ch_num = 0;
    int choose_num = 0;
    int chat_delay_time = 2;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TextPratice());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                GameObject clickObject = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
                if (clickObject)
                {
                    Debug.Log(clickObject.name);
                    choose.SetActive(false);
                    chat.SetActive(true);
                    if (clickObject.name == "A")
                    {
                        ch_num = 1;
                    }
                    if (clickObject.name == "B")
                    {
                        ch_num = 2;
                    }
                    if(choose_num == 0)
                        StartCoroutine(TextPratice2());
                    else if(choose_num == 1)
                        StartCoroutine(TextPratice3());
                    else
                        StartCoroutine(TextPratice4());
                }
                else
                {
                    Debug.Log("No game object");
                }
            }
        }
    }

    IEnumerator Normalchat(string narrator, float stoptime)
    {
        int a = 0;
        writwerText = "";
        for (a = 0; a < narrator.Length; a++)
        {
            writwerText += narrator[a];
            ChatText.text = writwerText;
            yield return new WaitForSeconds(0.05f);
        }
        //ChatText.text = narrator;
        yield return new WaitForSeconds(stoptime);
    }

    IEnumerator TextPratice()
    {
        chat.SetActive(true);
        yield return StartCoroutine(Normalchat("마법사: 자네의 여행엔 큰 이야기가 있지…. 듣겠는가? ", chat_delay_time));
        chat.SetActive(false);
        chooseText1.text = "들어보죠.";
        chooseText2.text = "싫소, 난 바쁩니다.";
        choose.SetActive(true);
    }

    IEnumerator TextPratice2()
    {
        if (ch_num == 1)
        {
            yield return StartCoroutine(Normalchat("파티를 즐기던 어느 날…. 공주님은 심심함을 이기지 못해 왕성 뒷문으로 몰래 나갔다네.", chat_delay_time));
            yield return StartCoroutine(Normalchat("하지만 운이 없게도 그 날, 산책을 나온 용이 공주님을 발견했고.", chat_delay_time));
            yield return StartCoroutine(Normalchat("공주님이 마음에 들었는지 그만 데리고 날아가 버렸지.", chat_delay_time));
            yield return StartCoroutine(Normalchat("후에 그 사실을 안 왕께서는 분노하며 기사들로부터 공주를 데려오라는 명령을 내렸지.", chat_delay_time));
            yield return StartCoroutine(Normalchat("그래서 자네가 가는 게야…. 이해되었나?", chat_delay_time));
            chat.SetActive(false);
            chooseText1.text = "기사의 명예를 걸고, 공주님을 데려오겠습니다.";
            chooseText2.text = "가기 싫습니다!";
            choose.SetActive(true);
        }
        else
        {
            yield return StartCoroutine(Normalchat("허허…. 그럴 줄 알고 스크립트를 준비 안 했지.", chat_delay_time));
            yield return StartCoroutine(Normalchat("명심하게…. 몬스터를 쓰러트리는 방법은 오직 시간과 버팀이라는 것을…!", chat_delay_time));
            SceneManager.LoadScene(2);
        }
        choose_num++;
    }

    IEnumerator TextPratice3()
    {
        if (ch_num == 1)
        {
            yield return StartCoroutine(Normalchat("명심하게…. 몬스터를 쓰러트리는 방법은 오직 시간과 버팀이라는 것을…!", chat_delay_time));
            SceneManager.LoadScene(2);
        }
        else
        {
            yield return StartCoroutine(Normalchat("공주를 구하는 자에겐…. 왕께서 1억 골드를 주겠다 약조하셨지…….", chat_delay_time));
            chat.SetActive(false);
            chooseText1.text = "기사의 명예를 걸고, 공주님을 데려오겠습니다.";
            chooseText2.text = "기사의 명예를 걸고, 공주님을 데려오겠습니다.";
            choose.SetActive(true);
        }
        choose_num++;
    }

    IEnumerator TextPratice4()
    {
        yield return StartCoroutine(Normalchat("명심하게…. 몬스터를 쓰러트리는 방법은 오직 시간과 버팀이라는 것을…!", chat_delay_time));
        choose_num++;
        SceneManager.LoadScene(2);
    }
}
