using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minicat : MonoBehaviour
{
    private float time;
    private float realtime;
    Vector3 firstP;
    int a = 1;

    // Start is called before the first frame update
    void Start()
    {
        firstP = transform.position;
    }

    // Update is called once per frame
    void Update()
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
}
