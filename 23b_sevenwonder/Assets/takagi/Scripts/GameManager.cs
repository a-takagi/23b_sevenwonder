using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{

    //マップのスタート位置の番号。扉から出てきたら扉の前。そうでない場合入り口
    public int StartPosition;

    //Soawn位置。番号はStartPositionと一致させること
    [SerializeField]
    GameObject[] SpawnPoint;
    //上記はうまくいきません！なぜならシーン遷移しちゃうと、GameObjectが消えるから

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
