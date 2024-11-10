using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    //参照系
    private GameManager gm;
    private ItemManager Im;
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
    }

    // Update is called once per frame
    void Update()
    {
        //クリックした分だけコードを実行しないようにする
        if(Input.GetButton("Fire1")){
           //Countinue処理

            //こっくりさんのコンテニュー
            //こっくりさんの会話中か確認[Flag23番のはず]
            if(gm.GetisFlag(23)){
                Debug.Log("GameOver.cs : ChangeKokkuriScene");
                //Item＆FlagReset
                gm.SetisFlag(2,false);
                gm.SetisFlag(3,false);
                gm.SetisFlag(23,false);
                Im.LostCoin();
                Im.LostKokkuriSheet();

                //SceneChange
                //Kokkuri is DoorNo.14
                gm.SetNowSpawnNum(14);
                SceneManager.LoadScene("w-room-2");
                gm.setPlayerSpawn = false;

            //真夜中授業のコンテニュー
            //MidNightLesson [FlagNo.25]
            }else if(gm.GetisFlag(25)){
                Debug.Log("GameOver.cs : ChangeMayonakaScene");
                //Item&FlagReset
                gm.SetisFlag(25,false);
                
                //SceneChange
                //NightLesson is DoorNo.16
                gm.SetNowSpawnNum(22);
                SceneManager.LoadScene("w-room4-4-2");
                gm.setPlayerSpawn = false;


            //PC教室のコンテニュー
            //PcRoomGameOverFlag No.24
            }else if(gm.GetisFlag(24)){
                Debug.Log("GameOver.cs : ChangePcRoomScene");
                //Item&FlagReset
                gm.SetisFlag(24,false);
                gm.SetisPcKey(false);
                gm.SetPcRoomSecond(false);
                Im.LostPcKey();

                //SceneChange
                //PcRoom is DoorNo.20
                gm.SetNowSpawnNum(20);
                SceneManager.LoadScene("e-pcroom-3");
                gm.setPlayerSpawn = false;
            
            
            }else if(gm.GetSpanwedKahanSin()){
                Debug.Log("GameOver.cs : ChangeKahansinRoomScene");
                //Item&FlagReset
                gm.SetisHomeWork(false);
                gm.SetSpawnedKahanSin(false);
                gm.SetKahanSinRoomSecond(false);
                Im.LostSyukudai();

                //SceneChange
                //KahanSinRoom is No.22
                gm.SetNowSpawnNum(22);
                SceneManager.LoadScene("e-kahanshin");
                gm.setPlayerSpawn = false;
            }

            

            

            //下半身少女のコンテニュー

        }else if(Input.GetButton("Fire3")){
            SceneManager.LoadScene("Title");
        }
    }
}
