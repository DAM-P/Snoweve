using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class P1Hp : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshPro healthText;
    public int maxHealth = 100;
    private int currentHealth;
    private GameObject player1;

    void Start()
    {
        player1 = GameObject.Find("Player1");
        currentHealth = maxHealth;
    }

    void Update()
    {
        healthText.text = "Health: " + player1.GetComponent<ColdPoint>().coldPoint;
    }

    
}
