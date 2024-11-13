using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

[RequireComponent(typeof(Flowchart))]
public class PcKiraKira : MonoBehaviour
{
    [SerializeField]  
    string message = "";

    [SerializeField]
    GameObject kaiwa;
    Flowchart flowchart;

    PcRoomManager Pm;
    
    void OnTriggerStay2D(Collider2D col){
    if(Input.GetButtonDown("Fire1")){
        StartCoroutine(Talk());
    }
    }

    IEnumerator Talk(){
        if(kaiwa == null){
            Debug.Log("PcKiraKira.cs : Kaiwa is Null");
        }
        if(flowchart ==null){
            Debug.Log("PcKiraKira.cs : FlowChart is Null");
        }
        flowchart.SendFungusMessage(message);
        yield return new WaitUntil(() => flowchart.GetExecutingBlocks().Count == 0);
        this.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject tmp;
        tmp = GameObject.Find("PcRoomManager");
        Pm=tmp.GetComponent<PcRoomManager>();
        if (!Pm)
        {
            Debug.Log("Door.cs: LibraryManagerが見つかりませんでした");
        }

        flowchart=kaiwa.GetComponent<Flowchart>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

