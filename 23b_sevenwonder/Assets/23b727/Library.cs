using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Library : MonoBehaviour
{
    [SerializeField]
    GameObject kirakira1;

    [SerializeField]
    GameObject kirakira2;

    [SerializeField]
    GameObject kirakira3;

    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        //GameManager‚ÌŽæ“¾
        GameObject tmp;
        tmp = GameObject.Find("GameManager");
        gm=tmp.GetComponent<GameManager>();
        if (!gm)
        {
            Debug.Log("Door.cs: GameManager‚ªŒ©‚Â‚©‚è‚Ü‚¹‚ñ");
        }

    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
