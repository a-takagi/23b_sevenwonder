using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class wroom2Manager : MonoBehaviour
{
    GameManager gm;
    ItemManager im;

    [SerializeField] GameObject kokkurisan;
    [SerializeField] GameObject kaiwa12;
    [SerializeField] GameObject kaiwa13;
    [SerializeField] GameObject kaiwa14;
    [SerializeField] GameObject kaiwa15;
    [SerializeField] GameObject kaiwa16;
 
    // �e��t���O
    bool isKaiwa12; // �n�߉�b�̕\�����������ǂ���
    bool isYen10;   // 10�~�ʂ���肵�����ǂ���
    bool isKami;    // �������肳��̎�����肵�����ǂ���
    bool isKaiwa15; // 10�~�ʂƂ������肳��̎����擾�������ǂ���
    bool isKaiwa16; // ��b

    // Start is called before the first frame update
    void Start()
    {
        kokkurisan.SetActive(false);  //�������肳��͍ŏ��͔�A�N�e�B�u
        kaiwa16.SetActive(false);    

        // GameManager�̎擾
        GameObject tmp = GameObject.Find("GameManager");
        gm = tmp.GetComponent<GameManager>();
        if (!gm)
        {
            Debug.Log("wroom2Manager.cs: GameManager��������܂���");
        }

        // ItemManager�̎擾
        GameObject imp = GameObject.Find("ItemManger");
        im = imp.GetComponent<ItemManager>();
        if (!im)
        {
            Debug.Log("wroom2Manager.cs: ItemManager��������܂���");
        }
      
    }

    // Update is called once per frame
    void Update()
    {   // kaiwa13 �� kaiwa14 ��null�iDestroy���ꂽ��ԁj�Ȃ�΁Akokkurisan���A�N�e�B�u������
        if (kaiwa13 == null && kaiwa14 == null)
        {
            kokkurisan.SetActive(true);
            Debug.Log("kokkurisan activated after kaiwa13 and kaiwa14 were destroyed.");
        }
    }


    // 10�~�ʂ��擾
    public void Coin()
    {
        im.GetCoin();
    }

    // �������肳��̎����擾
    public void KokkuriSheet()
    {
        im.GetKokkuriSheet();
    }

    // ��������
    public void OmamoriNakunaru()
    {
        im.LostOmamori();
    }

    // ��b�J�n���̏���
    public void KaiwaNau()
    {
        gm.KaiwaNau();
    }

    // ��b�I�����̏���
    public void KaiwaOwatade()
    {
        gm.KaiwaOwatade();
    }

    public void GameOver()
    {
			Debug.Log ("GameOver"); //�f�o�b�O�p�ɕ�����\��
            SceneManager.LoadScene("Title");
    }
}
