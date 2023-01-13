using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3_attack : MonoBehaviour
{
    private float time;
    private float realtime;
    int attacks_num = 0;

    public GameObject[] attacks = new GameObject[12];

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("CountTime", 3);
    }

    private void Update()
    {
        time += Time.deltaTime;
        realtime = 30 - time;
    }

    IEnumerator CountTime(float delayTime)
    {
        if (realtime != 30)
        {
            attacks[attacks_num].SetActive(true);
            yield return new WaitForSeconds(1);
            for (int i = 0; i < attacks[attacks_num].transform.childCount; i++)
            {
                attacks[attacks_num].transform.GetChild(i).GetComponent<BoxCollider2D>().enabled = true;
            }
            yield return new WaitForSeconds(1);
            for (int i = 0; i < attacks[attacks_num].transform.childCount; i++)
            {
                attacks[attacks_num].transform.GetChild(i).GetComponent<BoxCollider2D>().enabled = false;
            }
            yield return new WaitForSeconds(attacks[attacks_num].GetComponent<oneAttack>().delay -2);
            Destroy(attacks[attacks_num]);
            attacks_num++;
        }
        if (realtime > 0)
        {
            StartCoroutine("CountTime", 3);
        }
    }
}
