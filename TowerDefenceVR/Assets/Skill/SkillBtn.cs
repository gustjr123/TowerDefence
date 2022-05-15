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
    bool isCooldown = false;

    void Start()
    {
        skillFilter.fillAmount = 0;
    }

    void Update()
    {
        if (isCooldown == false)
            skillFilter.fillAmount = 0;
    }


    public void UseSkill()
    {
        if (isCooldown == false)
        {
            skillFilter.fillAmount = 1;
            currentCoolTime = coolTime;
            coolTimeCounter.text = "" + currentCoolTime;
            StartCoroutine("CoolTimeCounter");
            isCooldown = true;
        }
    }

    IEnumerator Cooltime()
    {
        while (skillFilter.fillAmount > 0)
        {
            //skillFilter.fillAmount -= 1 * Time.smoothDeltaTime / coolTime;
            skillFilter.fillAmount += 1 / coolTime * Time.deltaTime;
            yield return null;
        }
        isCooldown = false;
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
        isCooldown = false;
        yield break;
    }
}