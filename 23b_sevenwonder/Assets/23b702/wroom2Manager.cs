using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class wroom2Manager : MonoBehaviour
{
    GameManager gm;
    ItemManager im;

    [SerializeField] GameObject kokkurisan;
    [SerializeField] GameObject kaiwa12;
    [SerializeField] GameObject kaiwa13;
    [SerializeField] GameObject kaiwa14;
    [SerializeField] GameObject kaiwa15;
    [SerializeField] GameObject kaiwa16;
 
    // 各種フラグ
    bool isKaiwa12; // 始め会話の表示をしたかどうか
    bool isYen10;   // 10円玉を入手したかどうか
    bool isKami;    // こっくりさんの紙を入手したかどうか
    bool isKaiwa15; // 10円玉とこっくりさんの紙を取得したかどうか
    bool isKaiwa16; // 会話

    // Start is called before the first frame update
    void Start()
    {
        kokkurisan.SetActive(false);  //こっくりさんは最初は非アクティブ
        kaiwa16.SetActive(false);    

        // GameManagerの取得
        GameObject tmp = GameObject.Find("GameManager");
        gm = tmp.GetComponent<GameManager>();
        if (!gm)
        {
            Debug.Log("wroom2Manager.cs: GameManagerが見つかりません");
        }

        // ItemManagerの取得
        GameObject imp = GameObject.Find("ItemManger");
        im = imp.GetComponent<ItemManager>();
        if (!im)
        {
            Debug.Log("wroom2Manager.cs: ItemManagerが見つかりません");
        }
      
    }

    // Update is called once per frame
    void Update()
    {   // kaiwa13 と kaiwa14 がnull（Destroyされた状態）ならば、kokkurisanをアクティブ化する
        if (kaiwa13 == null && kaiwa14 == null)
        {
            kokkurisan.SetActive(true);
            Debug.Log("kokkurisan activated after kaiwa13 and kaiwa14 were destroyed.");
        }
    }


    // 10円玉を取得
    public void Coin()
    {
        im.GetCoin();
    }

    // こっくりさんの紙を取得
    public void KokkuriSheet()
    {
        im.GetKokkuriSheet();
    }

    // お守り消滅
    public void OmamoriNakunaru()
    {
        im.LostOmamori();
    }

    // 会話開始時の処理
    public void KaiwaNau()
    {
        gm.KaiwaNau();
    }

    // 会話終了時の処理
    public void KaiwaOwatade()
    {
        gm.KaiwaOwatade();
    }

    public void GameOver()
    {
			Debug.Log ("GameOver"); //デバッグ用に文字を表示
            SceneManager.LoadScene("Title");
    }
}
