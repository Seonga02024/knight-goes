using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class goalManager : MonoBehaviour
{
    public int nextgoal;
    public Image save;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("saveM");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator saveM()
    {
        save.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        save.gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GameObject.Find("keys").GetComponent<keyManager>().kcount == 3)
            SceneManager.LoadScene(nextgoal);
        Debug.Log("goal");
    }
}
