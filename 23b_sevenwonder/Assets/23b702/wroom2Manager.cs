using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class wroom2Manager : MonoBehaviour
{

    GameManager gm;

    [SerializeField] GameObject kaiwa12;
    [SerializeField] GameObject kaiwa13;
    [SerializeField] GameObject kaiwa14;
    [SerializeField] GameObject kaiwa15;
    [SerializeField] GameObject kaiwa16;
    [SerializeField] GameObject kaiwa17;
    [SerializeField] GameObject kirakira;
    [SerializeField] GameObject kirakira2;
    [SerializeField] GameObject kirakira3;

    int kiranum;

    //�e��t���O
    bool isKaiwa12; //�n�߉�b�̕\�����������ǂ���
    bool isYen10; //10�~�ʂ���肵�����ǂ���
    bool isKami;  //�������肳��̎�����肵�����ǂ���
    bool isKaiwa15; //10�~�ʂƂ������肳��̎����擾�������ǂ���
    bool isKaiwa17; //��b 

    // Start is called before the first frame update
    void Start()
    {
        kirakira3.SetActive(false);
        //GameManager�̎擾
        GameObject tmp;
        tmp = GameObject.Find("GameManager");
        gm = tmp.GetComponent<GameManager>();
        if (!gm) 
        {
            Debug.Log("w-room-2Manager.cs; GameManager��������܂���");
        }

        //��b12�̕\������Ă��邩�ǂ����̏���
        isKaiwa12 = gm.GetisFlag(7);
        if (gm.GetisFlag(7) == true)
        {
            kaiwa12.SetActive(false);
        }
        else
        {
            kaiwa12.SetActive(true);
        }

        //10�~�ʂ���肵�Ă���
        isYen10 = gm.GetisFlag(2);
        if (gm.GetisFlag(2) == true)
        {
            kaiwa13.SetActive(false);
        }
        else
        {
            kaiwa13.SetActive(true);
        }

        //�������肳��̋V���̎�����肵�Ă���
        isKami = gm.GetisFlag(3);
        if (gm.GetisFlag(3) == true)
        {
            kaiwa14.SetActive(false);
        }
        else
        {
            kaiwa14.SetActive(true);
        }

        //�������肳��̃L���L��
        if (gm.GetisFlag(8) == true)
        {
            kiranum = 2;
            kirakira.SetActive(false);
            kirakira2.SetActive(false);

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseKira()
    {
        kiranum++;
        if(kiranum >= 2) 
        {
            kirakira3.SetActive (true);
        }
        gm.SetisFlag(8,true);
    }
    public void KaiwaStart() 
    {
        gm.KaiwaNau();
    }

    public void KaiwaStop()
    {
        gm.KaiwaOwatade();
    }

    public void Get10yen()
    {
        gm.SetisFlag(2, true);
        isYen10 = true;
    }

    public void GetKami()
    {
        gm.SetisFlag (3, true);
        isKami = true;
    }

}
