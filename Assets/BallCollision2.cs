using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallConl2 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;
    public GameObject Pusher;
    private BallMove2 ballMove;
    private ColdPoint cp;
    void Start()
    {

        Player = GameObject.Find("Player1");
        Pusher = GameObject.Find("Player2");
        ballMove = GetComponent<BallMove2>();
        cp = Player.GetComponent<ColdPoint>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            cp.DamageDown(transform.localScale.x);
            
            if (ballMove.IsPushing)
            {
                Pusher.GetComponent<Animator>().Play("state");
                Pusher.GetComponent<Animator>().SetBool("IsBalling", false);
                Pusher.GetComponent<balling2>().Isballing = false;
            }
            Destroy(gameObject);


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
                    Pusher.GetComponent<balling2>().Isballing = false;
                }


                Destroy(gameObject);
            }

        }
    }
}
