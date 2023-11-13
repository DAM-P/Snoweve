using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Jump1 : MonoBehaviour
{
    public balling1 Balling;
    public GameObject gameObject;
    private Rigidbody2D rb;
    public float JumpForce = 100f;
    public bool onGround = true;
    private BallMove ballMove1;
    private HoldUp Hold;
    public bool holding = false;
    // Start is called before the first frame update
    void Start()
    {
        Balling = GetComponent<balling1>();
        rb = GetComponent<Rigidbody2D>();
        ballMove1 = GetComponent<BallMove>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {

            if (!Balling.Isballing || holding)
            {

                onGround = false;
                GetComponent<Animator>().SetBool("OnGround", false);
                Move();
            }

        }

    }
    private void Move()
    {
        GetComponent<Animator>().SetTrigger("Isjumping");
        Vector2 movement = new Vector2(0, JumpForce);
        rb.AddForce(movement);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Player"))
        {

            onGround = true;
            GetComponent<Animator>().SetBool("OnGround",true) ;
        }
    }
}
