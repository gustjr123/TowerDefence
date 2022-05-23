using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelScript1 : MonoBehaviour
{
    public GameObject Panel1;
    public GameObject Panel2;
    public GameObject Panel3;
    public GameObject Panel4;
    public GameObject Panel5;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("CreatePanel");
    }

    IEnumerator CreatePanel()
    {
        while (Application.isPlaying)
        {
            float createTime = 4.8f;
            yield return new WaitForSeconds(createTime);
            print("패널 생성");
            Instantiate(Panel1, transform.position, Quaternion.identity);
            //Destroy(Panel1, 0.3f);
        }
    }
}
