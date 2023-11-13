using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthchange2 : MonoBehaviour
{
    public Image hpimage;//图像血条
    public Image hpeffect;//缓冲血条
    public GameObject Player;

    public float icepointmax_p2 = 10f;//寒冷最大值p2
    public float icepointcurrent_p2,Cp2;//当前寒冷值p2
    public float bufftime=0.3f;

    private Coroutine loaddoing;//新建进程血条缓升
    private void Start()
    {
        Player = GameObject.Find("Player2");

        Updatetheicepoint_p2();//这段指令可以即刻更新血条
        Cp2 = Player.GetComponent<ColdPoint2>().coldPoint;
        icepointcurrent_p2 = icepointmax_p2 - Cp2;
    }
    private void Update()
    {
        Cp2 = Player.GetComponent<ColdPoint2>().coldPoint;
        if (Cp2 <= 0)
        {
            GetComponent<Animator>().SetBool("isFrozen", true); return;
        }
        if (icepointcurrent_p2 != Cp2)

        {
            icepointcurrent_p2 = icepointcurrent_p2 = icepointmax_p2 - Cp2; ;
            Updatetheicepoint_p2();
        }
    }
    private void Updatetheicepoint_p2()
    {
        hpeffect.fillAmount = icepointcurrent_p2 / icepointmax_p2;//调整血条显示,先升高缓冲条
        if (loaddoing != null)
        {
            StopCoroutine(loaddoing);//如果正在进程就停止进程

        }
        loaddoing = StartCoroutine(Uppericepoint2());
    }
    private IEnumerator Uppericepoint2()
    {
        float bufflength = hpeffect.fillAmount - hpimage.fillAmount;//缓冲条与血条之差
        float buffTime = 0f;
        while (buffTime < bufftime && icepointcurrent_p2< 100)
        {
            buffTime += Time.deltaTime;
            hpimage.fillAmount = Mathf.Lerp(hpeffect.fillAmount - bufflength, hpeffect.fillAmount, buffTime/bufftime);
            yield return null;
        }
        hpimage.fillAmount = hpeffect.fillAmount;          
    }
}