using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class wroom2Manager : MonoBehaviour
{

    GameManager gm;

    ItemManager im;

    [SerializeField] GameObject kirakira;
    [SerializeField] GameObject kirakira2;
    [SerializeField] GameObject kirakira3;
    [SerializeField] GameObject kokkurisan;
    [SerializeField] GameObject kaiwa12;
    [SerializeField] GameObject kaiwa13;
    [SerializeField] GameObject kaiwa14;
    [SerializeField] GameObject kaiwa15;
    [SerializeField] GameObject kaiwa16;
    [SerializeField] GameObject kaiwa17;

    int kiranum;

    //各種フラグ
    bool isKaiwa12; //始め会話の表示をしたかどうか
    bool isYen10; //10円玉を入手したかどうか
    bool isKami;  //こっくりさんの紙を入手したかどうか
    bool isKaiwa15; //10円玉とこっくりさんの紙を取得したかどうか
    bool isKaiwa17; //会話 

    // Start is called before the first frame update
    void Start()
    {
        kokkurisan.SetActive(false);
        kaiwa16.SetActive(false);
        kaiwa17.SetActive(false);
        //GameManagerの取得
        GameObject tmp;
        tmp = GameObject.Find("GameManager");
        gm = tmp.GetComponent<GameManager>();
        if (!gm) 
        {
            Debug.Log("wroom2Manager.cs; GameManagerが見つかりません");
        }

        //ItemManagerの取得
        GameObject imp;
        imp = GameObject.Find("ItemManger");
        im=imp.GetComponent<ItemManager>();
        if (!im)
        {
            Debug.Log("wroom2Manager.cs: ItemMangerが見つかりません");
        }


        //10円玉を入手している
        isYen10 = gm.GetisFlag(2);
        if (isYen10 == true)
        {
            kaiwa13.SetActive(false);
        }
        else
        {
            kaiwa13.SetActive(true);
        }

        //こっくりさんの儀式の紙を入手している
        isKami = gm.GetisFlag(3);
        if (isKami == true)
        {
            kaiwa14.SetActive(false);
        }
        else
        {
            kaiwa14.SetActive(true);
        }

        //こっくりさんのキラキラ
        if (gm.GetisFlag(8) == true)
        {
            isKaiwa15 = isYen10 && isKami;

            kokkurisan.SetActive(true);
            kaiwa13.SetActive(false);
            kaiwa14.SetActive(false);
            
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void Coin(){
        im.GetCoin();
    }
        
    public void KokkuriSheet(){
        im.GetKokkuriSheet();
    }

    public void KaiwaNau() 
    {
        gm.KaiwaNau();
    }

    public void KaiwaOwatade()
    {
        gm.KaiwaOwatade();
    }

    public void Get10yen()
    {
        gm.SetisFlag(2, true);
        isYen10 = true;

        // 10円玉と紙を両方取得したらkaiwa15を表示
        isKaiwa15 = isYen10 && isKami;
        kokkurisan.SetActive(isKaiwa15);

    }

    // 紙を取得した際の処理
    public void GetKami()
    {
        gm.SetisFlag(3, true);
        isKami = true;

        // 10円玉と紙を両方取得したらkaiwa15を表示
        isKaiwa15 = isYen10 && isKami;
        kokkurisan.SetActive(isKaiwa15);

        if(isKami)
        {
            kaiwa14.SetActive(false);
        }
    }        

}
