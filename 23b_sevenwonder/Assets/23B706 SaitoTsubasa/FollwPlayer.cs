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
    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.Find("GameManager") != null){
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        Debug.Log("Get GameManager");
        }else{Debug.Log("Not Found GameManager");}
        
        agent = GetComponent<NavMeshAgent2D>(); //agentにNavMeshAgent2Dを取得
        if(GameObject.Find("Player")){
        Player = GameObject.Find("Player");
        }else{Debug.Log("Not Found Player");}
        target = Player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(gm.GetKaiwaFlag() == false){
            agent.destination = target.position;
        }
    }
}
