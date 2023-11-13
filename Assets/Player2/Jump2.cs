using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Jump2 : MonoBehaviour
{
    public balling2 Balling;
    public GameObject gameObject;
    private Rigidbody2D rb;
    public float JumpForce = 100f;
    public bool onGround = true;
    private BallMove2 ballMove1;
    private HoldUp Hold;
    public bool holding = false;
    // Start is called before the first frame update
    void Start()
    {
        Balling = GetComponent<balling2>();
        rb = GetComponent<Rigidbody2D>();
        //ballMove1 = GetComponent<BallMove2>();

    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log('A');
        //if (onGround) Debug.Log('R');
        if (Input.GetKeyDown(KeyCode.Keypad0) && onGround)
        {
           //Debug.Log('A');
            if ( holding|| !Balling.Isballing)
            {
                //Debug.Log('E');

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
        //Debug.Log('A');
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Player"))
        {

            onGround = true;
            GetComponent<Animator>().SetBool("OnGround", true);
        }
    }
}
