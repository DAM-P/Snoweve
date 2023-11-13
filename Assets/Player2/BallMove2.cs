using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BallMove2 : MonoBehaviour
{
    private Vector3 lastPosition;
    public float Speed = 1f;
    public float maxRadius = 5f;
    public float scaleFactor = 1.01f;
    public GameObject Player;
    public Move2 Move;
    public bool Playerfx;//��ҷ���
    public float high = 1f;
    public float distance = 1f;
    private float Forward = 0;
    private Rigidbody2D rb, playerrb;
    private balling2 Ball;
    public bool IsPushing = true;
    private Vector2 movement;
    private CircleCollider2D circleCollider;
    private float nextTime, coldown = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        lastPosition = transform.position;
        Player = GameObject.Find("Player2");
        rb = GetComponent<Rigidbody2D>();  // ��ȡ�������
        circleCollider = GetComponent<CircleCollider2D>();
        nextTime = 0;
        //   playerrb=Player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        Ball = Player.GetComponent<balling2>();
        Move = Player.GetComponent<Move2>();
        //Debug.Log("1");
        Playerfx = Move.forward;
        //Transform parentTransform = transform.parent;
        if (Playerfx)
        {
            Forward = -1f;
        }
        else
        {
            Forward = 1f;
        }
        if (IsPushing)
        {
            // ��ȡԲ����ײ���İ뾶
            // ���Բ����ײ���İ뾶
            //Debug.Log("Circle collider radius: " + radius);
            float radius = circleCollider.radius;
            movement = new Vector2(Forward * Speed, 0);
            // ����λ��
            Vector3 currentPosition = rb.position;  // ��ȡ��ǰλ��
            currentPosition.x = Player.transform.position.x + Forward * transform.localScale.x;  // ���� x ����

            rb.position = currentPosition;  // ������λ��

        }
        else
        {
            rb.AddForce(movement);
            movement = Vector3.zero;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {

            IsPushing = false;
        }
        if (CheckObjectMovement())
        {

            GetComponent<Animator>().SetBool("IsRolling", true);
            // Debug.Log("!");
        }
        else
        {
            //Debug.Log("?");
            GetComponent<Animator>().SetBool("IsRolling", false);
        }

    }
    private void FixedUpdate()
    {
        if (Player.GetComponent<Rigidbody2D>().velocity.x != 0 && IsPushing && Time.time >= nextTime)
        {
            nextTime = Time.time + coldown;
            Vector3 scale = transform.localScale;

            //  Debug.Log(scale.x);
            if (scale.x <= maxRadius)
            {
                scale *= scaleFactor;
                transform.localScale = scale;
                //  float radius = transform.localScale.x/2; // ����ʹ�� x ��������Ϊ�뾶
                //   circleCollider.radius = radius;
            }
            //     
            //     newRadius = Mathf.Clamp(newRadius/2, 0f, maxRadius); 

        }

    }
    bool CheckObjectMovement()
    {
        Vector3 currentPosition = transform.position;

        if (currentPosition.x != lastPosition.x)
        {
            lastPosition = currentPosition;
            return true;
        }
        else
        {
            return false;
        }

        

    }


}

