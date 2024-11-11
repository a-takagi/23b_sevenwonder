using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roka3Manager : MonoBehaviour
{
    //会話のオブジェクトたち
    [SerializeField] private GameObject PcRoomEndKaiwa;
    [SerializeField] private GameObject PcRoomDoor;
    [SerializeField] private GameObject KahanshinDoor;

    //参照系
    private GameManager gm;
    private ItemManager Im;
    private PlayerController Pm;

    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.Find("GameManager") != null){
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        Debug.Log("Roka3Manager.cs : Get GameManager");
        }else{Debug.Log("Not Found GameManager");}
        
        
        if(GameObject.Find("ItemManger") != null){
        Im = GameObject.Find("ItemManger").GetComponent<ItemManager>();
        Debug.Log("Roka3Manager.cs : Get ItemManger");
        }else{Debug.Log("Not Found ItemManger");}
        
        if(GameObject.Find("Player")){
        PlayerController Pm = GameObject.Find("Player").GetComponent<PlayerController>();
        }else{Debug.Log("Not Found Player");}

        //PcRoomが終わった後にクリア後の会話を表示させる
        //表示させた後はフラグをオンに
        //PcRoomの鍵を持っていたら会話表示
        if(gm.GetisPcKey()){
            if(!gm.GetisFlag(27)){
                PcRoomEndKaiwa.SetActive(true);
                gm.SetisFlag(27,true);
            }
            PcRoomDoor.SetActive(true);
            KahanshinDoor.SetActive(true);
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
}
