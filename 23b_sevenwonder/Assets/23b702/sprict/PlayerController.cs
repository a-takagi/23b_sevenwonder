using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 100.0f;

    Animator animater;

    int nowAnim = 0;
    float vx = 0;
    float vy = 0;

    GameManager gm;

    ItemManager Im;

    [SerializeField] GameObject right;


   
    
    // Start is called before the first frame update
    void Start()
    {
        animater = right.GetComponent<Animator>();

        GameObject tmp;
        tmp = GameObject.Find("GameManager");
        gm = tmp.GetComponent<GameManager>();

        GameObject tmp1;
        tmp1 = GameObject.Find("ItemManger");
        Im = tmp1.GetComponent<ItemManager>();
        if (!gm)
        {
            Debug.Log("Player.cs: GameManagerが見つかりません");
        }

        if(!Im)
        {
            Debug.Log("Player.cs: ItemManagerが見つかりません");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // 毎フレーム数値を初期化
        vx = 0;
        vy = 0;
        if (gm.GetKaiwaFlag() == false)
        {
        if (Im.GetItemCanvasPreviewed() == false)
        {

            float dx = Input.GetAxis("Horizontal");
            float dy = Input.GetAxis("Vertical");
            transform.Translate(speed * dx, speed * dy, 0.0F);

            if (dx > 0.0f)
            {
                animater.SetBool("right", true);
            }
            else
            {
                animater.SetBool("right", false);
            }

            if (dx < 0.0f)
            {
                animater.SetBool("left", true);
            }
            else
            {
                animater.SetBool("left", false);
            }

            if (dy > 0.0f)
            {
                animater.SetBool("back", true);
            }
            else
            {
                animater.SetBool("back", false);
            }

            if (dy < 0.0f)
            {
                animater.SetBool("front", true);
            }
            else
            {
                animater.SetBool("front", false);
            }
        }
        }

        if (Input.GetButtonDown("Fire1")){
            
        }

        if(Input.GetButtonDown("Fire2")){
           
        }

        if(Input.GetButtonDown("Jump")){
           
        }


    }


    private void WalkSwitch(string str)
    {

        switch (str)
        {
            case "LeftWalk":
                nowAnim = 2;
                break;
            case "RightWalk":
                nowAnim = 4;
                break;
            case "UpWalk":
                nowAnim = 3;
                break;
            case "DownWalk":
                nowAnim = 1;
                break;
            case "Stand":
                nowAnim = 0;
                break;
            default:
                nowAnim = 0;
                break;
        }
        animater.SetInteger("nowWalk", nowAnim);
    }

    
    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.name == "Enemy" || col.gameObject.name == "Enemy(Clone)"){
            Debug.Log("hit Enemy");
            //シーンを変える処理
            SceneManager.LoadScene("GameOver");

        }
        Debug.Log(col.gameObject.name);
    }
}
