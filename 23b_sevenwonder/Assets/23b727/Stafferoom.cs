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
        //GameManager‚ÌŽæ“¾
        GameObject tmp;
        tmp = GameObject.Find("GameManager");
        gm=tmp.GetComponent<GameManager>();
        if (!gm)
        {
            Debug.Log("Stafferoom.cs: GameManager‚ªŒ©‚Â‚©‚è‚Ü‚¹‚ñ");
        }
                
        //ItemManager‚ÌŽæ“¾
        GameObject imp;
        imp = GameObject.Find("ItemManger");
        im=imp.GetComponent<ItemManager>();
        if (!im)
        {
            Debug.Log("Library.cs: ItemManger‚ªŒ©‚Â‚©‚è‚Ü‚¹‚ñ");
        }
               
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
