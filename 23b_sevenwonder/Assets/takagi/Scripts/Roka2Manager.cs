using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roka2Manager : MonoBehaviour
{

    GameManager gm;

    //各種フラグ
    bool isBaby; //赤ちゃんを入手しているか（幽霊看護婦と会えたかどうか）
    bool isKagamiwithBaby; //鏡の幽霊赤ちゃんと会えた
    bool isKokkuriCleared; //こっくりさんをクリアしたかどうか（真夜中の授業開始）

    //会話Prefab
    [SerializeField] GameObject KagamiKaiwaFirst; //鏡の母最初の会話
    [SerializeField] GameObject KagamiKaiwawithBaby; //鏡の母赤ちゃんと再会の会話
    [SerializeField] GameObject KagamiRoukaStop; //鏡の母の廊下ストップ
    [SerializeField] GameObject MayonakaKaiwaFirst; //真夜中の授業最初の会話

    // Start is called before the first frame update
    void Start()
    {
        //GameManagerの取得
        GameObject tmp;
        tmp = GameObject.Find("GameManager");
        gm = tmp.GetComponent<GameManager>();
        if (!gm)
        {
            Debug.Log("Roka2Manager.cs: GameManagerが見つかりません");
        }

        //フラグチェック gmからゲットする
        isBaby = gm.GetisFlag(20);
        isKagamiwithBaby = gm.GetisFlag(21);
        isKokkuriCleared = gm.GetisFlag(22);

        //赤ちゃんを入手したか
        if (isBaby)
        {
            KagamiKaiwaFirst.SetActive(false);
            KagamiRoukaStop.SetActive(false);
            KagamiKaiwawithBaby.SetActive(true);
        }
        else
        {
            KagamiKaiwaFirst.SetActive(true);
            KagamiRoukaStop.SetActive(true);
            KagamiKaiwawithBaby.SetActive(false);
        }


        //こっくりさんをクリアしたか
        if (isKokkuriCleared)
        {
            MayonakaKaiwaFirst.SetActive(true);
        }
        else
        {
            MayonakaKaiwaFirst.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void KaiwaStart()
    {
        gm.KaiwaNau();
    }

    public void KaiwaStop()
    {
        gm.KaiwaOwatade();
    }

}
