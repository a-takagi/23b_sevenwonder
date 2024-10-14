using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//保健室専用のManager
public class HealthRoomManager : MonoBehaviour
{
    //会話のオブジェクトたち
    [SerializeField] GameObject KangoKaiwa;

    //会話のフラグ
    private bool isHokenSecond;

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

        //保健室二回目の入室時は看護婦の会話を発生させない
        isHokenSecond = gm.GetHealthRoomSecond();
        Debug.Log(isHokenSecond.ToString());
        if(isHokenSecond){
            KangoKaiwa.SetActive(false);

        //一回目の入室時
        }else{
            KangoKaiwa.SetActive(true);
        }

        InHokenRoom();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InHokenRoom(){
        gm.SetHealthRoomSecond(true);
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
