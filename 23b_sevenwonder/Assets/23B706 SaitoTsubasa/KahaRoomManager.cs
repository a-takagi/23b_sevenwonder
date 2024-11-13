using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KahaRoomManager : MonoBehaviour
{
    //会話のオブジェクトたち
    [SerializeField] GameObject HomeworkGetKaiwa;
    [SerializeField] GameObject KahansinKaiwa;

    //オブジェクト
    [SerializeField] private GameObject Enemy;

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

        //二回目は会話達をなくす
        if(gm.GetSpanwedKahanSin() == true){
            //会話をなくす
            HomeworkGetKaiwa.SetActive(false);
        }else{
            //二回目の入室フラグON
            gm.SetKahanSinRoomSecond(true);
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

    public void GetHomeWork(){
        //ItemManagerの宿題をON
        Im.GetSyukudai();
        //GameManagerのフラグをON
        gm.SetisHomeWork(true);
        //化け物出現
        Enemy.SetActive(true);
        gm.SetSpawnedKahanSin(true);
        //会話26出現
        KahansinKaiwa.SetActive(true);
    }

    public void GetFamilyPhoto(){
        //ItemManager GameManager のフラグをオンに
        Im.GetFamilyPhoto();
        gm.SetisFlag(29,true);
    }
}
