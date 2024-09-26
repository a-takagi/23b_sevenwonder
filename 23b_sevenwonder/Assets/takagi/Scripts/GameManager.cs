using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonMonoBehaviour<GameManager>
{

    //�}�b�v�̃X�^�[�g�ʒu�̔ԍ��B������o�Ă�������̑O�B�����łȂ��ꍇ�����
    public int StartPosition;

    //Spawn�ʒu�B�ԍ���StartPosition�ƈ�v�����邱��
    //SpawnPoint��GameObject��GameManger>SpawnPointList�̒��ɓ���āAInspector�Őݒ肷�邱��
    [SerializeField]
    GameObject[] SpawnPoint;

    public bool setPlayerSpawn = false;

    bool LibrarySecond=false;

    //会話中かどうかのフラグです[Byさいとー]
    //会話中：true 会話してない：false
    private bool KaiwaFlag = false;

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
        Debug.Log("GameManager:setPlayerSpawnFlag:" + t+"�ɐݒ肵�܂�");
        setPlayerSpawn = t;
    }
    public void PlayerSpawn()
    {
        if (setPlayerSpawn == false)
        {
            //�Z�ɂ�����SpawnPoint��ݒ肷��B����ȊO�͐ݒ肵�Ȃ�
            //�{�ԗp�Ɍ�ŕύX���邱��
            if (SceneManager.GetActiveScene().name == "roka-1")
            {
                //���C���Z�ɂȂ̂�
                GameObject tmp = GameObject.Find("Player");
                tmp.transform.SetPositionAndRotation(SpawnPoint[StartPosition].transform.position, Quaternion.identity);
                Debug.Log("GameManager:PlayerSpawn: StartPosition:" + StartPosition);
                setPlayerSpawn = true;
            }
            else
            {
                //�Z�ɂł͂Ȃ��̂ŃX�|�[���|�C���g�͐ݒ肵�Ȃ�
            }
        }
    }

    public void SetLibrarySecond(bool t){
        LibrarySecond=t;

    }
    public bool GetLibrarySecond(){
        return LibrarySecond;
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
    

}
