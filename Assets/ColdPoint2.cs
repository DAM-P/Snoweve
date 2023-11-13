using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ColdPoint2 : MonoBehaviour
{
    //[SerializeField]
    public float coldPoint = 10, delaySeconds = 2f;
    public TextMeshProUGUI healthText;
    public GameObject Canva;
    // Start is called before the first frame update
    void Start()
    {
        // healthText=GetComponent<TextMeshProUGUI>();
        UpdateHealthText();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void DamageDown(float damage)
    {
        coldPoint -= damage;
        if (coldPoint < 0) coldPoint = 0;

        if (coldPoint <= 0)
        {
            Canva.GetComponent<Ending>().winner1 = true;
            GetComponent<Animator>().Play("Frozen");
            GetComponent<Jump2>().enabled = false;
            GetComponent<Move2>().enabled = false;
            GetComponent<balling2>().enabled = false;
            Invoke("End", delaySeconds);
            Debug.Log("Winner 1");
        }
        UpdateHealthText();

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

