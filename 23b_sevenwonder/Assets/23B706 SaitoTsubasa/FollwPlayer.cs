using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollwPlayer : MonoBehaviour
{
     NavMeshAgent2D agent; //NavMeshAgent2Dを使用するための変数
    [SerializeField] Transform target; //追跡するターゲット
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent2D>(); //agentにNavMeshAgent2Dを取得
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = target.position;
    }
}
