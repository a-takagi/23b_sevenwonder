using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 100.0f;

    Animator animater;

    int nowAnim = 0;
    float vx = 0;
    float vy = 0;

    [SerializeField] GameObject right;


   
    
    // Start is called before the first frame update
    void Start()
    {
        animater = right.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // –ˆƒtƒŒ[ƒ€”’l‚ð‰Šú‰»
        vx = 0;
        vy = 0;

        float dx = Input.GetAxis ("Horizontal");
        float dy = Input.GetAxis ("Vertical");
        transform.Translate (speed * dx, speed * dy, 0.0F);

        if (dx > 0.0f) {
            animater.SetBool("right", true);
        }
        else
        {
            animater.SetBool("right", false);
        }

        if (dx < 0.0f)
        {
            animater.SetBool("left", true);
        }
        else
        {
            animater.SetBool("left", false);
        }

        if (Input.GetButtonDown("Fire1")){
            
        }

        if(Input.GetButtonDown("Fire2")){
           
        }

        if(Input.GetButtonDown("Jump")){
           
        }


    }


    private void WalkSwitch(string str)
    {

        switch (str)
        {
            case "LeftWalk":
                nowAnim = 2;
                break;
            case "RightWalk":
                nowAnim = 4;
                break;
            case "UpWalk":
                nowAnim = 3;
                break;
            case "DownWalk":
                nowAnim = 1;
                break;
            case "Stand":
                nowAnim = 0;
                break;
            default:
                nowAnim = 0;
                break;
        }
        animater.SetInteger("nowWalk", nowAnim);
    }
}
