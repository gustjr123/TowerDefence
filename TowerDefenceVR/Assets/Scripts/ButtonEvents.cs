using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonEvents : MonoBehaviour
{
    [SerializeField] private Text detail;
    [SerializeField] private GameObject ButtonSet;
    [SerializeField] private GameObject Label;
    private bool isActivate = true;

    private void Start() {
        isActivate = false;
        ButtonSet.SetActive(false);
    }

    // Start is called before the first frame update
    public void gameStart()
    {
        SceneManager.LoadScene("main");
    }

    public void onClickExit()
    {
        Application.Quit();
    }

    public void onInfo() 
    {
        detail.text = "made by Team BigBrother";
    }

    public void onToggleButtonSet() 
    {
        if (isActivate) 
        {
            ButtonSet.SetActive(false);
            Label.GetComponent<TextMesh>().text = "Off";
            isActivate = !isActivate;
        }
        else 
        {
            ButtonSet.SetActive(true);
            Label.GetComponent<TextMesh>().text = "On";
            isActivate = !isActivate;
        }
    }
}
