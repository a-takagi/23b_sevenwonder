using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//西棟2階のManager
public class West2RoomManager : MonoBehaviour
{
    //会話のオブジェクトたち
    

    //フラグ

    //参照系
    private GameManager gm;
    private ItemManager Im;
    private PlayerController Pm;


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
        gm.KaiwaNau();
    }

    //会話終わった時用メソッド
    public void KaiwaOwatade(){
        gm.KaiwaOwatade();
    }
}
