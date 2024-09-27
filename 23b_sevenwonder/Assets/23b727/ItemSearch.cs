using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSearch : MonoBehaviour
{
    [SerializeField]
    GameObject heaKey;

    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        heaKey.SetActive(false);
        //GameManagerの取得
        GameObject tmp;
        tmp = GameObject.Find("GameManager");
        gm=tmp.GetComponent<GameManager>();
        if (!gm)
        {
            Debug.Log("GameManagerが見つかりません");
        }
                
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
                Destroy (this.gameObject);
                
                return;
            }
        }
    }
}

