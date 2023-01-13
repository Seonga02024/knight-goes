using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clound : MonoBehaviour
{
    Vector3 firstP;
    public float speed = 0.2f;
    int a = 1;

    // Start is called before the first frame update
    void Start()
    {
        firstP = transform.position;
    }

    private void Update()
    {
        if (firstP.y + 0.5f < transform.position.y)
        {
            a = -1;
        }
        else if (firstP.y - 0.5f > transform.position.y)
        {
            a = 1;
        }
        transform.Translate(Vector3.up * 1.0f * Time.deltaTime * a * speed);
    }
}
