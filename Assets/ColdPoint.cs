using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ColdPoint : MonoBehaviour
{
    //[SerializeField]
    public float coldPoint = 10f, delaySeconds=2f, transitionSpeed=1f;
    public TextMeshProUGUI healthText;
    public bool win;
    private SpriteRenderer sprite;
    public GameObject Canva;
    // Start is called before the first frame update
    void Start()
    {
       // healthText=GetComponent<TextMeshProUGUI>();
       sprite = GetComponent<SpriteRenderer>();
        UpdateHealthText();
    }

    // Update is called once per frame
    void Update()
    {
        if (win)
        {
            Color targetColor=new Color(1,1,1,0); 
            sprite.color = Color.Lerp(sprite.color, targetColor, Time.deltaTime * transitionSpeed);
        }
    }
    public void DamageDown(float damage)
    {
        coldPoint -= damage;
        if(coldPoint < 0) coldPoint = 0;
        
        if (coldPoint <=0)
        {
            Canva.GetComponent<Ending>().winner1 = false;
            GetComponent<Animator>().Play("Frozen");
            GetComponent<Jump1>().enabled = false;
            GetComponent<Move1>().enabled = false;
            GetComponent<balling1>().enabled = false;
            Invoke("End", delaySeconds);
            Debug.Log("Winner 2");
        }UpdateHealthText();

    }
    private void UpdateHealthText()
    {
        healthText.text = "Health: " + coldPoint.ToString();
    }
    private void End()
    {
            Canva.GetComponent<Ending>().EndMenu();

    }
}

