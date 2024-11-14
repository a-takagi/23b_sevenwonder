using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stafferoom : MonoBehaviour
{
    
    GameManager gm;

    ItemManager im;

    [SerializeField] GameObject KeyKiraKira;

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

        if(gm.GetisHokenKey()){
            KeyKiraKira.SetActive(false);
        }
               
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //��b���n�߂����p���\�b�h
    public void KaiwaNau(){
        gm.KaiwaNau();
    }

    //��b�I��������p���\�b�h
    public void KaiwaOwatade(){
        gm.KaiwaOwatade();
    }

    public void healkey(){
        Debug.Log("GetKey");
        im.GetKey();
        gm.SetisHokenOpen(true);
        gm.SetisHokenKey(true);
    }
}
