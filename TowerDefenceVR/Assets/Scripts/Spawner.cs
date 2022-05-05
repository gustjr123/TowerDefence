using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Spawner : MonoBehaviour
{
    public List<GameObject> prefabs;
    [Header("Cooldown Time for Second")]
    [SerializeField] private int Cooldown;
    [Header("TextField")]
    [SerializeField] private Text text;

    private bool isCooldown;
    private WaitForSeconds WaitTime;

    private void Start() {
        isCooldown = true;
        WaitTime = new WaitForSeconds(1.0f);
    }

    public void Spawn(int index)
    {
        if (isCooldown) {
            Instantiate(prefabs[index], transform.position, transform.rotation);
            StartCoroutine(CoolDownCoroutine());
        }
    }

    IEnumerator CoolDownCoroutine() {
        isCooldown = false;
        for(int i=Cooldown; i>0; i--) {
            yield return WaitTime;
            text.text = (i-1).ToString();
        }
        text.text = "Can Use";
        isCooldown = true;
    }
}