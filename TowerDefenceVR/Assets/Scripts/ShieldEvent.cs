using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldEvent : MonoBehaviour
{
    [Header("Shield Prefab")]
    [SerializeField] private GameObject Shield_Big;
    
    public void OnShield1() {
        Instantiate(Shield_Big, new Vector3(-17.28f, 1.11f, 14f), gameObject.transform.rotation);
    }
    public void OnShield2() {
        Instantiate(Shield_Big, new Vector3(18.82f, -0.3f, 11.32f), gameObject.transform.rotation);
    }
    public void OnShield3() {
        Instantiate(Shield_Big, new Vector3(-16.52f, -1.98f, 3.06f), gameObject.transform.rotation);
    }
    public void OnShield4() {
        Instantiate(Shield_Big, new Vector3(0.35f, 2.98f, 13.18f), gameObject.transform.rotation);
    }
    public void OnShieldTower() {
        Instantiate(Shield_Big, new Vector3(1.09f, 3.54f, -8.07f), gameObject.transform.rotation);
    }
}
