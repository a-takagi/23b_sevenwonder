using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{

    //�}�b�v�̃X�^�[�g�ʒu�̔ԍ��B������o�Ă�������̑O�B�����łȂ��ꍇ�����
    public int StartPosition;

    //Soawn�ʒu�B�ԍ���StartPosition�ƈ�v�����邱��
    [SerializeField]
    GameObject[] SpawnPoint;
    //��L�͂��܂������܂���I�Ȃ��Ȃ�V�[���J�ڂ����Ⴄ�ƁAGameObject�������邩��

    public bool setSpawn = false;

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
        if (setSpawn == false)
        {
            PlayerSpawn();
            setSpawn = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (setSpawn == false)
        {
            PlayerSpawn();
            setSpawn = true;
        }
    }

    public void SetSpawnPointNum(int n)
    {
        StartPosition = n;
        Debug.Log("GameManager:SetSpawnPointNum: StartPosition:" + n);
    }

    public void SetSpawnFlag(bool t)
    {
        setSpawn = t;
    }

    private void PlayerSpawn()
    {
        GameObject tmp = GameObject.Find("Player");
        tmp.transform.SetPositionAndRotation(SpawnPoint[StartPosition].transform.position, Quaternion.identity);

        Debug.Log("GameManager:PlayerSpawn: StartPosition:" + StartPosition);

    }
}
