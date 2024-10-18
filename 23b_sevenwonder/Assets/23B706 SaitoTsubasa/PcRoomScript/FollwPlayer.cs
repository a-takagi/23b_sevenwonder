using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollwPlayer : MonoBehaviour
{
     NavMeshAgent2D agent; //NavMeshAgent2Dを使用するための変数
    [SerializeField] Transform target; //追跡するターゲット

    //参照系
    GameManager gm;
    GameObject Player;
    ItemManager Im;
    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.Find("GameManager") != null){
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        Debug.Log("FllowPlayers.cs : Get GameManager");
        }else{Debug.Log("FllowPlayers.cs : Not Found GameManager");}

        if(GameObject.Find("ItemManger") != null){
        Im = GameObject.Find("ItemManger").GetComponent<ItemManager>();
        Debug.Log("FllowPalyers.cs : Get ItemManger");
        }else{Debug.Log("FllowPlayers.cs : Not Found ItemManger");}
        
        agent = GetComponent<NavMeshAgent2D>(); //agentにNavMeshAgent2Dを取得
        if(GameObject.Find("Player")){
        Debug.Log("FllowPlayers.cs : Get Player");
        Player = GameObject.Find("Player");
        target = Player.transform;
        }else{Debug.Log("FllowPlayers.cs : Not Found Player");}
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gm.GetKaiwaFlag() == false){
        if(Im.GetItemCanvasPreviewed() == false){
            agent.destination = target.position;
        }
        }
    }
}
