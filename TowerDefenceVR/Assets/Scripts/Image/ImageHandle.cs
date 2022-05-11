using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageHandle : MonoBehaviour
{
    [SerializeField] private Material red;
    [SerializeField] private Material green;
    [SerializeField] private GameObject imageWindow;
    /*
    0 : Gun
    1 : Shoot
    2 : Good
    3 : Calling
    4 : Two
    5 : Three
    6 : Four
    7 : Five
    8 : Peace
    */
    [SerializeField] private Sprite[] images;
    [SerializeField] private bool isRight;
    private Image nowimage;
    
    

    // Start is called before the first frame update
    void Start()
    {
        nowimage = imageWindow.GetComponent<Image>();
        if (isRight) {
            transform.LookAt(2 * transform.position - GameObject.Find("OVRCameraRig").transform.position);
            // transform.rotation = Quaternion.LookRotation(transform.position - GameObject.Find("OVRCameraRig").transform.position);
        }
        else {
            transform.LookAt(GameObject.Find("OVRCameraRig").transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectImage(Hands hand) {
        // find the image Object
        Image[] img = gameObject.GetComponentsInChildren<Image>();
        Image face = img[0];
        foreach (Image i in img)
        {
            if (i.gameObject.CompareTag("Hand"))
                face = i;
        }
        
        // input image to Object
        face.sprite = images[((int)hand)];
    }

    public void Success() {
        gameObject.GetComponent<MeshRenderer>().material = green;
    }
}
