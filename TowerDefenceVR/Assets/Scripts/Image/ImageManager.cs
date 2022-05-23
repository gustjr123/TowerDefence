using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageManager : MonoBehaviour
{
    [Header("Respawn Area")]
    public GameObject rangeObject;
    BoxCollider rangeCollider;
    [SerializeField] private GameObject LeftHandImage;
    [SerializeField] private GameObject RightHandImage;

    private KillCounter KCO;
    private GameObject nowImage;
    private bool isright = false;
    private List<bool> Usedhand;
    
    private void Start() {
        Usedhand = new List<bool>();
        for (int i=0; i<9; i++) {
            Usedhand.Add(false);
        }
        KCO = GameObject.Find("EventManager").GetComponent<KillCounter>();
    }

    // Use for Tutorial
    #region Using at Tutorial
    public void ImageSet(Hands hand) {
        nowImage = Instantiate(LeftHandImage, gameObject.transform.position, gameObject.transform.rotation);
        nowImage.GetComponent<ImageHandle>().SelectImage(hand);
    }

    public void ImageSuccess() {
        if (nowImage != null) {
            nowImage.GetComponent<ImageHandle>().Success();
            Destroy(nowImage, 0.8f);
        }
    }

    public void ImageSSuccess() {
        if (nowImage != null) {
            nowImage.GetComponent<ImageHandle>().Success();
            Destroy(nowImage);
        }
    }

    public void RightImageSet(Hands hand) {
        nowImage = Instantiate(RightHandImage, gameObject.transform.position, gameObject.transform.rotation);
        nowImage.GetComponent<ImageHandle>().SelectImage(hand);
    }
    #endregion
    
    // RandomRespawn에서 사용하는 랜덤위치 생성, using For RandomRespawn Script
    // Use for MainScene
    #region Using at main
    public Hands RandomImage() {
        // StartCoroutine(RandomRespawn_Coroutine());
        // if 0 == RightHand, 1 == LeftHand and Create ImagePrefab
        // GameObject selectObject = (Random.Range(0, 2) == 0) ? RightHandImage : LeftHandImage;
        int temp = Random.Range(0, 2);
        Hands hand;
        // 중복 코드 방지
        while (true) {
            hand = (Hands) Random.Range(0, 9);
            if (!Usedhand[(int) hand]) {
                Usedhand[(int) hand] = true;
                break;
            }
        }
        
        if (temp == 0) {
            nowImage = Instantiate(RightHandImage, Return_RandomPosition(), gameObject.transform.rotation);
            // Random Image Setting 
            // hand = (Hands) Random.Range(0, 9);
            nowImage.GetComponent<ImageHandle>().SelectImage(hand);
            isright = true;
        }
        else {
            nowImage = Instantiate(LeftHandImage, Return_RandomPosition(), gameObject.transform.rotation);
            // Random Image Setting
            // hand = (Hands) Random.Range(0, 9);
            nowImage.GetComponent<ImageHandle>().SelectImage(hand);
            isright = false;
        }
        Debug.Log("Create Image : " + hand.ToString());
        KCO.readyImage = true;
        return hand;
    }
    // if success matching Hand and image, return true
    public bool isRight() {
        return isright;
    }

    public void Reset() {
        for (int i=0; i<9; i++) {
            Usedhand[i] = false;
        }
    }
    Vector3 Return_RandomPosition()
    {
        Vector3 originPosition = rangeObject.transform.position;
        rangeCollider = rangeObject.GetComponent<BoxCollider>();

        float range_X = rangeCollider.bounds.size.x;
        float range_Z = rangeCollider.bounds.size.z;
        range_X = Random.Range((range_X / 2) * -1, range_X / 2);
        range_Z = Random.Range((range_Z / 2) * -1, range_Z / 2);
        Vector3 RandomPostion = new Vector3(range_X, 3f, range_Z);

        Vector3 respawnPosition = originPosition + RandomPostion;
        return respawnPosition;
    }
    #endregion
}


// IEnumerator RandomRespawn_Coroutine()
    // {
    //     for (int i=0; i<4; i++)
    //     {
    //         yield return new WaitForSeconds(0.8f);
            
    //         // if 0 == RightHand, 1 == LeftHand and Create ImagePrefab
    //         GameObject selectObject = (Random.Range(0, 2) == 0) ? RightHandImage : LeftHandImage;
    //         nowImage = Instantiate(selectObject, gameObject.transform.position, gameObject.transform.rotation);
    //         nowimages.Add(nowImage);

    //         // Random Image Setting 
    //         Hands hand = (Hands) Random.Range(0, 10);
    //         nowImage.GetComponent<ImageHandle>().SelectImage(hand);
    //         imageHands.Add(hand);
    //     }
    // }