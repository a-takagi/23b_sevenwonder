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

    int kiranum;

    // Start is called before the first frame update
    void Start()
    {
        
        tarohanaobj.SetActive(false);
        //GameManager‚ÌŽæ“¾
        GameObject tmp;
        tmp = GameObject.Find("GameManager");
        gm=tmp.GetComponent<GameManager>();
        if (!gm)
        {
            Debug.Log("Door.cs: GameManager‚ªŒ©‚Â‚©‚è‚Ü‚¹‚ñ");
        }
        tarohanakaiwa2obj.SetActive(false);

        //2‰ñ–Ú‚©‚Ç‚¤‚©‚Ìˆ—
        if(gm.GetLibrarySecond()==true){
            kiranum=3;
            tarohanaobj.SetActive(true);
            kirakira1.SetActive(false);
            kirakira2.SetActive(false);
            kirakira3.SetActive(false);
            TaroHana2Show();
            tarohanakaiwa1obj.SetActive(false);
        }
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
        //2‰ñ–Ú‚Ì‰ï˜b‚ð•\Ž¦‚µ‚½‚¢

        this.tarohanakaiwa2obj.SetActive(true);
    }
}