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


    //会話中かどうかのフラグです[Byさいとー]
    //会話中：true 会話してない：false
    private bool KaiwaFlag = false;

    //各部屋のフラグをここに列挙。GetSetを作ること
    [SerializeField] bool isKaiwaFirst; //校舎に入ったところの会話を見たフラグ
    [SerializeField] bool LibrarySecond = false; //図書館の2回目以降の入室だよフラグ
    [SerializeField] bool HealthRoomSecond = false; //保健室の2回目以降の入室だよフラグ
    [SerializeField] bool isHokenKey = false; //保健室のカギを入手したかどうか
    [SerializeField] bool isHokenOpen = false; //保健室が開いているかどうか


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
        Debug.Log("GameManager:setPlayerSpawnFlag:" + t+ "に設定します");
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

    public void SetHealthRoomSecond(bool t)
    {
        HealthRoomSecond = t;

    }
    public bool GetHealthRoomSecond()
    {
        return HealthRoomSecond;
    }

    //会話している時に使う
    public void KaiwaNau(){
        KaiwaFlag = true;
    }

    //会話が終わった時に使う
    public void KaiwaOwatade(){
        KaiwaFlag = false;
    }

    public bool GetKaiwaFlag(){
        return KaiwaFlag;
    }
    public void SetKaiwaFlag(bool t)
    {
        KaiwaFlag=t;
    }

    public void SetisKaiwaFirst(bool t)
    {
        isKaiwaFirst = t;
    }

    public bool GetisKaiwaFirst()
    {
        return isKaiwaFirst;
    }

    public void SetisHokenKey(bool t)
    {
        isHokenKey = t;
    }

    public bool GetisHokenKey()
    {
        return isHokenKey;
    }

    public void SetisHokenOpen(bool t)
    {
        isHokenOpen = t;
    }

    public bool GetisHokenOpen()
    {
        return isHokenOpen;
    }
}
