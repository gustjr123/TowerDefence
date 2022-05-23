using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slimeDialog : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(2 * transform.position - GameObject.Find("OVRCameraRig").transform.position);
    }
}
