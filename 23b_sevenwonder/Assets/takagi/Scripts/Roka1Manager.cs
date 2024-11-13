using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Roka1Manager : MonoBehaviour
{

    GameManager gm;
    GameObject Player;
    GameObject PlayerSprite;

    [SerializeField] GameObject KaiwaFirst;
    [SerializeField] GameObject StopRouka;
    [SerializeField] GameObject StopHokenshitsu;
    [SerializeField] GameObject HokenshitsuDoor;
    [SerializeField] GameObject HokenshitsuKeyOpenMessage;
    [SerializeField] GameObject Ghost1;
    [SerializeField] GameObject Ghost2;
    [SerializeField] GameObject ShokuinshitsuDoor;
    [SerializeField] GameObject TrueEnd;
    [SerializeField] GameObject NomalEnd;
    [SerializeField] GameObject TrueEndObjects;
    [SerializeField] GameObject NomalEndObjects;


    //�e��t���O
    bool isKaiwaFirst; //�ŏ��̉�b��\���������ǂ���
    bool isLibrary; //�ŏ��̐}���قɂ��������ǂ���
    bool isHokenKey; //�ی����̃J�M����肵�����ǂ���
    bool isHokenOpen; //�ی������J�������ǂ���
    bool isFamilyPhoto;
    bool isGirl;


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

        Player = GameObject.Find("Player");
        if(!Player){
            Debug.Log("Roka1Manager.cs : Player Not Found");
        }else{
            PlayerSprite = Player.transform.Find("right").gameObject;
        }

        //�t���O�`�F�b�N gm����Q�b�g����

        //�ŏ��̉�b�����\������Ă��邩�ǂ����̏���
        isKaiwaFirst = gm.GetisKaiwaFirst();
        //isKaiwaFirst = gm.GetisFlag(10); //�ŏ��̉�b

        if (isKaiwaFirst)
        {
            KaiwaFirst.SetActive(false);
        }
        else
        {
            KaiwaFirst.SetActive(true);
        }

        //�}���قɍs�������ƁB�E�����ɍs����悤�ɂȂ�
        isLibrary = gm.GetLibrarySecond();
        //isLibrary=gm.GetisFlag(11); //�}����
        
        if (isLibrary)
        {
            //�E�������J��
            StopRouka.SetActive(false);
            ShokuinshitsuDoor.SetActive(true);
        }
        else
        {
            //�ʂ�Ȃ�
            StopRouka.SetActive(true);
            ShokuinshitsuDoor.SetActive(false);
        }

        //�ی����̌�����肵�Ă���
        isHokenKey = gm.GetisHokenKey();
        //isHokenKey= gm.GetisFlag(12); //�ی����̃J�M

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
        //isHokenOpen=gm.GetisFlag(13); //�ی������J���Ă���
        if (isHokenOpen)
        {
            HokenshitsuDoor.SetActive(true);
            HokenshitsuKeyOpenMessage.SetActive(false);
            StopHokenshitsu.SetActive(false);
            Ghost1.SetActive(false);
            Ghost2.SetActive(true);
        }
        else
        {
            HokenshitsuDoor.SetActive(false);
            Ghost1.SetActive(true);
            Ghost2.SetActive(false);
        }

        //GameClerObjects
        isGirl = gm.GetSpanwedKahanSin();
        if(gm.GetSpanwedKahanSin()){
            isFamilyPhoto = gm.GetisFlag(29);
            if(isFamilyPhoto){
                //TrueEnd
                TrueEnd.SetActive(true);
            }else{
                //NomalEnd
                NomalEnd.SetActive(true);
            }
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
        gm.SetisFlag(10, true);
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

    public void StartNomalEnding(){
        PlayerSprite.GetComponent<Renderer>().enabled = false;
        NomalEndObjects.SetActive(true);
    }

    public void EndNomalEnding(){
        SceneManager.LoadScene("NormalEnd");
    }

    public void StartTrueEnding(){
        PlayerSprite.GetComponent<Renderer>().enabled = false;
        TrueEndObjects.SetActive(true);
    }

    public void EndTrueEnding(){
        SceneManager.LoadScene("TrueEnd");
    }
}