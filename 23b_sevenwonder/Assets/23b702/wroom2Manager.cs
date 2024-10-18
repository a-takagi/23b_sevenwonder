using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class wroom2Manager : MonoBehaviour
{

    GameManager gm;

    ItemManager im;

    [SerializeField] GameObject kirakira;
    [SerializeField] GameObject kirakira2;
    [SerializeField] GameObject kirakira3;
    [SerializeField] GameObject kokkurisan;
    [SerializeField] GameObject kaiwa12;
    [SerializeField] GameObject kaiwa13;
    [SerializeField] GameObject kaiwa14;
    [SerializeField] GameObject kaiwa15;
    [SerializeField] GameObject kaiwa16;
    [SerializeField] GameObject kaiwa17;

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
        kokkurisan.SetActive(false);
        kaiwa16.SetActive(false);
        kaiwa17.SetActive(false);
        //GameManager�̎擾
        GameObject tmp;
        tmp = GameObject.Find("GameManager");
        gm = tmp.GetComponent<GameManager>();
        if (!gm) 
        {
            Debug.Log("wroom2Manager.cs; GameManager��������܂���");
        }

        //ItemManager�̎擾
        GameObject imp;
        imp = GameObject.Find("ItemManger");
        im=imp.GetComponent<ItemManager>();
        if (!im)
        {
            Debug.Log("wroom2Manager.cs: ItemManger��������܂���");
        }


        //10�~�ʂ���肵�Ă���
        isYen10 = gm.GetisFlag(2);
        if (isYen10 == true)
        {
            kaiwa13.SetActive(false);
        }
        else
        {
            kaiwa13.SetActive(true);
        }

        //�������肳��̋V���̎�����肵�Ă���
        isKami = gm.GetisFlag(3);
        if (isKami == true)
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
            isKaiwa15 = isYen10 && isKami;

            kokkurisan.SetActive(true);
            kaiwa13.SetActive(false);
            kaiwa14.SetActive(false);
            
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void Coin(){
        im.GetCoin();
    }
        
    public void KokkuriSheet(){
        im.GetKokkuriSheet();
    }

    public void KaiwaNau() 
    {
        gm.KaiwaNau();
    }

    public void KaiwaOwatade()
    {
        gm.KaiwaOwatade();
    }

    public void Get10yen()
    {
        gm.SetisFlag(2, true);
        isYen10 = true;

        // 10�~�ʂƎ��𗼕��擾������kaiwa15��\��
        isKaiwa15 = isYen10 && isKami;
        kokkurisan.SetActive(isKaiwa15);

    }

    // �����擾�����ۂ̏���
    public void GetKami()
    {
        gm.SetisFlag(3, true);
        isKami = true;

        // 10�~�ʂƎ��𗼕��擾������kaiwa15��\��
        isKaiwa15 = isYen10 && isKami;
        kokkurisan.SetActive(isKaiwa15);

        if(isKami)
        {
            kaiwa14.SetActive(false);
        }
    }        

}
