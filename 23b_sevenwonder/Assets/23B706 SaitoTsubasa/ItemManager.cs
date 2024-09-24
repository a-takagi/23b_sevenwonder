using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private List<ItemData> Items = new List<ItemData>();

    //カーソル関連
    [SerializeField] GameObject Cursor;
    [SerializeField] float CursorMoveWidth;
    private int CursorX;
    private int CursorY;

    //入力関連
    private float InputVertical;
    private float InputHorizontal;
    private float BeforeVertical;
    private float BeforeHorizontal;

    [SerializeField]
    private Sprite SpriteId1;
    [SerializeField]
    private Sprite SpriteId2;
    [SerializeField]
    private Sprite SpriteId3;
    [SerializeField]
    private Sprite SpriteId4;
    [SerializeField]
    private Sprite SpriteId5;
    [SerializeField]
    private Sprite SpriteId6;
    [SerializeField]
    private Sprite SpriteId7;
    [SerializeField]
    private Sprite SpriteId8;
    [SerializeField]
    private Sprite SpriteId9;
    [SerializeField]
    private Sprite SpriteId10;
    [SerializeField]
    private Sprite SpriteId11;
    [SerializeField]
    private Sprite SpriteId12;
    [SerializeField]
    private Sprite SpriteId13;
    [SerializeField]
    private Sprite SpriteId14;
    [SerializeField]
    private Sprite SpriteId15;

    //コンストラクタ
    public ItemManager(){
        //Items.Add(new ItemData(1,"ひのき棒","旅の始まりのお供",SpriteId1));
        //Items.Add(new ItemData(2,"鍵","どこかで開けられる気がする",SpriteId2));
    }

    void start(){
        Items.Add(new ItemData(1,"ひのき棒","旅の始まりのお供",SpriteId1));
        Items.Add(new ItemData(2,"鍵","どこかで開けられる気がする",SpriteId2));
        Items.Add(new ItemData(3, "xx03xx03xx", "xx0303xxxx0303xx", SpriteId3));
        Items.Add(new ItemData(4, "xx04xx04xx", "xx0404xxxx0404xx", SpriteId4));
        Items.Add(new ItemData(5, "xx05xx05xx", "xx0505xxxx0505xx", SpriteId5));
        Items.Add(new ItemData(6, "xx06xx06xx", "xx0606xxxx0606xx", SpriteId6));
        Items.Add(new ItemData(7, "xx07xx07xx", "xx0707xxxx0707xx", SpriteId7));
        Items.Add(new ItemData(8, "xx08xx08xx", "xx0808xxxx0808xx", SpriteId8));
        Items.Add(new ItemData(9, "xx09xx09xx", "xx0909xxxx0909xx", SpriteId9));
        Items.Add(new ItemData(10, "xx10xx10xx", "xx1010xxxx1010xx", SpriteId10));
        Items.Add(new ItemData(11, "xx11xx11xx", "xx1111xxxx1111xx", SpriteId11));
        Items.Add(new ItemData(12, "xx12xx12xx", "xx1212xxxx1212xx", SpriteId12));
        Items.Add(new ItemData(13, "xx13xx13xx", "xx1313xxxx1313xx", SpriteId13));
        Items.Add(new ItemData(14, "xx14xx14xx", "xx1414xxxx1414xx", SpriteId14));
        Items.Add(new ItemData(15, "xx15xx15xx", "xx1515xxxx1515xx", SpriteId15));
    

    }

    void FixedUpdate(){
        InputVertical = Input.GetAxis("Vertical");
        InputHorizontal = Input.GetAxis("Horizontal");

        //Debug.Log(InputVertical.ToString());


        //上下左右系の入力処理
        //上[Verticalが0.5以上 ＆ 前のフレームが上じゃない]
        if( (InputVertical > 0.5f) && !(BeforeVertical > 0.5f) ){
            Debug.Log("Input Up");

        //下[Veticalが-0.5以下]
        }else if((InputVertical < -0.5f) && !(BeforeVertical < -0.5f)){
            Debug.Log("Input Down");
        

        //右
        }else if((InputHorizontal > 0.5f) && !(BeforeHorizontal > 0.5f)){
            Debug.Log("Input Right");
        
        //左
        }else if((InputHorizontal < -0.5f) && !(BeforeHorizontal < -0.5f) ){
            Debug.Log("Input Left");

        }
        BeforeVertical = InputVertical;
        BeforeHorizontal = InputHorizontal;
    }

    void Update(){
        //スペースキーの入力処理
        if(Input.GetButtonDown("Fire1")){
            //オブジェクトを生成する
            
        }

    }

    

    //アイテムを手に入れた時
    public void addItem(int ItemId){
        if(ItemId < Items.Count){
            Items[ItemId].SetFlag(1);
        }
    }

    //アイテムを失った時
    public void deleteItem(int ItemId){
        if(ItemId < Items.Count){
            Items[ItemId].SetFlag(0);
        }
    }
    
    //アイテムのデータを返す
    public List<ItemData> getItems(){
        List<ItemData> HasItems = new List<ItemData>();
        for(int i = 0;i<Items.Count;i++){
            if(Items[i].GetFlag() == 1){
                HasItems.Add(Items[i]);
            }
        }
        return HasItems;
    }
    
}
