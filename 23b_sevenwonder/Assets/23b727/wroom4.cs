using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class wroom4 : MonoBehaviour
{
    
    GameManager gm;
    ItemManager im;

    [SerializeField] GameObject kaiwa1;
    [SerializeField] GameObject kaiwa2;
    [SerializeField] GameObject kaiwa3;

    // Start is called before the first frame update
    void Start()
    {
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
    {
        
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
			Debug.Log ("GameOverシーン移動"); //デバッグ用に文字を表示
            SceneManager.LoadScene("GameOver");
    }
}
