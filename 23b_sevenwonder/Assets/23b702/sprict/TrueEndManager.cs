using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrueEndManager : MonoBehaviour
{
    [SerializeField] private bool EndingEnded;
    [SerializeField] private GameObject Kaiwa1;
    //参照系
    private GameManager gm;
    private GameObject GameManager;
    private ItemManager Im;
    private GameObject ItemManager;
    private PlayerController Pm;
    private GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.Find("GameManager") != null){
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        GameManager = GameObject.Find("GameManger");
        Debug.Log("Get GameManager");
        }else{Debug.Log("Not Found GameManager");}
        
        if(GameObject.Find("ItemManger") != null){
        Im = GameObject.Find("ItemManger").GetComponent<ItemManager>();
        ItemManager = GameObject.Find("ItemManger");
        Debug.Log("Get ItemManger");
        }else{Debug.Log("Not Found ItemManger");}

        if(GameObject.Find("Player")){
        Pm = GameObject.Find("Player").GetComponent<PlayerController>();
        Player = GameObject.Find("Player");
        }else{Debug.Log("Not Found Player");}
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
        if(Kaiwa1 == null){
            Destroy(Player);
            Destroy(ItemManager);
            Destroy(GameManager);
            SceneManager.LoadScene("Title");
        }
        }        
    }

    //会話を始めた時用メソッド
    public void KaiwaNau(){
        gm.KaiwaNau();
    }

    //会話終わった時用メソッド
    public void KaiwaOwatade(){
        gm.KaiwaOwatade();
    }
}
