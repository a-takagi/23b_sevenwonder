using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FungusManager : MonoBehaviour
{
    //参照系
    private GameManager gm;
    private ItemManager Im;
    private PlayerController Pm;

    //会話フラグ[trueの時は会話中]
    private bool KaiwaFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.Find("GameManager") != null){
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        Debug.Log("Get GameManager");
        }else{Debug.Log("Not Found GameManager");}
        
        
        if(GameObject.Find("ItemManger") != null){
        Im = GameObject.Find("ItemManger").GetComponent<ItemManager>();
        Debug.Log("Get ItemManger");
        }else{Debug.Log("Not Found ItemManger");}
        
        if(GameObject.Find("Player")){
        PlayerController Pm = GameObject.Find("Player").GetComponent<PlayerController>();
        }else{Debug.Log("Not Found Player");}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //会話を始めた時用メソッド
    public void KaiwaNau(){
        Im.SetKaiwaFlag(true);
        gm.KaiwaNau();
    }

    //会話終わった時用メソッド
    public void KaiwaOwatade(){
        Im.SetKaiwaFlag(false);
        gm.KaiwaOwatade();
    }
}
