using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthchange1 : MonoBehaviour
{
    public Image hpimage;//ͼ��Ѫ��
    public Image hpeffect;//����Ѫ��

    public GameObject Player;
    public float icepointmax_p1 = 10f;//�������ֵp1
    public float icepointcurrent_p1,Cp1;//��ǰ����ֵp1
    public float bufftime = 0.3f; 

    private Coroutine loaddoing;//�½�����Ѫ������
    private void Start()
    {
        Player = GameObject.Find("Player1");
        
        Updatetheicepoint_p1();//���ָ����Լ��̸���Ѫ��
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
        hpeffect.fillAmount = icepointcurrent_p1 / icepointmax_p1;//����Ѫ����ʾ,�����߻�����
        if (loaddoing != null)
        {
            StopCoroutine(loaddoing);//������ڽ��̾�ֹͣ����

        }
        loaddoing = StartCoroutine(Uppericepoint1());
    }
    private IEnumerator Uppericepoint1()
    {
        float bufflength = hpeffect.fillAmount - hpimage.fillAmount;//��������Ѫ��֮��
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