using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallConl : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;
    public GameObject Pusher;
    private BallMove ballMove;
    private ColdPoint2 cp;
    void Start()
    {

        Player = GameObject.Find("Player2");
        Pusher = GameObject.Find("Player1");
        ballMove = GetComponent<BallMove>();
        cp = Player.GetComponent<ColdPoint2>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player2"))
        {

            cp.DamageDown(transform.localScale.x);
            Destroy(gameObject);
            if (ballMove.IsPushing)
            {
                Pusher.GetComponent<Animator>().Play("state");
                Pusher.GetComponent<Animator>().SetBool("IsBalling", false);
                Pusher.GetComponent<balling1>().Isballing = false;
            }
               
         
            //Debug.Log(transform.localScale.x);


        }
        if (collision.gameObject.CompareTag("SnowBall"))
        {
            float scale1 = transform.localScale.x, scale2 = collision.gameObject.transform.localScale.x;
            if (scale1 <= scale2 * 1.3)
            {
                if (ballMove.IsPushing)
                {
                Pusher.GetComponent<Animator>().Play("state");                
                Pusher.GetComponent<Animator>().SetBool("IsBalling", false);
                Pusher.GetComponent<balling1>().Isballing = false;
                }
                
                
                Destroy(gameObject);
            }

        }
    }
}
