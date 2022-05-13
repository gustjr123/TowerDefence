using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class KillCounter : MonoBehaviour
{
    public Text counterText;
    int kills;
    private GameObject target;
    int endCondition = 0;

    [Header("ImageManager")]
    [SerializeField] private GameObject ImageManager;
    [SerializeField] private GameObject RightHandImage;
    [SerializeField] private GameObject LeftHandImage;

    private int nowPaze;
    private int MaxPaze;

    /*
    [Header("Description UI")]
    [SerializeField] private Text description;
    */
    [Header("Give Data")]
    [SerializeField] private GameObject PauseManager;

    [System.NonSerialized] public Hands RightHandData;
    [System.NonSerialized] public Hands LeftHandData;

    private List<bool> IsPaze;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ShowKills();

        if (kills >= 3)
        {
            nowPaze = 1;
            ImageManager.GetComponent<ImageManager>().ImageSet(Hands.Shoot);
            PauseManager.GetComponent<Pause>().PauseGame();
            if (RightHandData == Hands.Shoot)
            {
                PauseManager.GetComponent<Pause>().NonPause();
                Debug.Log("1PazeIncounter");
                ImageManager.GetComponent<ImageManager>().ImageSuccess();
                StartCoroutine(WaitSecnd());
                ImageManager.GetComponent<ImageManager>().ImageSet(Hands.Shoot);
                Debug.Log("1PazeEnd");
                PauseManager.GetComponent<Pause>().PauseGame();
                nowPaze++;


                if (nowPaze == 2)
                {
                    if (LeftHandData == Hands.Shoot)
                    {
                        PauseManager.GetComponent<Pause>().NonPause();
                        Debug.Log("2PazeIncounter");
                        ImageManager.GetComponent<ImageManager>().ImageSuccess();
                        StartCoroutine(WaitSecnd());
                        ImageManager.GetComponent<ImageManager>().ImageSet(Hands.Two);
                        nowPaze++;
                        Debug.Log("2PazeEnd");
                        PauseManager.GetComponent<Pause>().PauseGame();
                    }


                    if (nowPaze == 3)
                    {
                        if (LeftHandData == Hands.Two)
                        {
                            PauseManager.GetComponent<Pause>().NonPause();
                            Debug.Log("3PazeIncounter");
                            ImageManager.GetComponent<ImageManager>().ImageSuccess();
                            StartCoroutine(WaitSecnd());
                            ImageManager.GetComponent<ImageManager>().ImageSet(Hands.Peace);
                            nowPaze++;
                            Debug.Log("3PazeEnd");
                            PauseManager.GetComponent<Pause>().PauseGame();
                        }

                        if (nowPaze == 4)
                        {
                            if (RightHandData == Hands.Peace)
                            {
                                PauseManager.GetComponent<Pause>().NonPause();
                                IsPaze[nowPaze] = true;
                                nowPaze++;
                                RightHandImage.GetComponent<ImageManager>().ImageSuccess();
                                StartCoroutine(WaitSecnd());
                                PauseManager.GetComponent<Pause>().PauseGame();
                            }
                        }
                    }
                }
            }
        }
    }


    private void ShowKills()
    {
        counterText.text = kills.ToString();
    }

    public void AddKill()
    {
        kills += 1;
    }

    #region 각 페이즈 함수

    void secondPaze()
    {
        LeftHandImage.GetComponent<ImageManager>().ImageSet(Hands.Shoot);
    }

    void thirdPaze()
    {
        LeftHandImage.GetComponent<ImageManager>().ImageSet(Hands.Two);
    }

    void fourthPaze()
    {
        RightHandImage.GetComponent<ImageManager>().RightImageSet(Hands.Peace);
    }
    #endregion




    #region Input Hands Gesture
    public void RightHandInput(int data)
    {
        // enum Hands { Gun, Shoot, Good, Boom, Two, Three, Four, Five, Peace, Temp }
        switch (data)
        {
            case 0: RightHandData = Hands.Gun; break;
            case 1: RightHandData = Hands.Shoot; break;
            case 2: RightHandData = Hands.Good; break;
            case 3: RightHandData = Hands.Calling; break;
            case 4: RightHandData = Hands.Two; break;
            case 5: RightHandData = Hands.Three; break;
            case 6: RightHandData = Hands.Four; break;
            case 7: RightHandData = Hands.Five; break;
            case 8: RightHandData = Hands.Peace; break;
            case 9: RightHandData = Hands.Temp; break;
        }
    }

    public void LeftHandInput(int data)
    {
        // enum Hands { Gun, Shoot, Good, Boom, Two, Three, Four, Five, Peace, Temp }
        switch (data)
        {
            case 0: LeftHandData = Hands.Gun; break;
            case 1: LeftHandData = Hands.Shoot; break;
            case 2: LeftHandData = Hands.Good; break;
            case 3: LeftHandData = Hands.Calling; break;
            case 4: LeftHandData = Hands.Two; break;
            case 5: LeftHandData = Hands.Three; break;
            case 6: LeftHandData = Hands.Four; break;
            case 7: LeftHandData = Hands.Five; break;
            case 8: LeftHandData = Hands.Peace; break;
            case 9: LeftHandData = Hands.Temp; break;
        }
    }
    #endregion

    private IEnumerator WaitSecnd()
    {
        yield return new WaitForSeconds(1f);
    }
}