using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stafferoom : MonoBehaviour
{
    
    GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        //GameManagerの取得
        GameObject tmp;
        tmp = GameObject.Find("GameManager");
        gm=tmp.GetComponent<GameManager>();
        if (!gm)
        {
            Debug.Log("Stafferoom.cs: GameManagerが見つかりません");
        }
               
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
