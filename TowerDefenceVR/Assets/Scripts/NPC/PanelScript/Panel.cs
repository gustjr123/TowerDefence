using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel : MonoBehaviour
{
    public GameObject Panel1;
    public GameObject Panel2;
    public GameObject Panel3;
    public GameObject Panel4;
    public GameObject Panel5;

    float currTime;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currTime += Time.deltaTime;

        if (currTime > 4.95 && currTime < 5)
        {
            GameObject Dialog = Instantiate(Panel1, transform.position, Quaternion.identity);
            print("鳶確 持失");
            Panel1.SetActive(true);
            Destroy(Dialog, 0.2f);
        }

        if (currTime > 9.95 && currTime < 10)
        {
            GameObject Dialog2 = Instantiate(Panel2, transform.position, Quaternion.identity);
            print("鳶確 持失");
            Panel1.SetActive(true);
            Destroy(Dialog2, 0.2f);
        }

        if (currTime > 14.95 && currTime < 15)
        {
            GameObject Dialog3 = Instantiate(Panel3, transform.position, Quaternion.identity);
            print("鳶確 持失");
            Panel3.SetActive(true);
            Destroy(Dialog3, 0.2f);
        }

        if (currTime > 19.95 && currTime <20)
        {
            GameObject Dialog4 = Instantiate(Panel4, transform.position, Quaternion.identity);
            print("鳶確 持失");
            Panel4.SetActive(true);
            Destroy(Dialog4, 0.2f);
        }

        if (currTime > 24.95 && currTime < 25)
        {
            GameObject Dialog5 = Instantiate(Panel5, transform.position, Quaternion.identity);
            print("鳶確 持失");
            Panel5.SetActive(true);
            Destroy(Dialog5, 0.2f);
        }
    }
}