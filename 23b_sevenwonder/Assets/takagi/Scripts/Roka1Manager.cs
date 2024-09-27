using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roka1Manager : MonoBehaviour
{

    GameManager gm;

    [SerializeField] GameObject KaiwaFirst;
    [SerializeField] GameObject StopRouka;
    [SerializeField] GameObject StopHokenshitsu;
    [SerializeField] GameObject HokenshitsuDoor;
    [SerializeField] GameObject HokenshitsuKeyOpenMessage;

    //各種フラグ
    bool isKaiwaFirst; //最初の会話を表示したかどうか
    bool isLibrary; //最初の図書館にいったかどうか
    bool isHokenKey; //保健室のカギを入手したかどうか
    bool isHokenOpen; //保健室が開いたかどうか

    // Start is called before the first frame update
    void Start()
    {
        //GameManagerの取得
        GameObject tmp;
        tmp = GameObject.Find("GameManager");
        gm = tmp.GetComponent<GameManager>();
        if (!gm)
        {
            Debug.Log("Roka1Manager.cs: GameManagerが見つかりません");
        }


        //最初の会話文が表示されているかどうかの処理
        isKaiwaFirst = gm.GetisKaiwaFirst();

        if (isKaiwaFirst)
        {
            KaiwaFirst.SetActive(false);
        }
        else
        {
            KaiwaFirst.SetActive(true);
        }

        //図書館に行ったあと。渡り廊下に行けるようになる
        isLibrary = gm.GetLibrarySecond();
        if (isLibrary)
        {
            //渡り廊下が開く
            StopRouka.SetActive(false);
        }
        else
        {
            //通れない
            StopRouka.SetActive(true);
        }

        //保健室の鍵を入手している
        isHokenKey = gm.GetisHokenKey();
        if (isHokenKey)
        {
            HokenshitsuKeyOpenMessage.SetActive(true);
            HokenshitsuDoor.SetActive(false);
            StopHokenshitsu.SetActive(false);
        }
        else
        {
            HokenshitsuKeyOpenMessage.SetActive(false);
            HokenshitsuDoor.SetActive(false);
            StopHokenshitsu.SetActive(true);
        }


        //保健室が開いている
        isHokenOpen= gm.GetisHokenOpen();
        if (isHokenOpen)
        {
            HokenshitsuDoor.SetActive(true);
            HokenshitsuKeyOpenMessage.SetActive(false);
            StopHokenshitsu.SetActive(false);
        }
        else
        {
            HokenshitsuDoor.SetActive(false);
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

    public void SetisKaiwaFirst(bool t)
    {
        isKaiwaFirst = t;
        gm.SetisKaiwaFirst(t);
    }

    public bool GetisKaiwaFirst()
    {
        return isKaiwaFirst;
    }

    public void HideKaiwaFirst()
    {
        KaiwaFirst.SetActive(false);
    }

    public void SetisHokenOpen()
    {
        gm.SetisHokenOpen(true);
    }
}
