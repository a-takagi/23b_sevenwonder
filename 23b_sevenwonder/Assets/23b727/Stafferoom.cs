using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stafferoom : MonoBehaviour
{
    
    GameManager gm;

    ItemManager im;
    
    GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        //GameManager�̎擾
        GameObject tmp;
        tmp = GameObject.Find("GameManager");
        gm=tmp.GetComponent<GameManager>();
        if (!gm)
        {
            Debug.Log("Stafferoom.cs: GameManager��������܂���");
        }
                
        //ItemManager�̎擾
        GameObject imp;
        imp = GameObject.Find("ItemManger");
        im=imp.GetComponent<ItemManager>();
        if (!im)
        {
            Debug.Log("Library.cs: ItemManger��������܂���");
        }
               
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
