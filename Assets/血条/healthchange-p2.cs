using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthchange2 : MonoBehaviour
{
    public Image hpimage;//ͼ��Ѫ��
    public Image hpeffect;//����Ѫ��
    public GameObject Player;

    public float icepointmax_p2 = 10f;//�������ֵp2
    public float icepointcurrent_p2,Cp2;//��ǰ����ֵp2
    public float bufftime=0.3f;

    private Coroutine loaddoing;//�½�����Ѫ������
    private void Start()
    {
        Player = GameObject.Find("Player2");

        Updatetheicepoint_p2();//���ָ����Լ��̸���Ѫ��
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
        hpeffect.fillAmount = icepointcurrent_p2 / icepointmax_p2;//����Ѫ����ʾ,�����߻�����
        if (loaddoing != null)
        {
            StopCoroutine(loaddoing);//������ڽ��̾�ֹͣ����

        }
        loaddoing = StartCoroutine(Uppericepoint2());
    }
    private IEnumerator Uppericepoint2()
    {
        float bufflength = hpeffect.fillAmount - hpimage.fillAmount;//��������Ѫ��֮��
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