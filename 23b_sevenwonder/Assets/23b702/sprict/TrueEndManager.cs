using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrueEndManager : MonoBehaviour
{

    [SerializeField] private GameObject kaiwa1;

    [SerializeField] private GameObject kaiwa2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void End(){
        kaiwa1.SetActive(false);
        kaiwa2.SetActive(true);
    }
}
