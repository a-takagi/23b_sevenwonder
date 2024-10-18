using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonMonoBehaviour<GameManager>
{

    //Let's New Array
    [SerializeField]
    Vector3[] SpawnPointPos;
    [SerializeField]
    int NowSpawnNum;

    public bool setPlayerSpawn = false;


    //会話中かどうかのフラグです[Byさいとー]
    //会話中：true 会話してない：false
    private bool KaiwaFlag = false;

    //いろいろなフラグを配列で管理する。番号はGoogleSpreadsheet参照
    [SerializeField] bool[] isFlag = new bool[100];

    //各部屋のフラグをここに列挙。GetSetを作ること
    [SerializeField] bool isKaiwaFirst; //校舎に入ったところの会話を見たフラグ
    [SerializeField] bool LibrarySecond = false; //図書館の2回目以降の入室だよフラグ

    [SerializeField] bool HealthRoomSecond = false; //保健室の2回目以降の入室だよフラグ
    [SerializeField] bool isHokenKey = false; //保健室のカギを入手したかどうか
    [SerializeField] bool isHokenOpen = false; //保健室が開いているかどうか

    [SerializeField] bool isPcKey = false;      //Pc教室の鍵を持っているかどうか
    [SerializeField] bool PcRoomSecond = false; //Pc教室が2回目の入室かどうか


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
        Debug.Log("GameManager:Start:");
        //PlayerSpawn();
         PlayerSpawnPos();

    }

    // Update is called once per frame
    void Update()
    {
        if (setPlayerSpawn == false)
        {
            //PlayerSpawn();
            PlayerSpawnPos();
        }
    }

    public void setPlayerSpawnFlag(bool t)
    {
        Debug.Log("GameManager:setPlayerSpawnFlag:" + t+ "に設定します");
        setPlayerSpawn = t;
    }

    //Let's New Method
    public void PlayerSpawnPos(){
        if (setPlayerSpawn == false)
        {
            GameObject tmp = GameObject.Find("Player");
            tmp.transform.SetPositionAndRotation(SpawnPointPos[NowSpawnNum], Quaternion.identity);
            Debug.Log("GameManager:PlayerSpawn: StartPosition:" + NowSpawnNum);
            setPlayerSpawn = true;
            Debug.Log("Player Spawned");
            Debug.Log(SceneManager.GetActiveScene().name.ToString());
            Vector3 ggst = tmp.transform.position;
            Debug.Log(ggst.x);
        }else
        {
            //校舎ではないのでスポーンポイントは設定しない
        }
    }

    //Let's New Method
    public void SetSpawnPointPos(int index, Vector3 pos){
        SpawnPointPos[index] = pos;
    }

    //Let's New Method
    public void SetNowSpawnNum(int n){
        NowSpawnNum = n;
    }
    
    //Let's New Method
    public Vector3 GetSpawnPointPos(int index){
        return SpawnPointPos[index];
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

    public bool GetisFlag(int n) {
        return isFlag[n];
    }

    public void SetisFlag(int n, bool t)
    {
        isFlag[n] = t;
    }
}
