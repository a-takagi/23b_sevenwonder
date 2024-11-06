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

    [SerializeField] GameObject KahanSinSyouzyo;

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

    [SerializeField] bool isHomeWork = false;           //宿題を手に入れたか
    [SerializeField] bool SpawnedKahanSin = false;//下半身少女が出現したか
    [SerializeField] bool KahanSinRoomSecond =false;//下半身少女教室に二回目の入室かどうか


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

            if(SpawnedKahanSin == true){        
            StartCoroutine("SpawnKahanSin");
            }
        }else
        {
            //校舎ではないのでスポーンポイントは設定しない
        }
    }

    private IEnumerator SpawnKahanSin(){
        yield return new WaitForSeconds(1.0f);
        string SceneName = SceneManager.GetActiveScene().name.ToString();
        if(SceneName == "roka-1"  || SceneName == "raka-2" || SceneName == "roka-3" || SceneName == "e-kahanshin"){
        //下半身少女のフラグがONの時1秒後に下半身少女出現
        Instantiate(KahanSinSyouzyo, SpawnPointPos[NowSpawnNum], Quaternion.identity);
        Debug.Log("GameManager:KahanSinSyouzyo: StartPosition:" + NowSpawnNum);
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
        SetisFlag(14, t);

    }
    public bool GetLibrarySecond(){
        return LibrarySecond;
    }

    public void SetHealthRoomSecond(bool t)
    {
        HealthRoomSecond = t;
        SetisFlag(20, t);
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
        SetisFlag(18, t);
    }

    public bool GetisKaiwaFirst()
    {
        return isKaiwaFirst;
    }

    public void SetisHokenKey(bool t)
    {
        isHokenKey = t;
        SetisFlag(12, t);
    }

    public bool GetisHokenKey()
    {
        return isHokenKey;
    }

    public void SetisHokenOpen(bool t)
    {
        isHokenOpen = t;
        SetisFlag(13, t);
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

    public void SetisPcKey(bool t){
        isPcKey = t;
        SetisFlag(15, t);
    }

    public bool GetisPcKey(){
        return isPcKey;
    }

    public void SetPcRoomSecond(bool t){
        PcRoomSecond = t;
        SetisFlag(16, t);
    }

    public bool GetPcRoomSecond(){
        return PcRoomSecond;
    }

    public void SetisHomeWork(bool t){
        isHomeWork = t;
        SetisFlag(17, t);
    }

    public bool GetisHomeWork(){
        return isHomeWork;
    }

    public void SetSpawnedKahanSin(bool t){
        SpawnedKahanSin = t;
        SetisFlag(19, t);
    }

    public bool GetSpanwedKahanSin(){
        return  SpawnedKahanSin;
    }

    public void SetKahanSinRoomSecond(bool t){
        KahanSinRoomSecond = t;
        SetisFlag(9, t);

    }

    public bool GetKahanSinRoomSecond(){
        return KahanSinRoomSecond;
    }

    //PlayerPrefsでFlagをセーブする
    void SaveFlagData()
    {
        int tmp;

        for (int i = 0; i < 100; i++)
        {
            if (isFlag[i])
            {
                tmp = 1;
            }
            else
            {
                tmp = 0;
            }
            PlayerPrefs.SetInt("Flag" + i, tmp);
        }
        PlayerPrefs.Save();
    }

    void LoadFlagData()
    {
        int tmp;

        for(int i = 0; i < 100; i++)
        {
            tmp=PlayerPrefs.GetInt("Flag" + i);
            if (tmp == 1)
            {
                isFlag[i] = true;
            }
            else
            {
                isFlag[i] = false;
            }
        }
    }

}
