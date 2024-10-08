using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffRoomManager : MonoBehaviour
{

    GameManager gm;

    [SerializeField] GameObject KeyObject;

    // Start is called before the first frame update
    void Start()
    {
        //GameManagerの取得
        GameObject tmp;
        tmp = GameObject.Find("GameManager");
        gm = tmp.GetComponent<GameManager>();
        if (!gm)
        {
            Debug.Log("StaffRoomManager.cs: GameManagerが見つかりません");
        }

        //保健室のカギを入手したかどうか
        if (gm.GetisHokenKey())
        {
            KeyObject.SetActive(false);
        }
        else
        {
            KeyObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetHokenKey()
    {
        gm.SetisHokenKey(true);
    }
}
