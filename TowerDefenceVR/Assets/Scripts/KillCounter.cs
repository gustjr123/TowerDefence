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
    private TimeManager TimeManager = new TimeManager();

    private bool IsEnd = false;

    // for ending as calculate tip distance
    [Header("fingerTip Object of OVRCamera")]
    [SerializeField] private GameObject lefttip;
    [SerializeField] private GameObject righttip;
    [SerializeField] private GameObject leftthump;
    [SerializeField] private GameObject rightthump;
    // calculation rate time 
    private float timeTo = 0f;
    [SerializeField] private GameObject ClearImage;
    [SerializeField] private GameObject ImageCanvas;

    private void Awake() {
        readyImage = false;
        MaxPaze = 4;
        DataReset();
    }
    void Start()
    {
        
    }

    private bool tipDistance() {
        if (Time.time >= timeTo){
            Vector3 v1 = gameObject.transform.InverseTransformPoint(lefttip.transform.position);
            Vector3 v2 = gameObject.transform.InverseTransformPoint(righttip.transform.position);

            float one = Vector3.Distance(v1, v2);

            v1 = gameObject.transform.InverseTransformPoint(leftthump.transform.position);
            v2 = gameObject.transform.InverseTransformPoint(rightthump.transform.position);

            float two = Vector3.Distance(v1, v2);
            if (one <= 0.015f && two <= 0.015f) {
                return true;
            }
            // calculation rate
            timeTo = 0.5f + Time.time;
        }
        return false;
    }

    private bool ImageCheckPerPaze() {
        if (isRight) {
            if (nowCurrentHand == RightHandData) {
                PauseManager.GetComponent<Pause>().NonPause();
                //nowPaze++;
                ImageManager.GetComponent<ImageManager>().ImageSSuccess();
                Debug.Log("nowPaze : " + nowPaze.ToString());
                return true;
            }
        }
        else {
            if (nowCurrentHand == LeftHandData) {
                PauseManager.GetComponent<Pause>().NonPause();
                //nowPaze++;
                ImageManager.GetComponent<ImageManager>().ImageSSuccess();
                Debug.Log("nowPaze : " + nowPaze.ToString());  
                return true;              
            }
        }
        return false;
    }

    private void ImageEventStart() {
        PauseManager.GetComponent<Pause>().PauseGame();
        readyImage = false;
        PazeFunc();
        IsPaze[nowPaze] = !IsPaze[nowPaze];
    }

    // Update is called once per frame
    void Update()
    {
        ShowKills();
        // 킬수로 하나, 시간으로 하나 조건을 맞춰주면 됨
        if (TimeManager.Minute >= 15 && nowPaze == 0) {
        // if (kills >= 5 && nowPaze == 0) {
            if (!IsPaze[nowPaze]) {
                ImageEventStart();
            }
            // readyImage is Handled by ImageManager. It's set to true when ImageManager completely created ImagePrefab.
            else if (readyImage) {
                if (ImageCheckPerPaze()) {
                    ShieldEvent.GetComponent<ShieldEvent>().OnShield1();
                    nowPaze = 1;
                }
            }
        }
        if (TimeManager.Minute >= 30 && nowPaze == 1) {
        // if (kills >= 10 && nowPaze == 1) {
            if (!IsPaze[nowPaze]) {
                ImageEventStart();
            }
            else if (readyImage) {
                if (ImageCheckPerPaze()) {
                    ShieldEvent.GetComponent<ShieldEvent>().OnShield2();
                    nowPaze = 2;
                }
            }
        }
        if (TimeManager.Minute >= 45 && nowPaze == 2) {
        // if (kills >= 15 && nowPaze == 2) {
            if (!IsPaze[nowPaze]) {
                ImageEventStart();
            }
            else if (readyImage) {
                if (ImageCheckPerPaze()) {
                    ShieldEvent.GetComponent<ShieldEvent>().OnShield3();
                    nowPaze = 3;
                }
            }
        }
        if (TimeManager.Hour >= 1 && nowPaze == 3) {
        // if (kills >= 20 && nowPaze == 3) {
            if (!IsPaze[nowPaze]) {
                ImageEventStart();
            }
            else if (readyImage) {
                if (ImageCheckPerPaze()) {
                    ShieldEvent.GetComponent<ShieldEvent>().OnShield4();
                    ShieldEvent.GetComponent<ShieldEvent>().OnShieldTower();
                    ClearImage.GetComponent<Renderer>().enabled = true;
                    ImageCanvas.GetComponent<Canvas>().enabled = true;
                    nowPaze = 4;
                }
            }
        }
        // ending
        if (TimeManager.Hour >= 1 && nowPaze == 4 && LeftHandData == Hands.Circle && RightHandData == Hands.Circle) {
        // if (kills >= 20 && nowPaze == 4) {
            if (tipDistance()) {
                Debug.Log("Last Paze");
                PauseManager.GetComponent<Pause>().NonPause();
                StartCoroutine(FinalEndingPaze());
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
        // enum Hands { Gun, Shoot, Good, Boom, Two, Three, Four, Five, Peace, Temp, Circle }
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
            case 10: RightHandData = Hands.Circle; break;
        }
    }

    public void LeftHandInput(int data)
    {
        // enum Hands { Gun, Shoot, Good, Boom, Two, Three, Four, Five, Peace, Temp, Circle }
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
            case 10: LeftHandData = Hands.Circle; break;
        }
    }
    #endregion

    private IEnumerator FinalEndingPaze()
    {
        IsEnd = false;
        yield return new WaitForSeconds(2f);
        DataReset();
        ImageManager.GetComponent<ImageManager>().Reset();

        // GameClear and Clear Impact open
        SceneManager.LoadScene("resultClear");
    }

    private void DataReset() {
        kills = 0;
        RightHandData = Hands.Temp;
        nowPaze = 0;
        IsPaze = new List<bool>(MaxPaze);
        for (int i=0; i<MaxPaze; i++) {
            IsPaze.Add(false);
        }
        
        ClearImage.GetComponent<Renderer>().enabled = false;
        ImageCanvas.GetComponent<Canvas>().enabled = false;
    }
}