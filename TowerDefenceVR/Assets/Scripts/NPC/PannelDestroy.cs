using UnityEngine;
using System.Collections;

public class PannelDestroy : MonoBehaviour
{

    public float DestroyTime = 1.0f;
    void Start()
    {
        Destroy(gameObject, DestroyTime);
    }
}
