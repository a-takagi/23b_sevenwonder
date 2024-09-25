using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonMonoBehaviour<GameManager>
{

    //マップのスタート位置の番号。扉から出てきたら扉の前。そうでない場合入り口
    public int StartPosition;

    //Spawn位置。番号はStartPositionと一致させること
    //SpawnPointのGameObjectはGameManger>SpawnPointListの中に入れて、Inspectorで設定すること
    [SerializeField]
    GameObject[] SpawnPoint;

    public bool setPlayerSpawn = false;

    bool LibrarySecond=false;

    public void Awake()
    {
        if (this != Instance)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("GameManager:Start:SpawnPoint.Length:" + SpawnPoint.Length);
        PlayerSpawn();

    }

    // Update is called once per frame
    void Update()
    {
        if (setPlayerSpawn == false)
        {
            PlayerSpawn();
        }
    }


    public void SetSpawnPointNum(int n)
    {
        StartPosition = n;
        Debug.Log("GameManager:SetSpawnPointNum: StartPosition:" + n);
    }

    public void setPlayerSpawnFlag(bool t)
    {
        Debug.Log("GameManager:setPlayerSpawnFlag:" + t+"に設定します");
        setPlayerSpawn = t;
    }
    public void PlayerSpawn()
    {
        if (setPlayerSpawn == false)
        {
            //校舎だけでSpawnPointを設定する。それ以外は設定しない
            //本番用に後で変更すること
            if (SceneManager.GetActiveScene().name == "roka-1")
            {
                //メイン校舎なので
                GameObject tmp = GameObject.Find("Player");
                tmp.transform.SetPositionAndRotation(SpawnPoint[StartPosition].transform.position, Quaternion.identity);
                Debug.Log("GameManager:PlayerSpawn: StartPosition:" + StartPosition);
                setPlayerSpawn = true;
            }
            else
            {
                //校舎ではないのでスポーンポイントは設定しない
            }
        }
    }

    public void SetLibrarySecond(bool t){
        LibrarySecond=t;

    }
    public bool GetLibrarySecond(){
        return LibrarySecond;
    }

}
