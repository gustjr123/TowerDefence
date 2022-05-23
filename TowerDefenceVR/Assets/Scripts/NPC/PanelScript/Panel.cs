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
    [SerializeField] private GameObject SlimeGuide;

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
            Vector3 v = new Vector3(SlimeGuide.transform.position.x, SlimeGuide.transform.position.y+2, SlimeGuide.transform.position.z);
            GameObject Dialog = Instantiate(Panel1, v, Quaternion.identity);
            print("�г� ����");
            Panel1.SetActive(true);
            Destroy(Dialog, 0.2f);
        }

        if (currTime > 9.95 && currTime < 10)
        {
            Vector3 v = new Vector3(SlimeGuide.transform.position.x, SlimeGuide.transform.position.y+2, SlimeGuide.transform.position.z);
            GameObject Dialog2 = Instantiate(Panel2, v, Quaternion.identity);
            print("�г� ����");
            Panel1.SetActive(true);
            Destroy(Dialog2, 0.2f);
        }

        if (currTime > 14.95 && currTime < 15)
        {
            Vector3 v = new Vector3(SlimeGuide.transform.position.x, SlimeGuide.transform.position.y+2, SlimeGuide.transform.position.z);
            GameObject Dialog3 = Instantiate(Panel3, v, Quaternion.identity);
            print("�г� ����");
            Panel3.SetActive(true);
            Destroy(Dialog3, 0.2f);
        }

        if (currTime > 19.95 && currTime <20)
        {
            Vector3 v = new Vector3(SlimeGuide.transform.position.x, SlimeGuide.transform.position.y+2, SlimeGuide.transform.position.z);
            GameObject Dialog4 = Instantiate(Panel4, v, Quaternion.identity);
            print("�г� ����");
            Panel4.SetActive(true);
            Destroy(Dialog4, 0.2f);
        }

        if (currTime > 24.95 && currTime < 25)
        {
            Vector3 v = new Vector3(SlimeGuide.transform.position.x, SlimeGuide.transform.position.y+2, SlimeGuide.transform.position.z);
            GameObject Dialog5 = Instantiate(Panel5, v, Quaternion.identity);
            print("�г� ����");
            Panel5.SetActive(true);
            Destroy(Dialog5, 0.2f);
        }
    }
}