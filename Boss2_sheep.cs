using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2_sheep : MonoBehaviour
{
    private float time;
    private float realtime;
    public float delaytime;
    Vector3 firstP;
    int a = 1;
    int attacks_num = 0;
    public GameObject[] attacks = new GameObject[10];

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("CountTime");
        firstP = transform.position;
    }

    private void Update()
    {
        time += Time.deltaTime;
        realtime = 30 - time;

        if (firstP.x + 2 < transform.position.x)
        {
            a = 1;
        }
        else if (firstP.x - 2 > transform.position.x)
        {
            a = -1;
        }
        transform.Translate(Vector3.left * 1.0f * Time.deltaTime * a);
    }

    IEnumerator CountTime()
    {
        if(attacks_num == 0)
        {
            attacks[attacks_num].SetActive(true);
            yield return new WaitForSeconds(1);
            attacks[attacks_num].GetComponent<BoxCollider2D>().enabled = true;
            yield return new WaitForSeconds(1.5f);
            Destroy(attacks[attacks_num]);
            attacks_num++;
        }
        if (realtime != 30)
        {
            attacks[attacks_num].SetActive(true);
            yield return new WaitForSeconds(2);
            for(int i = 0; i< attacks[attacks_num].transform.childCount; i++)
            {
                attacks[attacks_num].transform.GetChild(i).GetComponent<BoxCollider2D>().enabled = true;
            }
            yield return new WaitForSeconds(1.2f);
            Destroy(attacks[attacks_num]);
            attacks_num++;
        }
        if (realtime > 0)
        {
            StartCoroutine("CountTime", 3);
        }
    }
}
