using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempCreate : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    private GameObject Temp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreatePrefab() {
        Temp = Instantiate(enemy, gameObject.transform.position, gameObject.transform.rotation);
    }
}
