using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HoldUp2 : MonoBehaviour
{
    public bool hold = false;
    public GameObject Player;
    private BallMove2 ballmove2;
    private Rigidbody2D rb, playerrb;
    private CircleCollider2D circleCollider;
    private Jump2 jump;
    public float high = 0;
    public float duration = 0.2f;
    public Vector3 targetPosition;
    private Vector3 startPosition;
    // Start is  called before the first frame update
    void Start()
    {
        ballmove2 = GetComponent<BallMove2>();
        rb = GetComponent<Rigidbody2D>();
        Player = GameObject.Find("Player2");
        jump = Player.GetComponent<Jump2>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) && ballmove2.IsPushing)
        {
            ballmove2.enabled = false;

            jump.holding = true;
            Player.GetComponent<balling2>().Holiding = true;
            Player.GetComponent<Animator>().SetBool("IsHolding", true);
            ballmove2.enabled = false;
            leftup();
        }
        else { 

            Player.GetComponent<balling2>().Holiding = false;
            Player.GetComponent<Animator>().SetBool("IsHolding", false);

            jump.holding = false;
            hold = false;
            ballmove2.enabled = true;
        }

    }
    void leftup()
    {
        Vector3 scale = transform.localScale;
        Vector3 currentPosition = rb.position;  // ��ȡ��ǰλ��

        currentPosition.y = Player.transform.position.y + high + transform.localScale.x;  // ���� x ����

        currentPosition.x = Player.transform.position.x;

        startPosition = transform.position;
        targetPosition = currentPosition;
        StartCoroutine(AnimateMove1());
        //transform.position = currentPosition;  // ������λ��

        //Debug.Log(transform.position.y);
    }
    private IEnumerator AnimateMove1()
    {
        float elapsedTime = 0f;
        //Debug.Log(elapsedTime);

        while (elapsedTime < duration)
        {
            if (!jump.holding)
            {
                yield break;
            }
            //Debug.Log(1);
            // ���㵱ǰ�Ĳ�ֵ����
            float t = elapsedTime / duration;
            // ʹ��ƽ����ֵ��Lerp�����㵱ǰ��λ��
            transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            // �ȴ�һ֡
            yield return null;
            // �����Ѿ�������ʱ��
            elapsedTime += Time.deltaTime;
        }
        // ȷ���������յ���Ŀ��λ��
        transform.position = targetPosition;
    }
}
