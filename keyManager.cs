using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class keyManager : MonoBehaviour
{
    public GameObject k1;
    public GameObject k2;
    public GameObject k3;
    public int kcount;

    // Start is called before the first frame update
    void Start()
    {
        kcount = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GetKey()
    {
        AudioSource bgmmusic = GetComponent<AudioSource>();
        bgmmusic.Play();
        kcount++;
        GetKeyActive();
    }

    public void GetKeyActive()
    {
        if (kcount == 3)
        {
            SpriteRenderer spr = k3.GetComponent<SpriteRenderer>();
            Color color = spr.color;
            color.a = 1f;
            spr.color = color;
        }
        else if (kcount == 2)
        {
            SpriteRenderer spr = k2.GetComponent<SpriteRenderer>();
            Color color = spr.color;
            color.a = 1f;
            spr.color = color;
        }
        else if (kcount == 1)
        {
            SpriteRenderer spr = k1.GetComponent<SpriteRenderer>();
            Color color = spr.color;
            color.a = 1f;
            spr.color = color;
        }
    }
}
