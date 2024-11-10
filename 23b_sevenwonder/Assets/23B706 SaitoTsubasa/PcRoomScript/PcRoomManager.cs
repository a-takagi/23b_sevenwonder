using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PcRoomManager : MonoBehaviour
{
    //会話のオブジェクトたち
    [SerializeField] GameObject PcRoomFirstKaiwa;
    [SerializeField] GameObject PcRoomPcKaiwa;

    //会話のフラグ
    private bool isPcRoomSecond;

    //オブジェクト
    [SerializeField] private GameObject LockerKira;
    [SerializeField] private GameObject DeskKira;
    [SerializeField] private GameObject ShelfKira;
    [SerializeField] private GameObject Enemy;

    //PcObject
    [SerializeField] private GameObject PcLighting;
    [SerializeField] private GameObject PcRed;

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

        //PC教室の二回目は会話達をなくす
        if(gm.GetPcRoomSecond() == true){
            PcRoomFirstKaiwa.SetActive(false);
            PcRoomPcKaiwa.SetActive(false);
        }else{
            gm.SetPcRoomSecond(true);
        }
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
        //化け物出現
        //鍵探しポイント作成
        //Pcを赤に切り替える
        LockerKira.SetActive(true);
        DeskKira.SetActive(true);
        ShelfKira.SetActive(true);
        Enemy.SetActive(true);
        PcLighting.SetActive(false);
    }

    public void GetKey(){
        //ItemManagerに画像追加
        Im.GetPcKey();
        //GameManagerにフラグ渡す
        gm.SetisPcKey(true);
    }

    public void StartPcRoom(){
        Debug.Log("PcRoomManager.cs : StartKABI");
        gm.SetisFlag(24,true);
    }
    public void ClearPcRoom(){
        gm.SetisFlag(24,false);
    }
}
