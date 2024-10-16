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
        // 最初に全てのオブジェクトを非アクティブにする
        tarohanaobj.SetActive(false);
        tarohanakaiwa1obj.SetActive(false);
        tarohanakaiwa2obj.SetActive(false);
        tarohanakaiwa3obj.SetActive(false);

        // GameManagerの取得
        GameObject tmp; 
        tmp = GameObject.Find("GameManager");
        gm = tmp.GetComponent<GameManager>();
        if (!gm)
        {
            Debug.Log("Library.cs: GameManagerが見つかりません");
        }

        // 2回目以降の処理
        if (gm.GetLibrarySecond() == true)
        {
            kiranum = 3;
            tarohanaobj.SetActive(true);
            kirakira1.SetActive(false);
            kirakira2.SetActive(false);
            kirakira3.SetActive(false);
            TaroHana3Show(); // 2回目以降は別の会話を表示
        }
        else
        {
            // 初回の会話処理
            StartFirstConversation();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // 必要に応じて更新処理をここに追加
    }

    public void IncreaseKira()
    {
        kiranum++;
        if (kiranum >= 3)
        {
            tarohanaobj.SetActive(true);
        }
        gm.SetLibrarySecond(true);
    }

    // 初回の会話フロー
    void StartFirstConversation()
    {
        tarohanakaiwa1obj.SetActive(true); // 最初の会話を表示
        StartCoroutine(WaitAndShowTaroHana2()); // 会話終了後に次の会話を表示
    }

    // tarohanakaiwa1の後にtarohanakaiwa2を表示するコルーチン
    IEnumerator WaitAndShowTaroHana2()
    {
        yield return new WaitForSeconds(5); // 5秒待機（会話が終わるまでの時間）
        tarohanakaiwa1obj.SetActive(false); // 最初の会話を非表示に
        tarohanakaiwa2obj.SetActive(true);  // 次の会話を表示
    }

    // 2回目以降の会話
    public void TaroHana3Show()
    {
        tarohanakaiwa3obj.SetActive(true); // 2回目以降の会話を表示
    }
}
