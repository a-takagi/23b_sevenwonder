using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roka2Manger : MonoBehaviour
{
    //会話のオブジェクト達
    [SerializeField] private GameObject FirstGhostMam;  //一回目の鏡の会話
    [SerializeField] private GameObject SecondGhostMam; //看護婦に赤ちゃん届けた後の鏡の会話

    [SerializeField] private GameObject ClassStart; //授業始める会話
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
    
        //こっくりさんの後に真夜中授業の会話を生成するようにする
        //こっくりさん終わって真夜中授業の部屋に行くまで
        //それ以外の時は非表示

        //保健室が終わったら看護婦の会話を変える
        if(gm.GetHealthRoomSecond()){
            Debug.Log("Roka2Manager：HelthRoomSecond");
            FirstGhostMam.SetActive(false);
            SecondGhostMam.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

