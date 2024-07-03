using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSearch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            Debug.Log("Itemがプレイヤーに触れる");

            if (Input.GetButtonDown("Fire1"))
            {
                //Fire1ボタンが押された
                Debug.Log("Fire1が押された");
            }
        }
    }
}

