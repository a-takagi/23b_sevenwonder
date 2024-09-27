using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roka1Manager : MonoBehaviour
{

    GameManager gm;

    [SerializeField] GameObject KaiwaFirst;
    bool isKaiwaFirst;

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

        //��b�����\������Ă��邩�ǂ����̏���
        isKaiwaFirst = gm.GetisKaiwaFirst();

        if (isKaiwaFirst)
        {
            KaiwaFirst.SetActive(false);
        }
        else
        {
            KaiwaFirst.SetActive(true);
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
}
