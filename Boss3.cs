using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3 : MonoBehaviour
{
    private float time;
    private float realtime;
    int attacks_num = 0;

    public GameObject[] attacks = new GameObject[10];

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("CountTime", 3);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        realtime = 30 - time;
    }

    IEnumerator CountTime(float delayTime)
    {
        if (realtime != 30)
        {
            attacks[attacks_num].SetActive(true);
            yield return new WaitForSeconds(attacks[attacks_num].GetComponent<oneAttack>().delay);
            Destroy(attacks[attacks_num]);
            attacks_num++;
        }
        if (realtime > 0)
        {
            StartCoroutine("CountTime", 3);
        }
    }
}
