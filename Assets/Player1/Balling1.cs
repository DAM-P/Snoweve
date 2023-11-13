using UnityEngine;
public class balling1 : MonoBehaviour
{
    public GameObject weaponPrefab;
    public Move1 Move;
    public float distance = 1f;
    public float high = 1f;
    private Vector3 Forward = new Vector3(1, 0, 0);
    public bool Playerfx;
    public bool Isballing = false,Holiding=false;
    private float nextAttackTime, coldTime;
    public float attackCooldown = 1f, coldTimeInterval = 1f, colding = 0.5f;
    private ColdPoint CP;
    public Jump1 Jump;
    private void Start()
    {

        CP = GetComponent<ColdPoint>();
        Jump = GetComponent<Jump1>();
        coldTime = 0;
        nextAttackTime = 0;
    }
    void Update()
    {
        if(Isballing && Time.time >= coldTime)
        {
            coldTime = Time.time + coldTimeInterval;
            CP.DamageDown(colding);

        }
        GetComponent<Animator>().SetBool("Create", false);

        //if()
        if (Time.time >= nextAttackTime && Input.GetKeyDown(KeyCode.S)&&!Holiding)
        {
            
            //Debug.Log(1);
            nextAttackTime = Time.time + attackCooldown;
            if (!Isballing && Jump.onGround)
            {
                //Debug.Log("Ball");
                GetComponent<Animator>().SetBool("Create", true);
                GetComponent<Animator>().SetBool("IsBalling",true);
                Isballing = true;
                //   Debug.Log("qql");
                Move = GetComponent<Move1>();
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
                //   Debug.Log("Isballing");
                GetComponent<Animator>().SetBool("IsBalling",false);
                Isballing = false;
                return;
            }

        }
        if (Isballing && Input.GetKeyDown(KeyCode.S)&&!Holiding)
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
        // Debug.Log("baling");
        Vector3 spawnPosition = transform.position + (Forward * distance); //基于当前方向生成位置
        Instantiate(weaponPrefab, spawnPosition, transform.rotation); //生成新武器
    }

}