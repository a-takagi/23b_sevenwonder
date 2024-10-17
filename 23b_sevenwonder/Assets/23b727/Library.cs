using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Library : MonoBehaviour
{
    [SerializeField]
    GameObject kirakira1;

    [SerializeField]
    GameObject kirakira2;

    [SerializeField]
    GameObject kirakira3;

    [SerializeField]
    GameObject tarohanaobj;

    [SerializeField]
    GameObject tarohanakaiwa1obj;

    [SerializeField]
    GameObject tarohanakaiwa2obj;

    [SerializeField]
    GameObject tarohanakaiwa3obj;

    GameManager gm;

    int kiranum;

    // Start is called before the first frame update
    void Start()
    {
        
        tarohanaobj.SetActive(false);
        //GameManagerの取得
        GameObject tmp;
        tmp = GameObject.Find("GameManager");
        gm=tmp.GetComponent<GameManager>();
        if (!gm)
        {
            Debug.Log("Library.cs: GameManagerが見つかりません");
        }
        tarohanakaiwa3obj.SetActive(false);

        //2回目かどうかの処理
        if(gm.GetLibrarySecond()==true){
            kiranum=3;
            tarohanaobj.SetActive(true);
            kirakira1.SetActive(false);
            kirakira2.SetActive(false);
            kirakira3.SetActive(false);
            FirstTarohana();
            tarohanakaiwa2obj.SetActive(false);
            TaroHana3Show();
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

    // 初回の会話フロー
    void FirstTarohana()
    {
        StartCoroutine(TaroHana2Show()); // 会話終了後に次の会話を表示
    }

    // tarohanakaiwa1の後にtarohanakaiwa2を表示
    IEnumerator TaroHana2Show()
    {
        yield return new WaitForSeconds(1); // 1秒待機（会話が終わるまでの時間）
        tarohanakaiwa1obj.SetActive(false); // 最初の会話を非表示に
        tarohanakaiwa2obj.SetActive(true);  // 次の会話を表示
        tarohanakaiwa2obj.SetActive(false);  // 次の会話を表示
    }

    public void IncreaseKira(){
        kiranum++;
        if(kiranum>=3){
        tarohanaobj.SetActive(true);
        }
        gm.SetLibrarySecond(true);
    }
   
    public void TaroHana3Show(){
        //2回目の会話を表示したい
       this.tarohanakaiwa3obj.SetActive(true);
    }
}