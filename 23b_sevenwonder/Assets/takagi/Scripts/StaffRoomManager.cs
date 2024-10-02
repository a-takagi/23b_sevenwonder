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
        //GameManager�̎擾
        GameObject tmp;
        tmp = GameObject.Find("GameManager");
        gm = tmp.GetComponent<GameManager>();
        if (!gm)
        {
            Debug.Log("StaffRoomManager.cs: GameManager��������܂���");
        }

        //�ی����̃J�M����肵�����ǂ���
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
