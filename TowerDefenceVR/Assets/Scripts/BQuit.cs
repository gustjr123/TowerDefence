using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BQuit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void onClickExit()
    {
        Application.Quit();
        Debug.Log("Q Button Click");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
