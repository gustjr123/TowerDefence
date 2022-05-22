using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCAreaController : MonoBehaviour
{
    public Text dialogText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        print(other.gameObject.tag);
        if (other.gameObject.tag == "Player")
        {
            GameObject panel = GameObject.FindWithTag("Canvas").transform.Find("DialogPanel").gameObject;
            if (panel == null)
            {
                return;
            }

            panel.SetActive(true);
        };
    }

    public void PannelDie()
    {
        GameObject panel = GameObject.FindWithTag("Canvas").transform.Find("DialogPanel").gameObject;
        panel.SetActive(false);
    }
}