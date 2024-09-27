using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roka1Manager : MonoBehaviour
{

    GameManager gm;

    [SerializeField] GameObject KaiwaFirst;

    // Start is called before the first frame update
    void Start()
    {
        //GameManager‚ÌŽæ“¾
        GameObject tmp;
        tmp = GameObject.Find("GameManager");
        gm = tmp.GetComponent<GameManager>();
        if (!gm)
        {
            Debug.Log("Roka1Manager.cs: GameManager‚ªŒ©‚Â‚©‚è‚Ü‚¹‚ñ");
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
}
