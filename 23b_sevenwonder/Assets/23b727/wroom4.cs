using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class wroom4 : MonoBehaviour
{
    
    GameManager gm;
    ItemManager im;

    [SerializeField] GameObject kaiwa1;
    [SerializeField] GameObject kaiwa2;
    [SerializeField] GameObject kaiwa3;

    // Start is called before the first frame update
    void Start()
    {
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
    {
        
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
			Debug.Log ("GameOver�V�[���ړ�"); //�f�o�b�O�p�ɕ�����\��
            SceneManager.LoadScene("GameOver");
    }
    public void PCroom()
    {
			Debug.Log ("PCroom�V�[���ړ�"); //�f�o�b�O�p�ɕ�����\��
            SceneManager.LoadScene("e-pcroom-3");
    }

    public void StartLesson()
    {
        Debug.Log("wroom4.cs : LessonStart");
        gm.SetisFlag(25,true);
    }
    public void ClearLesson()
    {
        Debug.Log("wroom4.cs : LessonClear");
        gm.SetisFlag(25,false);
        gm.SetisFlag(26,true);
    }
}
