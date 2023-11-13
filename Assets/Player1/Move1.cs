using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;

public class Move1 : MonoBehaviour
{
    private bool onground = false;
    private Rigidbody2D rb;
    public float moveSpeed = 5f;
    public float maxSpeed = 5f;
    public float rotationSpeed = 100f;
    //public AudioSource audioSource;
    public bool forward = false,oldForward=false;
    private SpriteRenderer rbSprite;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rbSprite = GetComponent<SpriteRenderer>();

    }
    void Update()

    {
       
        if (Input.GetKey(KeyCode.A))
        {
            //rbSprite.flipX = false;
            forward = true;
            OnAnimatorMove(-1);
        }

        else if (Input.GetKey(KeyCode.D))
        {

            //rbSprite.flipX = true;
            forward = false;
            OnAnimatorMove(1);
        }else{
            //audioSource.Stop();
            GetComponent<Animator>().SetBool("Moving", false);
        }
        //FixedUpdate();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            onground = false;
        }
    }
    void FixedUpdate()
    {
        if (oldForward != forward)
        {
            oldForward = forward;
            GetComponent<Animator>().SetTrigger("Turn");
        }
        if (Input.GetKey(KeyCode.A))
        {
            rbSprite.flipX = false;

        }

        else if (Input.GetKey(KeyCode.D))
        {

            rbSprite.flipX = true;

        }
        Vector2 currentVelocity = rb.velocity;
        float horizontalVelocity = currentVelocity.x;

        // 在水平方向上限制速度
        float limitedHorizontalVelocity = Mathf.Clamp(horizontalVelocity, -maxSpeed, maxSpeed);
        rb.velocity = new Vector2(limitedHorizontalVelocity, currentVelocity.y);
    }
    private void OnAnimatorMove(int fx)
    {
        //audioSource.Play();
        GetComponent<Animator>().SetBool("Moving",true);
        Vector2 movement = new Vector2(fx * moveSpeed, 0);
        rb.AddForce(movement);
    }

}