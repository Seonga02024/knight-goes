using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss1 : MonoBehaviour
{
    private float time;
    private float realtime;
    public GameObject mogi1;
    public GameObject mogi2;
    Vector3 firstP;
    int a = 1;
    int attacks_num = 0;

    public GameObject[] attacks = new GameObject[10];

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("CountTime", 3);
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

    IEnumerator CountTime(float delayTime)
    {
        if(realtime != 30)
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

//if(realtime%2 == 0)
//    Instantiate(mogi1, transform.position, Quaternion.identity);
//else
//    Instantiate(mogi2, transform.position, Quaternion.identity);