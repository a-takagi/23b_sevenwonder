using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            //Debug.Log("Door‚ÉPlayer‚ªG‚ê‚½");

            if (Input.GetButtonDown("Fire1"))
            {
                //Fire1ƒ{ƒ^ƒ“‚ª‰Ÿ‚³‚ê‚½
                Debug.Log("Fire1‚ª‰Ÿ‚³‚ê‚½");
            }
        }
    }

}
