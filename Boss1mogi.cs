using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1mogi : MonoBehaviour
{
    public GameObject player;
    Rigidbody2D rigid;
    int num1, num2, num3;
    Vector3 target;
    Vector3 chp;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        num1 = Random.Range(0, 3);
        num2 = Random.Range(0, 3);
        num3 = Random.Range(0, 3);
        target = GameObject.FindWithTag("Player").transform.position;
        Vector3 chp2 = new Vector3(transform.position.x + num1, transform.position.y + num2, transform.position.z + num3);
        chp = new Vector3(-8, 3, transform.position.z + num3);
    }

    // Update is called once per frame
    void Update()
    {
        //rigid.AddForce(new Vector2(-num1, num2), ForceMode2D.Impulse);
        //transform.position = Vector3.Lerp(transform.position, chp, 0.05f);
        transform.position = Vector3.MoveTowards(transform.position, chp, 0.1f);
        if (Vector3.Distance(chp, transform.position) < 1)
        {
            StartCoroutine("CountTime", 0.2);
        }
        transform.Rotate(new Vector3(0, 0, 90f) * Time.deltaTime);
    }

    IEnumerator CountTime(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
            Destroy(gameObject);
    }
}
