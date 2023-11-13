using UnityEngine;
public class balling2 : MonoBehaviour
{
    public GameObject weaponPrefab;
    public Move2 Move;
    public float distance = 1f;
    public float high = 1f;
    private Vector3 Forward;
    public bool Playerfx;
    public bool Isballing = false, Holiding = false;
    private float nextAttackTime,coldTime;
    public float attackCooldown = 1f,coldTimeInterval=1f,colding=0.5f;
    private ColdPoint2 CP;
    public Jump2 Jump;
    private void Start()
    {
        CP= GetComponent<ColdPoint2>();
        nextAttackTime = 0;
        Jump = GetComponent<Jump2>();
        coldTime = 0;
    }
    void Update()
    {

        if(Isballing&&Time.time>=coldTime) 
        {
            coldTime=Time.time+coldTimeInterval;
            CP.DamageDown(colding);
            
        }
        GetComponent<Animator>().SetBool("Create", false);
        if (Time.time >= nextAttackTime && Input.GetKeyDown(KeyCode.DownArrow)&&!Holiding)
        {
            nextAttackTime = Time.time + attackCooldown;
            if (!Isballing && Jump.onGround)
            {
                GetComponent<Animator>().SetBool("Create", true);
                GetComponent<Animator>().SetBool("IsBalling", true);
                // Debug.Log("Ball");
                Isballing = true;
                //   Debug.Log("qql");
                Move = GetComponent<Move2>();
                //Debug.Log("1");
                Playerfx = Move.forward;
                if (Playerfx)
                {
                    Forward = new Vector3(-1, high, 0);
                }
                else
                {
                    Forward = new Vector3(1, high, 0);
                }
                Createball();
                return;

            }
            if (Isballing)
            {
                GetComponent<Animator>().SetBool("IsBalling", false);
                //   Debug.Log("Isballing");
                Isballing = false;
                return;
            }

        }
        if (Isballing && Input.GetKeyDown(KeyCode.DownArrow) && !Holiding)
        {
            //   Debug.Log("Isballing");
            GetComponent<Animator>().SetBool("IsBalling", false);
            Isballing = false;
            return;
        }
    }
    private void FixedUpdate()
    {

    }
    void Createball()
    {
        Vector3 spawnPosition = transform.position + (Forward * distance); //基于当前方向生成位置
        Instantiate(weaponPrefab, spawnPosition, transform.rotation); //生成新武器
    }

}