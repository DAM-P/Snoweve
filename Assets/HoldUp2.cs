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
        Vector3 currentPosition = rb.position;  // 获取当前位置

        currentPosition.y = Player.transform.position.y + high + transform.localScale.x;  // 设置 x 坐标

        currentPosition.x = Player.transform.position.x;

        startPosition = transform.position;
        targetPosition = currentPosition;
        StartCoroutine(AnimateMove1());
        //transform.position = currentPosition;  // 设置新位置

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
            // 计算当前的插值比例
            float t = elapsedTime / duration;
            // 使用平滑插值（Lerp）计算当前的位置
            transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            // 等待一帧
            yield return null;
            // 更新已经经过的时间
            elapsedTime += Time.deltaTime;
        }
        // 确保物体最终到达目标位置
        transform.position = targetPosition;
    }
}
