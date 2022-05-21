using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class KillCounter : MonoBehaviour
{
    public Text counterText;
    static public int kills;

    [Header("RandomImageRespawner")]
    [SerializeField] private GameObject ImageManager;

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

    private bool isRight;
    private List<bool> IsPaze;
    private Hands nowCurrentHand;
    [System.NonSerialized] public bool readyImage;

    [Header("ShieldEvent")]
    [SerializeField] private GameObject ShieldEvent;

    private bool IsEnd = false;

    private void Awake() {
        readyImage = false;
        MaxPaze = 4;
        DataReset();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShowKills();
        
        if(RightHandData == Hands.Four) {
            Debug.Log("Four OK");
        }
        if(LeftHandData == Hands.Four) {
            Debug.Log("LFour OK");
        }
        if (kills >= 10)
        {
            if (nowPaze == 0) {
                PauseManager.GetComponent<Pause>().PauseGame();
                nowPaze = 1;
                readyImage = false;
                PazeFunc();
                Debug.Log("nowPaze : " + nowPaze.ToString());
            }
            
            //if (RightHandData == Hands.Peace)
            // first
            if (nowPaze == 1 && !IsPaze[nowPaze - 1] && readyImage)
            {
                if (isRight) {
                    if (nowCurrentHand == RightHandData) {
                        IsPaze[nowPaze - 1] = true;
                        nowPaze = 2;
                        ImageManager.GetComponent<ImageManager>().ImageSSuccess();
                        readyImage = false;
                        PazeFunc();
                        Debug.Log("nowPaze : " + nowPaze.ToString());
                        ShieldEvent.GetComponent<ShieldEvent>().OnShield1();
                    }
                }
                else {
                    if (nowCurrentHand == LeftHandData) {
                        IsPaze[nowPaze - 1] = true;
                        nowPaze = 2;
                        ImageManager.GetComponent<ImageManager>().ImageSSuccess();
                        readyImage = false;
                        PazeFunc();
                        Debug.Log("nowPaze : " + nowPaze.ToString());
                        ShieldEvent.GetComponent<ShieldEvent>().OnShield1();
                    }
                }
            }
            // second
            if (nowPaze == 2 && !IsPaze[nowPaze - 1] && readyImage)
            {
                if (isRight) {
                    if (nowCurrentHand == RightHandData) {
                        IsPaze[nowPaze - 1] = true;
                        nowPaze = 3;
                        ImageManager.GetComponent<ImageManager>().ImageSSuccess();
                        readyImage = false;
                        PazeFunc();
                        Debug.Log("nowPaze : " + nowPaze.ToString());
                        ShieldEvent.GetComponent<ShieldEvent>().OnShield2();
                    }
                }
                else {
                    if (nowCurrentHand == LeftHandData) {
                        IsPaze[nowPaze - 1] = true;
                        nowPaze = 3;
                        ImageManager.GetComponent<ImageManager>().ImageSSuccess();
                        readyImage = false;
                        PazeFunc();
                        Debug.Log("nowPaze : " + nowPaze.ToString());
                        ShieldEvent.GetComponent<ShieldEvent>().OnShield2();
                    }
                }
            }
            // third
            if (nowPaze == 3 && !IsPaze[nowPaze - 1] && readyImage)
            {
                if (isRight) {
                    if (nowCurrentHand == RightHandData) {
                        IsPaze[nowPaze - 1] = true;
                        nowPaze = 4;
                        ImageManager.GetComponent<ImageManager>().ImageSSuccess();
                        readyImage = false;
                        PazeFunc();
                        Debug.Log("nowPaze : " + nowPaze.ToString());
                        ShieldEvent.GetComponent<ShieldEvent>().OnShield3();
                    }
                }
                else {
                    if (nowCurrentHand == LeftHandData) {
                        IsPaze[nowPaze - 1] = true;
                        nowPaze = 4;
                        ImageManager.GetComponent<ImageManager>().ImageSSuccess();
                        readyImage = false;
                        PazeFunc();
                        Debug.Log("nowPaze : " + nowPaze.ToString());
                        ShieldEvent.GetComponent<ShieldEvent>().OnShield3();
                    }
                }
            }
            // fourth
            if (nowPaze == 4 && !IsPaze[nowPaze - 1] && readyImage)
            {
                if (isRight) {
                    if (nowCurrentHand == RightHandData) {
                        IsPaze[nowPaze - 1] = true;
                        nowPaze = 5;
                        ImageManager.GetComponent<ImageManager>().ImageSSuccess();
                        readyImage = false;
                        Debug.Log("nowPaze : " + nowPaze.ToString());
                        ShieldEvent.GetComponent<ShieldEvent>().OnShield4();
                        ShieldEvent.GetComponent<ShieldEvent>().OnShieldTower();
                        IsEnd = true;
                    }
                }
                else {
                    if (nowCurrentHand == LeftHandData) {
                        IsPaze[nowPaze - 1] = true;
                        nowPaze = 5;
                        ImageManager.GetComponent<ImageManager>().ImageSSuccess();
                        readyImage = false;
                        Debug.Log("nowPaze : " + nowPaze.ToString());
                        ShieldEvent.GetComponent<ShieldEvent>().OnShield4();
                        ShieldEvent.GetComponent<ShieldEvent>().OnShieldTower();
                        IsEnd = true;
                    }
                }
            }

            // Last Paze
            if (nowPaze >= 5 && IsEnd)
            {
                Debug.Log("Last Paze");
                PauseManager.GetComponent<Pause>().NonPause();
                StartCoroutine(FinalEndingPaze());
                // DataReset();
                // ImageManager.GetComponent<ImageManager>().Reset();
                // // GameClear and Clear Impact open
                
                // SceneManager.LoadScene("resultScene");
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
    void PazeFunc() {
        Debug.Log("Image Create : PazeFunc");
        nowCurrentHand = ImageManager.GetComponent<ImageManager>().RandomImage();
        isRight = ImageManager.GetComponent<ImageManager>().isRight();
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

    private IEnumerator FinalEndingPaze()
    {
        IsEnd = false;
        yield return new WaitForSeconds(10f);
        DataReset();
        ImageManager.GetComponent<ImageManager>().Reset();
        // GameClear and Clear Impact open
        
        SceneManager.LoadScene("resultScene");
    }

    private void DataReset() {
        kills = 0;
        RightHandData = Hands.Temp;
        nowPaze = 0;
        IsPaze = new List<bool>(MaxPaze);
        for (int i=0; i<MaxPaze; i++) {
            IsPaze.Add(false);
        }
    }
}
