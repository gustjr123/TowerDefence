using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefabs;

    public void Spawn(int index)
    {
        Instantiate(prefabs, transform.position, transform.rotation);
    }
}