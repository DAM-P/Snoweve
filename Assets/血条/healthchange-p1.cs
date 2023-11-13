using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthchange1 : MonoBehaviour
{
    public Image hpimage;//图像血条
    public Image hpeffect;//缓冲血条

    public GameObject Player;
    public float icepointmax_p1 = 10f;//寒冷最大值p1
    public float icepointcurrent_p1,Cp1;//当前寒冷值p1
    public float bufftime = 0.3f; 

    private Coroutine loaddoing;//新建进程血条缓升
    private void Start()
    {
        Player = GameObject.Find("Player1");
        
        Updatetheicepoint_p1();//这段指令可以即刻更新血条
        Cp1 = Player.GetComponent<ColdPoint>().coldPoint;
        icepointcurrent_p1 = icepointmax_p1-Cp1;
    }
    private void Update()
    {
        Cp1=Player.GetComponent<ColdPoint>().coldPoint;
        if (Cp1 <= 0)
        {
            GetComponent<Animator>().SetBool("isFrozen", true); return;
        }
        if (icepointcurrent_p1!=Cp1)
        {
            icepointcurrent_p1 = icepointcurrent_p1 = icepointmax_p1 - Cp1; ;
            Updatetheicepoint_p1();
        }
    }
    private void Updatetheicepoint_p1()
    {
        hpeffect.fillAmount = icepointcurrent_p1 / icepointmax_p1;//调整血条显示,先升高缓冲条
        if (loaddoing != null)
        {
            StopCoroutine(loaddoing);//如果正在进程就停止进程

        }
        loaddoing = StartCoroutine(Uppericepoint1());
    }
    private IEnumerator Uppericepoint1()
    {
        float bufflength = hpeffect.fillAmount - hpimage.fillAmount;//缓冲条与血条之差
        float buffTime = 0f;
        while (buffTime < bufftime && icepointcurrent_p1 < 100)
        {
            buffTime += Time.deltaTime;
            hpimage.fillAmount = Mathf.Lerp(hpeffect.fillAmount - bufflength, hpeffect.fillAmount, buffTime/bufftime);
            yield return null;
        }
        hpimage.fillAmount = hpeffect.fillAmount;          
    }
}