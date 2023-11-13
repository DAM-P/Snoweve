using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;

public class Move2 : MonoBehaviour
{
    private bool onground = false;
    private Rigidbody2D rb;
    public float moveSpeed = 5f;
    public float maxSpeed = 5f;
    public float rotationSpeed = 100f;
    //public AudioSource audioSource;
    public bool forward = true;
    private SpriteRenderer rbSprite;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rbSprite = GetComponent<SpriteRenderer>();
    }
    void Update()

    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            forward = true;
            OnAnimatorMove(-1);
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            forward = false;
            OnAnimatorMove(1);
        }
        else
        {
            //audioSource.Pause();
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
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rbSprite.flipX = false;

        }

        else if (Input.GetKey(KeyCode.RightArrow))
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
        // RotateToVelocity();
        // transform.position = new Vector2(fx* moveSpeed * Time.deltaTime + transform.position.x, transform.position.y); // 应用移动变换
        GetComponent<Animator>().SetBool("Moving", true);
        Vector2 movement = new Vector2(fx * moveSpeed, 0);
        rb.AddForce(movement);

    }
    /* void RotateToVelocity()
     {
         if (rb.velocity.magnitude > 0.1f)
         {
             float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
             Quaternion newRotation = Quaternion.AngleAxis(angle, Vector3.forward);
             transform.rotation = Quaternion.RotateTowards(transform.rotation, newRotation, rotationSpeed * Time.deltaTime);
         }
     }*/
}