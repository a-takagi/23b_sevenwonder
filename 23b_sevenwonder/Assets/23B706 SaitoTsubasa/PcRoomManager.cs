using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PcRoomManager : MonoBehaviour
{
    //会話のオブジェクトたち
    [SerializeField] GameObject PcRoomFirstKaiwa;
    [SerializeField] GameObject PcRoomDoorKaiwa;

    //会話のフラグ
    private bool isPcRoomSecond;

    //オブジェクト
    [SerializeField] private GameObject Pc;
    [SerializeField] private GameObject LockerKira;
    [SerializeField] private GameObject DeskKira;
    [SerializeField] private GameObject ShelfKira;

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

        //PC教室の二回目は何も起きなくする
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

    public void RightingPc(){
        Pc.SetActive(true);
        //化け物出現
        //鍵探しポイント作成
        LockerKira.SetActive(true);
        DeskKira.SetActive(true);
        ShelfKira.SetActive(true);
    }
}
