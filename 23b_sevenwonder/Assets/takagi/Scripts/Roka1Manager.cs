using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roka1Manager : MonoBehaviour
{

    GameManager gm;

    [SerializeField] GameObject KaiwaFirst;
    [SerializeField] GameObject StopRouka;
    [SerializeField] GameObject StopHokenshitsu;
    [SerializeField] GameObject HokenshitsuDoor;
    [SerializeField] GameObject HokenshitsuKeyOpenMessage;

    //�e��t���O
    bool isKaiwaFirst; //�ŏ��̉�b��\���������ǂ���
    bool isLibrary; //�ŏ��̐}���قɂ��������ǂ���
    bool isHokenKey; //�ی����̃J�M����肵�����ǂ���
    bool isHokenOpen; //�ی������J�������ǂ���

    // Start is called before the first frame update
    void Start()
    {
        //GameManager�̎擾
        GameObject tmp;
        tmp = GameObject.Find("GameManager");
        gm = tmp.GetComponent<GameManager>();
        if (!gm)
        {
            Debug.Log("Roka1Manager.cs: GameManager��������܂���");
        }


        //�ŏ��̉�b�����\������Ă��邩�ǂ����̏���
        isKaiwaFirst = gm.GetisKaiwaFirst();

        if (isKaiwaFirst)
        {
            KaiwaFirst.SetActive(false);
        }
        else
        {
            KaiwaFirst.SetActive(true);
        }

        //�}���قɍs�������ƁB�n��L���ɍs����悤�ɂȂ�
        isLibrary = gm.GetLibrarySecond();
        if (isLibrary)
        {
            //�n��L�����J��
            StopRouka.SetActive(false);
        }
        else
        {
            //�ʂ�Ȃ�
            StopRouka.SetActive(true);
        }

        //�ی����̌�����肵�Ă���
        isHokenKey = gm.GetisHokenKey();
        if (isHokenKey)
        {
            HokenshitsuKeyOpenMessage.SetActive(true);
            HokenshitsuDoor.SetActive(false);
            StopHokenshitsu.SetActive(false);
        }
        else
        {
            HokenshitsuKeyOpenMessage.SetActive(false);
            HokenshitsuDoor.SetActive(false);
            StopHokenshitsu.SetActive(true);
        }


        //�ی������J���Ă���
        isHokenOpen= gm.GetisHokenOpen();
        if (isHokenOpen)
        {
            HokenshitsuDoor.SetActive(true);
            HokenshitsuKeyOpenMessage.SetActive(false);
            StopHokenshitsu.SetActive(false);
        }
        else
        {
            HokenshitsuDoor.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void KaiwaStart()
    {
        gm.KaiwaNau();
    }

    public void KaiwaStop()
    {
        gm.KaiwaOwatade();
    }

    public void SetisKaiwaFirst(bool t)
    {
        isKaiwaFirst = t;
        gm.SetisKaiwaFirst(t);
    }

    public bool GetisKaiwaFirst()
    {
        return isKaiwaFirst;
    }

    public void HideKaiwaFirst()
    {
        KaiwaFirst.SetActive(false);
    }

    public void SetisHokenOpen()
    {
        gm.SetisHokenOpen(true);
    }
}
