using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

[RequireComponent(typeof(Flowchart))]
public class KiraKira2 : MonoBehaviour
{
    [SerializeField]  
    string message = "";

    [SerializeField]
    GameObject kaiwa;
    Flowchart flowchart;

    [SerializeField]
    private int SentMassage =0 ;

    GameManager gm;
    
    void OnTriggerStay2D(Collider2D col){
    if(Input.GetButtonDown("Fire1")){
        StartCoroutine(Talk());
    }
    }

    IEnumerator Talk(){
        if(SentMassage == 0){
        flowchart.SendFungusMessage(message);
        SentMassage += 1;
        }
        yield return new WaitUntil(() => flowchart.GetExecutingBlocks().Count == 0);
        this.gameObject.SetActive(false);

    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject tmp;
        tmp = GameObject.Find("GameManager");
        gm=tmp.GetComponent<GameManager>();
        if (!gm)
        {
            Debug.Log("Door.cs: GameManager��������܂���");
        }

        flowchart=kaiwa.GetComponent<Flowchart>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
