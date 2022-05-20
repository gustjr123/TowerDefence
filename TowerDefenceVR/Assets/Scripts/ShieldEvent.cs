using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldEvent : MonoBehaviour
{
    [SerializeField] private List<GameObject> ShieldPosition;
    [SerializeField] private GameObject Shield_Big;
    [SerializeField] private GameObject Shield_small;
    [SerializeField] private int MaxSize;

    [SerializeField] private List<GameObject> ShieldPrefabs;
    private void Start() {
        List<GameObject> ShieldPrefabs = new List<GameObject>();

    }
    
    public void OnShield1() {
        ShieldPrefabs.Add(Instantiate(Shield_Big, ShieldPosition[0].transform.position, ShieldPosition[0].transform.rotation));
    }
    public void OnShield2() {
        ShieldPrefabs.Add(Instantiate(Shield_Big, ShieldPosition[1].transform.position, ShieldPosition[1].transform.rotation));
    }
    public void OnShield3() {
        ShieldPrefabs.Add(Instantiate(Shield_Big, ShieldPosition[2].transform.position, ShieldPosition[2].transform.rotation));
    }
    public void OnShield4() {
        ShieldPrefabs.Add(Instantiate(Shield_Big, ShieldPosition[3].transform.position, ShieldPosition[3].transform.rotation));
    }
    public void OnShield5() {
        ShieldPrefabs.Add(Instantiate(Shield_Big, ShieldPosition[4].transform.position, ShieldPosition[4].transform.rotation));
    }
    public void OnShieldTower() {
        ShieldPrefabs.Add(Instantiate(Shield_small, ShieldPosition[5].transform.position, ShieldPosition[5].transform.rotation));
    }

    public void Shield_Clear() {
        foreach(GameObject i in ShieldPrefabs) {
            Destroy(i);
        }
        ShieldPrefabs.Clear();
    }
}
