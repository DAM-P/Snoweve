using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interim : MonoBehaviour
{
    // Start is called before the first frame update
    public Image transitionImage;
    public bool ToImage=false,startGet=true;
    public float transitionSpeed = 1.0f;
    private bool transitioning = false;
    private Color targetColor;
    private Color originalColor;
    private void Start()
    {
        if(startGet)
        {
            StartTransition();
        }
        if (ToImage)
        {
            //transitionImage.enabled =true;
            // originalColor = new Color(1, 1, 1, 0); // 目标颜色为透明
            transitionImage.color = new Color(1, 1, 1, 0);
            targetColor = new Color(1, 1, 1, 1);
        }

    }
    public void StartTransition()
    {   
       // transitionImage.transform.position =new Vector3(0,0,0) ;
        transitioning= true;
        if (ToImage)
        {
            //transitionImage.enabled =true;
            // originalColor = new Color(1, 1, 1, 0); // 目标颜色为透明
            transitionImage.color= new Color(1, 1, 1, 0);
            targetColor = new Color(1, 1, 1, 1);
        }
        else
        {
            originalColor = transitionImage.color;
            targetColor = new Color(1, 1, 1, 0); // 目标颜色为透明
        }
        
        transitionImage.enabled = true;

    }

    void Update()
    {
        if (transitioning){

            //Debug.Log(2);
            transitionImage.color = Color.Lerp(transitionImage.color, targetColor, Time.deltaTime * transitionSpeed);

            if (transitionImage.color.a <= 0.01f&&!ToImage)
            {
                transitioning = false;
                transitionImage.enabled = false;
            }
        }
    }

}