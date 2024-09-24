using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    private List<ItemData> Items = new List<ItemData>();

    //参照系
    [SerializeField] private GameObject PrefabItemPanel;
    [SerializeField] private GameObject MainPanel;

    //カーソル関連
    [SerializeField] GameObject Cursor;
    [SerializeField] float CursorMoveWidth;
    private int CursorX;
    private int CursorY;

    //入力関連
    private float InputVertical;
    private float InputHorizontal;
    private float BeforeVertical = 0.0f;
    private float BeforeHorizontal = 0.0f;

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
    
        Items[0].SetFlag(1);
        // Items[1].SetFlag(1);
        // Items[2].SetFlag(1);
        // Items[3].SetFlag(1);
        // Items[4].SetFlag(1);
        // Items[5].SetFlag(1);
        // Items[6].SetFlag(1);
        // Items[7].SetFlag(1);
        // Items[8].SetFlag(1);
        // Items[9].SetFlag(1);
        // Items[10].SetFlag(1);
        // Items[11].SetFlag(1);
        // Items[12].SetFlag(1);
        // Items[13].SetFlag(1);
        // Items[14].SetFlag(1);
        // Items[15].SetFlag(1);

    }

    void FixedUpdate(){
        InputVertical = Input.GetAxis("Vertical");
        InputHorizontal = Input.GetAxis("Horizontal");

        //Debug.Log(InputVertical.ToString());


        //上下左右系の入力処理
        //上[Verticalが0.5以上 ＆ 前のフレームが上じゃない]
        if( (InputVertical > 0.5f) && !(BeforeVertical > 0.5f) ){
            Debug.Log("Input Up");

            Vector2 CursorPosition = Cursor.GetComponent<RectTransform>().anchoredPosition;
            CursorPosition.y += 200.0f;
            Cursor.GetComponent<RectTransform>().anchoredPosition = CursorPosition;
            

        //下[Veticalが-0.5以下]
        }else if((InputVertical < -0.5f) && !(BeforeVertical < -0.5f)){
            Debug.Log("Input Down");

            Vector2 CursorPosition = Cursor.GetComponent<RectTransform>().anchoredPosition;
            CursorPosition.y -= 200.0f;
            Cursor.GetComponent<RectTransform>().anchoredPosition = CursorPosition;
        

        //右
        }else if((InputHorizontal > 0.5f) && !(BeforeHorizontal > 0.5f)){
            Debug.Log("Input Right");

            Vector2 CursorPosition = Cursor.GetComponent<RectTransform>().anchoredPosition;
            CursorPosition.x += 200.0f;
            Cursor.GetComponent<RectTransform>().anchoredPosition = CursorPosition;
        
        //左
        }else if((InputHorizontal < -0.5f) && !(BeforeHorizontal < -0.5f) ){
            Debug.Log("Input Left");

            Vector2 CursorPosition = Cursor.GetComponent<RectTransform>().anchoredPosition;
            CursorPosition.x -= 200.0f;
            Cursor.GetComponent<RectTransform>().anchoredPosition = CursorPosition;

        }
        BeforeVertical = InputVertical;
        BeforeHorizontal = InputHorizontal;
    }

    void Update(){
        //スペースキーの入力処理
        if(Input.GetKeyDown(KeyCode.Space)){
            Debug.Log("InputSpace");

            //foreach(){

            //オブジェクトを生成する
            GameObject CreatedItem = (GameObject)Instantiate(PrefabItemPanel,new Vector3(0.0f,0.0f,0.0f),Quaternion.identity);
            
            //画像を設定する
            Image ItemImage = CreatedItem.transform.Find("ItemImage").GetComponentInChildren<Image>();
            ItemImage.sprite = SpriteId9;


            //SetParent & localScale
            CreatedItem.transform.SetParent(MainPanel.transform);
            CreatedItem.GetComponent<RectTransform>().localScale = new Vector3(1.0f,1.0f,1.0f);

            

            //}
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
