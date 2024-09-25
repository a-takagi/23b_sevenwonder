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

    GameManager gm;

    int kiranum = 0;

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
            Debug.Log("Door.cs: GameManagerが見つかりません");
        }
                tarohanakaiwa2obj.SetActive(false);

        //2回目かどうかの処理
        gm.getLibrary;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void IncreaseKira(){
        kiranum++;
        if(kiranum>=3){
        tarohanaobj.SetActive(true);
        }
        gm.SetLibrarySecond(true);
    }

    public void TaroHana2Show(){
        //2回目の会話を表示したい

        tarohanakaiwa2obj.SetActive(true);
    }
}