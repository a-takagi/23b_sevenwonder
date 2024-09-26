using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

[RequireComponent(typeof(Flowchart))]
public class KirakiraS : MonoBehaviour
{
    [SerializeField]  
    string message = "";

    [SerializeField]
    GameObject kaiwa;
    Flowchart flowchart;

    GameManager gm;
    
    void OnTriggerStay2D(Collider2D col){
    if(Input.GetButtonDown("Fire1")){
        StartCoroutine(Talk());
    }
    }

    IEnumerator Talk(){
        flowchart.SendFungusMessage(message);
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
            Debug.Log("Door.cs: GameManagerが見つかりません");
        }

        flowchart=kaiwa.GetComponent<Flowchart>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
