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
            //Debug.Log("DoorにPlayerが触れた");

            if (Input.GetButtonDown("Fire1"))
            {
                //Fire1ボタンが押された
                Debug.Log("Fire1が押された");
            }
        }
    }

}
