using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float maxSpeed;
    Rigidbody2D rigid;
    bool isjumping; // 현재 점프중인지 참, 거짓 값을 가지는 bool형 변수
    public float jumpPower = 16.0f; //플레이어 점프 힘
    int jumpcount = 0;
    int diecount = 0;
    public Animator anim;
    public SpriteRenderer rend;
    public int clearStage = 0;
    int nextgoal = 0;
    public int hiteCount = 3;

    void Awake()
    {
        rend = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        anim.SetBool("KeyButtonDown", false);
        rigid = GetComponent<Rigidbody2D>();
        rigid.freezeRotation = true;
    }

    // 키보드에서 손을 뗐을 때 완전 stop 
    private void Update() //즉각적인 키 입력 ,단발적인 키 입력
    {
        if (Input.GetButtonDown("Jump")) //점프 키가 눌렸을 때
        {
            anim.SetBool("SpaceButtonDown", true);
            if (jumpcount < 2) //점프 중이지 않을 때 isjumping == false
            {
                GameObject bgmMusic = GameObject.Find("jump");
                AudioSource music = bgmMusic.GetComponent<AudioSource>();
                music.Play();
                rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse); //위쪽으로 힘을 준다.
                jumpcount++;
            }
            //anim.SetBool("SpaceButtonDown", false);
        }
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.x < 0f) pos.x = 0f;
        if (pos.x > 1f) pos.x = 1f;
        if (pos.y < 0f) pos.y = 0f;
        if (pos.y > 1f) pos.y = 1f;
        transform.position = Camera.main.ViewportToWorldPoint(pos);
        if (GameObject.Find("hites").GetComponent<HpManager>().hpcount == 0) 
        {
            maxSpeed = 0;
            anim.SetBool("ConditionDie", true);
            //GameObject bgmMusic = GameObject.Find("diebgm");
            //AudioSource music = bgmMusic.GetComponent<AudioSource>();
            //music.Play();
        }
    }

    void FixedUpdate() //지속적인 키 입력
    {
        float h = Input.GetAxisRaw("Horizontal");
        //rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);
        if (h == 0)
        {
            anim.SetBool("KeyButtonDown", false);
        }
        else
        {
            anim.SetBool("KeyButtonDown", true);
        }
        Vector3 moveVelocity = Vector3.zero;
        if(Input.GetAxisRaw("Horizontal") < 0) //왼쪽
        {
            rend.flipX = false;
            moveVelocity = Vector3.left;
        }
        else if (Input.GetAxisRaw("Horizontal") > 0) //오른쪽
        {
            rend.flipX = true;
            moveVelocity = Vector3.right;
        }
        transform.position += moveVelocity * maxSpeed * Time.deltaTime;

        if (Input.GetKey("i"))
        {
            anim.SetBool("ConditionDie", true);
        }
        if (Input.GetKey("o"))
        {
            anim.SetBool("ConditionDie", false);
            //transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        }
        if (Input.GetKeyDown("p"))
        {
            GameObject.Find("hites").GetComponent<HpManager>().MinusHp();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            anim.SetBool("SpaceButtonDown", false);
            jumpcount = 0;
            //float yPosition = transform.position.y - collision.transform.position.y;
            //float coll_he = (collision.gameObject.GetComponent<RectTransform>().rect.height/2);
            //Debug.Log("coll_he : " + coll_he + " yPosition : " + yPosition);
            //if (yPosition >= coll_he)
            //    maxSpeed = 3;
            //else
            //    maxSpeed = 0;
        }

        //if (collision.gameObject.CompareTag("weapon"))
        //{
        //    GameObject.Find("hites").GetComponent<HpManager>().MinusHp();
        //    StartCoroutine("sickSitulation");
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("key"))
        {
            GameObject.Find("keys").GetComponent<keyManager>().GetKey();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("block"))
        {
            GameObject.Find("hites").GetComponent<HpManager>().MinusHp();
            StartCoroutine("sickSitulation");
        }

        if (collision.gameObject.CompareTag("weapon"))
        {
            GameObject.Find("hites").GetComponent<HpManager>().MinusHp();
            StartCoroutine("sickSitulation");
        }

        //if (collision.gameObject.CompareTag("goal"))
        //{
        //    SceneManager.LoadScene(3);
        //    Debug.Log("goal");
        //}
    }

    IEnumerator sickSitulation()
    {
        //if(GameObject.Find("hites").GetComponent<HpManager>().hpcount > 0)
        //{
        //    GameObject bgmMusic = GameObject.Find("damge");
        //    AudioSource music = bgmMusic.GetComponent<AudioSource>();
        //    music.Play();
        //}
        SpriteRenderer spr = GetComponent<SpriteRenderer>();
        Color color = spr.color;
        color.a = 0.5f;
        spr.color = color;
        yield return new WaitForSeconds(0.2f);
        color.a = 1f;
        spr.color = color;
        yield return new WaitForSeconds(0.2f);
        color.a = 0.5f;
        spr.color = color;
        yield return new WaitForSeconds(0.2f);
        color.a = 1f;
        spr.color = color;
        yield return new WaitForSeconds(0.2f);
    }

    public void saveStage()
    {
        if (null != GameObject.Find("goal"))
        {
            nextgoal = GameObject.Find("goal").GetComponent<goalManager>().nextgoal;
        }
        if (null != GameObject.Find("GameObject"))
        {
            nextgoal = GameObject.Find("GameObject").GetComponent<TimerManager>().nextgoal;
        }
        PlayerPrefs.SetInt("saveStage", nextgoal-1);
    }
}
