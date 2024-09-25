using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

[RequireComponent(typeof(Flowchart))]
public class Kirakira : MonoBehaviour
{
    [SerializeField]  
    string message = "";

    [SerializeField]
    GameObject kaiwa;
    Flowchart flowchart;

    Library lm;
    
    void OnTriggerStay2D(Collider2D col){
    if(Input.GetButtonDown("Fire1")){
        StartCoroutine(Talk());
    }
    }

    IEnumerator Talk(){
        flowchart.SendFungusMessage(message);
        yield return new WaitUntil(() => flowchart.GetExecutingBlocks().Count == 0);
        lm.IncreaseKira(); 
        this.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject tmp;
        tmp = GameObject.Find("LibraryManager");
        lm=tmp.GetComponent<Library>();
        if (!lm)
        {
            Debug.Log("Door.cs: LibraryManager‚ªŒ©‚Â‚©‚è‚Ü‚¹‚ñ");
        }

        flowchart=kaiwa.GetComponent<Flowchart>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
