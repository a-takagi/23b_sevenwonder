using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 100.0f;
    
    [SerializeField]
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float dx = Input.GetAxis ("Horizontal");
        float dy = Input.GetAxis ("Vertical");
        transform.Translate (speed * dx, speed * dy, 0.0F);

        if(Input.GetButtonDown("Fire1")){
            
        }

        if(Input.GetButtonDown("Fire2")){
           
        }

        if(Input.GetButtonDown("Jump")){
           
        }


    }
}
