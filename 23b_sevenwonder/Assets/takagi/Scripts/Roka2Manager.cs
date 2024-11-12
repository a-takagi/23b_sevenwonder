using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roka2Manager : MonoBehaviour
{

    GameManager gm;

    //�e��t���O
    bool isBaby; //�Ԃ�������肵�Ă��邩�i�H��Ō�w�Ɖ�����ǂ����j
    bool isKagamiwithBaby; //���̗H��Ԃ����Ɖ��
    bool isKokkuriCleared; //�������肳����N���A�������ǂ����i�^�钆�̎��ƊJ�n�j
    bool isMayonakaKaiwaFirst; //Fist Mayonaka Kaiwa in Roka2

    //��bPrefab
    [SerializeField] GameObject KagamiKaiwaFirst; //���̕�ŏ��̉�b
    [SerializeField] GameObject KagamiKaiwawithBaby; //���̕�Ԃ����ƍĉ�̉�b
    [SerializeField] GameObject KagamiRoukaStop; //���̕�̘L���X�g�b�v
    [SerializeField] GameObject MayonakaKaiwaFirst; //�^�钆�̎��ƍŏ��̉�b

    // Start is called before the first frame update
    void Start()
    {
        //GameManager�̎擾
        GameObject tmp;
        tmp = GameObject.Find("GameManager");
        gm = tmp.GetComponent<GameManager>();
        if (!gm)
        {
            Debug.Log("Roka2Manager.cs: GameManager��������܂���");
        }

        //�t���O�`�F�b�N gm����Q�b�g����
        isBaby = gm.GetisFlag(20);
        isKagamiwithBaby = gm.GetisFlag(21);
        isKokkuriCleared = gm.GetisFlag(22);
        isMayonakaKaiwaFirst = gm.GetisFlag(28);

        //�Ԃ�������肵����
        if (isBaby)
        {
            KagamiKaiwaFirst.SetActive(false);
            KagamiRoukaStop.SetActive(false);
            KagamiKaiwawithBaby.SetActive(true);
        }
        else
        {
            KagamiKaiwaFirst.SetActive(true);
            KagamiRoukaStop.SetActive(true);
            KagamiKaiwawithBaby.SetActive(false);
        }


        //�������肳����N���A������
        if (isKokkuriCleared && (!isMayonakaKaiwaFirst))
        {
            MayonakaKaiwaFirst.SetActive(true);
        }
        else
        {
            MayonakaKaiwaFirst.SetActive(false);
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

    public void MayonakaKaiwaEnd(){
        gm.SetisFlag(28,true);
    }

}
