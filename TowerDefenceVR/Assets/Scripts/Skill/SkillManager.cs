using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillManager : MonoBehaviour
{
    #region Configure Variable
    private WaitForSeconds waiting;

    [Header("WaveSkillSpawnObject")]
    [SerializeField] private GameObject WaveSkill;

    [Header("WaveSkillCooltimeText")]
    [SerializeField] private Text wave_text;

    [Header("WaveSkillCooltime")]
    [SerializeField] private int wave_cooltime;
    private bool isWaveCooling;


    [Header("RightShootManager for Explosion")]
    [SerializeField] private GameObject rightHandShoot;

    [Header("ExplosionCooltimeText")]
    [SerializeField] private Text explosion_text;

    [Header("ExplosionCooltime")]
    [SerializeField] private int explosion_cooltime;

    [Header("ExplosionRunningtime")]
    [SerializeField] private float explosion_RunningTime;
    private bool isExplosionCooling;
    #endregion 

    private void Start() {
        // Use
        waiting = new WaitForSeconds(1.0f);
        // Set explosion Running time
        rightHandShoot.GetComponent<ShootManager>().RunningTime = explosion_RunningTime;
    }

    public void WaveskillActivate() {
        if (!isWaveCooling) {
            WaveSkill.GetComponent<Spawner>().Spawn();
            StartCoroutine(WaveCoroutine());
        }
    }

    public void ExplosionSkillActivate() {
        if (!isExplosionCooling) {
            rightHandShoot.GetComponent<ShootManager>().explosionSkillOn();
            StartCoroutine(ExplosionCoroutine());
        }
    }

    #region Coroutine함수
    IEnumerator WaveCoroutine() {
        isWaveCooling = true;
        for(int i=wave_cooltime; i>0; i--) {
            wave_text.text = (i-1).ToString();
            yield return waiting;
        }
        wave_text.text = "Can Use";
        isWaveCooling = false;
    }

    IEnumerator ExplosionCoroutine() {
        isExplosionCooling = true;
        for(int i=explosion_cooltime; i>0; i--) {
            explosion_text.text = (i-1).ToString();
            yield return waiting;
        }
        explosion_text.text = "Can Use";
        isExplosionCooling = false;
    }
    #endregion
}
