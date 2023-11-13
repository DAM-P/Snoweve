using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HoldUp : MonoBehaviour
{
    public bool hold = false;
    public GameObject Player;
    private BallMove ballmove1;
    private Rigidbody2D rb, playerrb;
    private CircleCollider2D circleCollider;
    private Jump1 jump;
    public float high = 0;
    public Vector3 targetPosition;
    public float duration = 0.2f;

    private Vector3 startPosition;

    // Start is  called before the first frame update
    void Start()
    {
        ballmove1 = GetComponent<BallMove>();
        rb = GetComponent<Rigidbody2D>();
        Player = GameObject.Find("Player1");
        jump = Player.GetComponent<Jump1>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) && ballmove1.IsPushing)
        {
            //Debug.Log(2);
             
            ballmove1.enabled = false;
            
            jump.holding = true;
            Player.GetComponent<balling1>().Holiding = true;
            Player.GetComponent<Animator>().SetBool("IsHolding", true);
           // Debug.Log(2);
            leftup();
        }
        else
        {
            Player.GetComponent<balling1>().Holiding = false;
            Player.GetComponent<Animator>().SetBool("IsHolding", false);
            jump.holding = false;
            hold = false;
            ballmove1.enabled = true;
            //ballmove1.IsPushing = true;
          /* Vector3 currentPosition = rb.position;  // ��ȡ��ǰλ��
            currentPosition.x = Player.transform.position.x + ballmove1.Forward  * transform.localScale.x;
            startPosition = transform.position;
            targetPosition = currentPosition;
            StartCoroutine(AnimateMove1());*/
            

        }

    }
    void leftup()
    {

        Vector3 scale = transform.localScale;
        Vector3 currentPosition = rb.position;  // ��ȡ��ǰλ��
        currentPosition.y = Player.transform.position.y + high + transform.localScale.x ;  // ���� x ����
        currentPosition.x = Player.transform.position.x;
        
        startPosition = transform.position;
//Debug.Log(2);
        targetPosition=currentPosition;
        

        StartCoroutine(AnimateMove1());
        //AnimateMove();
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
