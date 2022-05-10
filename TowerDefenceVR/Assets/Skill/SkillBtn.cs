using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillBtn : MonoBehaviour
{
    public Image skillFilter;
    public float coolTime;
    public Text coolTimeCounter;

    private float currentCoolTime;

    void Start()
    {
        skillFilter.fillAmount = 0;
    }


    public void UseSkill()
    {
        Debug.Log("Use Skill");
        skillFilter.fillAmount = 1;
        StartCoroutine("Cooltime");

        currentCoolTime = coolTime;
        coolTimeCounter.text = "" + currentCoolTime;
        StartCoroutine("CoolTimeCounter");


    }

    IEnumerator Cooltime()
    {
        while (skillFilter.fillAmount > 0)
        {
            skillFilter.fillAmount -= 1 * Time.smoothDeltaTime / coolTime;
            yield return null;
        }

        yield break;
    }

    IEnumerator CoolTimeCounter()
    {
        while (currentCoolTime > 0)
        {
            yield return new WaitForSeconds(1.0f);

            currentCoolTime -= 1.0f;
            coolTimeCounter.text = "" + currentCoolTime;
        }
        yield break;
    }
}
