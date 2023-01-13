using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Video;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class endingStory : MonoBehaviour
{
    public GameObject storyImage;
    public GameObject chat;
    public Text ChatText;
    public GameObject choose;
    public Text chooseText1;
    public Text chooseText2;
    string writwerText;
    int root_num = 0;
    int ch_num = 0;
    int choose_num = 0;
    int chat_delay_time = 2;
    int chat_delay_time2 = 4;
    bool finish_end = false;

    public GameObject bgimg;
    public GameObject img1;
    public GameObject img2;
    public GameObject img3;
    public GameObject img4;
    public GameObject img5;
    public GameObject endText1;
    public GameObject endText2;

    public GameObject normal_bgm;
    public GameObject sad_bgm;
    public GameObject happy_bgm;

    public GameObject ornalprin;
    public GameObject changeprin;
    public GameObject angleprin;

    // Start is called before the first frame update
    void Start()
    {
        storyImage.SetActive(true);
        ornalprin.SetActive(true);
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
                    if (choose_num == 0)
                        StartCoroutine(TextPratice2());
                    else if (choose_num == 1)
                        StartCoroutine(TextPratice3());
                    else if (choose_num == 2)
                        StartCoroutine(TextPratice4());
                    else if (choose_num == 3)
                        StartCoroutine(TextPratice5());
                    else if (choose_num == 4)
                        StartCoroutine(TextPratice6());
                    else if (choose_num == 5)
                        StartCoroutine(TextPratice7());
                    else if (choose_num == 6)
                        StartCoroutine(TextPratice8());
                }
                else
                {
                    Debug.Log("No game object");
                }
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            PlayerPrefs.SetInt("saveStage", 8);
            SceneManager.LoadScene(0);
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (finish_end == true)
            {
                PlayerPrefs.SetInt("saveStage", 0);
                SceneManager.LoadScene(0);
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

    IEnumerator Endchat1(string narrator, float stoptime)
    {
        int a = 0;
        writwerText = "";
        for (a = 0; a < narrator.Length; a++)
        {
            writwerText += narrator[a];
            endText1.GetComponent<Text>().text = writwerText;
            yield return new WaitForSeconds(0.05f);
        }
        //ChatText.text = narrator;
        yield return new WaitForSeconds(stoptime);
    }

    IEnumerator Endchat2(string narrator, float stoptime)
    {
        int a = 0;
        writwerText = "";
        for (a = 0; a < narrator.Length; a++)
        {
            writwerText += narrator[a];
            endText2.GetComponent<Text>().text = writwerText;
            yield return new WaitForSeconds(0.05f);
        }
        //ChatText.text = narrator;
        yield return new WaitForSeconds(stoptime);
    }

    IEnumerator TextPratice()
    {
        chat.SetActive(true);
        yield return StartCoroutine(Normalchat("공주: 당신이 나를 구하로 온 기사로군요!", chat_delay_time));
        chat.SetActive(false);
        chooseText1.text = "기사의 명예를 걸고 당신을 데리러 왔습니다.";
        chooseText2.text = "당신을 구하면 1억 골드를 준다고 들었습니다.";
        choose.SetActive(true);
    }

    IEnumerator TextPratice2()
    {
        if (ch_num == 1)
        {
            yield return StartCoroutine(Normalchat("그렇군요. 지금까지 그 누구도 여기까지 도달하지 못해서 좌절하고 있었는데...", chat_delay_time));
            yield return StartCoroutine(Normalchat("당신이 와주셔서 살았어요, 감사합니다.", chat_delay_time));
            yield return StartCoroutine(Normalchat("제가 이 보답을 어떻게 해드려야 할지...", chat_delay_time));
            chat.SetActive(false);
            chooseText1.text = "당신에게 한눈에 반했습니다.";
            chooseText2.text = "공주님, 예전부터 사모하고 있었습니다.";
            choose.SetActive(true);
            root_num = 1;
        }
        else
        {
            yield return StartCoroutine(Normalchat("그렇군요. 당신은 절 구하러 온 게 아니라 돈을 얻으러 온 것이로군요.", chat_delay_time));
            chat.SetActive(false);
            chooseText1.text = "당연하죠. 제게 돈보다 소중한 것은 없습니다.";
            chooseText2.text = "아뇨... 사실 당신을 구하러 왔습니다.";
            choose.SetActive(true);
            root_num = 2;
        }
        choose_num++;
    }

    IEnumerator TextPratice3()
    {
        if (root_num == 1 && ch_num == 1)
        {
            yield return StartCoroutine(Normalchat("사실... 저도 당신의 충직한 모습에 반했어요.", chat_delay_time));
            yield return StartCoroutine(Normalchat("돌아가서 아버지께 말하고 정식으로 사귀면... 어떨까요?", chat_delay_time));
            chat.SetActive(false);
            chooseText1.text = "당연히 좋습니다.";
            chooseText2.text = "가죠!";
            choose.SetActive(true);
            root_num = 1;
        }
        if (root_num == 2 && ch_num == 1)
        {
            yield return StartCoroutine(Normalchat("알겠습니다. 구해주셔서 감사해요. ", chat_delay_time));
            yield return StartCoroutine(Normalchat("이번 일은 꼭 아버지에게 말해드리죠.", chat_delay_time));
            chat.SetActive(false);
            GameObject BackgroundMusic = GameObject.Find("Main Camera");
            AudioSource backmusic = BackgroundMusic.GetComponent<AudioSource>(); //배경음악 저장해둠
            backmusic.Stop();
            normal_bgm.SetActive(true);
            bgimg.SetActive(true);
            img3.SetActive(true);
            Image spr = img3.GetComponent<Image>();
            Color color = spr.color;
            for (int i = 0; i < 11; i++)
            {
                float f = i / 10.0f;
                color.a = f;
                spr.color = color;
                yield return new WaitForSeconds(0.1f);
            }
            endText1.SetActive(true);
            endText2.SetActive(true);
            yield return StartCoroutine(Endchat1("노말 엔딩 1", 1));
            yield return StartCoroutine(Endchat2("부제 : 큰 돈을 벌꺼야!", 1));
            finish_end = true;
        }
        if (root_num == 2 && ch_num == 2)
        {
            yield return StartCoroutine(Normalchat("변명은 괜찮습니다.", chat_delay_time));
            yield return StartCoroutine(Normalchat("구해주셔서 감사해요. 이번 일은 꼭 아버지에게 말해드리죠.", chat_delay_time));
            chat.SetActive(false);
            GameObject BackgroundMusic = GameObject.Find("Main Camera");
            AudioSource backmusic = BackgroundMusic.GetComponent<AudioSource>(); //배경음악 저장해둠
            backmusic.Stop();
            normal_bgm.SetActive(true);
            bgimg.SetActive(true);
            img3.SetActive(true);
            Image spr = img3.GetComponent<Image>();
            Color color = spr.color;
            for (int i = 0; i < 11; i++)
            {
                float f = i / 10.0f;
                color.a = f;
                spr.color = color;
                yield return new WaitForSeconds(0.1f);
            }
            endText1.SetActive(true);
            endText2.SetActive(true);
            yield return StartCoroutine(Endchat1("노말 엔딩 1", 1));
            yield return StartCoroutine(Endchat2("부제 : 큰 돈을 벌꺼야!", 1));
            finish_end = true;
        }
        if (root_num == 1 && ch_num == 2)
        {
            yield return StartCoroutine(Normalchat("예전부터... 라면, 제 비밀을 알고계시겠군요...", chat_delay_time));
            chat.SetActive(false);
            chooseText1.text = "당연히 알고있습니다.";
            chooseText2.text = "아... 그거말하는 거죠? 그거.";
            choose.SetActive(true);
            root_num = 2;
        }
        choose_num++;
    }

    IEnumerator TextPratice4()
    {
        if (root_num == 1)
        {
            yield return StartCoroutine(Normalchat("오늘부터 1일이예요!", chat_delay_time));
            GameObject BackgroundMusic = GameObject.Find("Main Camera");
            AudioSource backmusic = BackgroundMusic.GetComponent<AudioSource>(); //배경음악 저장해둠
            backmusic.Stop();
            happy_bgm.SetActive(true);
            bgimg.SetActive(true);
            img1.SetActive(true);
            Image spr = img1.GetComponent<Image>();
            Color color = spr.color;
            for (int i = 0; i < 11; i++)
            {
                float f = i / 10.0f;
                color.a = f;
                spr.color = color;
                yield return new WaitForSeconds(0.1f);
            }
            endText1.SetActive(true);
            endText2.SetActive(true);
            yield return StartCoroutine(Endchat1("해피 엔딩", 1));
            yield return StartCoroutine(Endchat2("부제 : 돈과 사랑, 두 마리의 토끼를 잡고야 만다", 1));
            finish_end = true;
        }
        if (root_num == 2)
        {
            yield return StartCoroutine(Normalchat("잠시, 눈을 감아주세요.", chat_delay_time));
            Image spr = bgimg.GetComponent<Image>();
            Color color = spr.color;
            color.a = 0.0f;
            spr.color = color;
            bgimg.SetActive(true);
            for (int i = 0; i < 11; i++)
            {
                float f = i / 10.0f;
                color.a = f;
                spr.color = color;
                yield return new WaitForSeconds(0.1f);
            }
            yield return new WaitForSeconds(2f);
            ornalprin.SetActive(false);
            changeprin.SetActive(true);
            for (int i = 0; i < 11; i++)
            {
                float f = i / 10.0f;
                color.a = 1 - f;
                spr.color = color;
                yield return new WaitForSeconds(0.1f);
            }
            color.a = 1.0f;
            spr.color = color;
            bgimg.SetActive(false);
            yield return StartCoroutine(Normalchat("왕자: 그래요, 저는 원래 남자였어요. 잠시 여장을 하고 있었을 뿐...", chat_delay_time));
            chat.SetActive(false);
            chooseText1.text = "?";
            chooseText2.text = "??";
            choose.SetActive(true);
            root_num = 3;
        }
        choose_num++;
    }

    IEnumerator TextPratice5()
    {
        if (root_num == 3)
        {
            yield return StartCoroutine(Normalchat("이야기는 제가 용에게 잡혀가고 이틀 뒤... ", chat_delay_time));
            yield return StartCoroutine(Normalchat("아버지께선 왕자가 용에 잡혀가서 구해 올 기사를 모집하셨죠.", chat_delay_time));
            yield return StartCoroutine(Normalchat("하지만 왕자가 잡혀갔다는 사실에 기사들은 아무도 나서지 않았어요...", chat_delay_time));
            yield return StartCoroutine(Normalchat("그 사실에 아버지는 한가지 묘책을 생각해냈죠.", chat_delay_time));
            yield return StartCoroutine(Normalchat("사실 잡혀간 건 왕자가 아니라 공주라는 이야기를 말이죠.", chat_delay_time));
            yield return StartCoroutine(Normalchat("그러자 놀랍게도, 공주가 잡혀갔다는 소식을 듣자마자 수백명의 기사들이 절 구하러 왔어요.", chat_delay_time));
            yield return StartCoroutine(Normalchat("전 그들을 위해서라도 성안에 놓여있던 드레스를 입고 있었죠.", chat_delay_time));
            yield return StartCoroutine(Normalchat("하지만 당신은 제 비밀을 다 알고도 왔군요...!", chat_delay_time));
            yield return StartCoroutine(Normalchat("기뻐요. 저 역시 당신을 사랑하고 있어요!", chat_delay_time));
            chat.SetActive(false);
            chooseText1.text = "저 또한... 진실을 말하는 모습에 다시금 반했습니다!";
            chooseText2.text = "이런 미친...! 꺼져!";
            choose.SetActive(true);
            root_num = 4;
        }
        choose_num++;
    }

    IEnumerator TextPratice6()
    {
        if (root_num == 4 && ch_num == 1)
        {
            yield return StartCoroutine(Normalchat("기, 기사님...", chat_delay_time));
            chat.SetActive(false);
            chooseText1.text = "공주... 아니, 왕자님...";
            chooseText2.text = "사랑합니다.";
            choose.SetActive(true);
            root_num = 5;
        }
        if (root_num == 4 && ch_num == 2)
        {
            yield return StartCoroutine(Normalchat("기,기사님 왜 그러시죠? 다 알고있는거 아니였나요?", chat_delay_time));
            yield return StartCoroutine(Normalchat("예전부터 절 좋아했다면서요!", chat_delay_time));
            chat.SetActive(false);
            chooseText1.text = "그건 거짓말이였어요. 전.... 당신이 공주인 줄 알았습니다.";
            chooseText2.text = "어떻게 날 속일 수 있어! 꺼져버려!";
            choose.SetActive(true);
            root_num = 6;
        }
        choose_num++;
    }

    IEnumerator TextPratice7()
    {
        if (root_num == 5)
        {
            GameObject BackgroundMusic = GameObject.Find("Main Camera");
            AudioSource backmusic = BackgroundMusic.GetComponent<AudioSource>(); //배경음악 저장해둠
            backmusic.Stop();
            happy_bgm.SetActive(true);
            bgimg.SetActive(true);
            img2.SetActive(true);
            Image spr = img2.GetComponent<Image>();
            Color color = spr.color;
            for (int i = 0; i < 11; i++)
            {
                float f = i / 10.0f;
                color.a = f;
                spr.color = color;
                yield return new WaitForSeconds(0.1f);
            }
            endText1.SetActive(true);
            endText2.SetActive(true);
            yield return StartCoroutine(Endchat1("해피? 엔딩", 1));
            yield return StartCoroutine(Endchat2("부제 : 너... 그런 취향이였니...?", 1));
            finish_end = true;
        }
        if (root_num == 6 && ch_num == 1)
        {
            yield return StartCoroutine(Normalchat("절 위해 거짓말을 하신거군요...", chat_delay_time));
            yield return StartCoroutine(Normalchat("이해했습니다. 그럼... 저와 친구라도 되어줄 수 없습니까?", chat_delay_time));
            chat.SetActive(false);
            chooseText1.text = "제 인맥이 되어주는 건가요?";
            chooseText2.text = "친구 정도면... 좋습니다.";
            choose.SetActive(true);
            root_num = 7;
        }
        if (root_num == 6 && ch_num == 2)
        {
            changeprin.SetActive(false);
            angleprin.SetActive(true);
            yield return StartCoroutine(Normalchat("무슨 소리...! 절 속인건 당신이 아닌가요?", chat_delay_time));
            yield return StartCoroutine(Normalchat("예전부터 라더니, 그저 입에 발린 말이였군요! 무례합니다!", chat_delay_time));
            chat.SetActive(false);
            chooseText1.text = "무례한 건 너의 복장이였지!";
            chooseText2.text = "이럴 줄 알았다면 구하러 오지 않는 건데!";
            choose.SetActive(true);
            root_num = 8;
        }
        choose_num++;
    }

    IEnumerator TextPratice8()
    {
        if (root_num == 7)
        {
            yield return StartCoroutine(Normalchat("그래요, 고마워요. ", chat_delay_time));
            yield return StartCoroutine(Normalchat("제 왕성으로 돌아가도록 하죠.", chat_delay_time));
            GameObject BackgroundMusic = GameObject.Find("Main Camera");
            AudioSource backmusic = BackgroundMusic.GetComponent<AudioSource>(); //배경음악 저장해둠
            backmusic.Stop();
            normal_bgm.SetActive(true);
            bgimg.SetActive(true);
            img4.SetActive(true);
            Image spr = img4.GetComponent<Image>();
            Color color = spr.color;
            for (int i = 0; i < 11; i++)
            {
                float f = i / 10.0f;
                color.a = f;
                spr.color = color;
                yield return new WaitForSeconds(0.1f);
            }
            endText1.SetActive(true);
            endText2.SetActive(true);
            yield return StartCoroutine(Endchat1("노말 엔딩 2", 1));
            yield return StartCoroutine(Endchat2("부제 : 이 인맥으로 기사단장이 될거야.", 1));
            finish_end = true;
        }
        if (root_num == 8)
        {
            yield return StartCoroutine(Normalchat("이 얼마나 어리석은 말인지...!", chat_delay_time));
            yield return StartCoroutine(Normalchat("그 말에 책임을 져야 할겁니다 기사.", chat_delay_time));
            GameObject BackgroundMusic = GameObject.Find("Main Camera");
            AudioSource backmusic = BackgroundMusic.GetComponent<AudioSource>(); //배경음악 저장해둠
            backmusic.Stop();
            sad_bgm.SetActive(true);
            bgimg.SetActive(true);
            img5.SetActive(true);
            Image spr = img5.GetComponent<Image>();
            Color color = spr.color;
            for (int i = 0; i < 11; i++)
            {
                float f = i / 10.0f;
                color.a = f;
                spr.color = color;
                yield return new WaitForSeconds(0.1f);
            }
            endText1.SetActive(true);
            endText2.SetActive(true);
            yield return StartCoroutine(Endchat1("새드 엔딩", 1));
            yield return StartCoroutine(Endchat2("부제 : 자나 깨나 왕족에게는 말조심", 1));
            finish_end = true;
        }
        choose_num++;
    }
    
}
