using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemManager : MonoBehaviour
{
    private List<ItemData> Items = new List<ItemData>();

    //参照系
    [SerializeField] private GameObject PrefabItemPanel;
    [SerializeField] private GameObject MainPanel;
    [SerializeField] private GameObject ItemMenuCanvas;
    [SerializeField] private GameObject ItemInfoText;

    //カーソル関連
    [SerializeField] GameObject Cursor;
    [SerializeField] float CursorMoveWidth;
    [SerializeField] int MaxCursorX;
    [SerializeField] int MaxCursorY;
    private int CursorX = 0;
    private int CursorY = 0;

    //入力関連
    private bool PreviewedCanvas = false;
    private float InputVertical;
    private float InputHorizontal;
    private float BeforeVertical = 0.0f;
    private float BeforeHorizontal = 0.0f;

    //アイテムの情報
    private List<ItemData> PreviewItems = new List<ItemData>();

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

    void Start(){
        Items.Add(new ItemData(1,"ひのき棒","旅の始まりのお供[0]",SpriteId1));
        Items.Add(new ItemData(2,"鍵","どこかで開けられる気がする[1]",SpriteId2));
        Items.Add(new ItemData(3, "xx03xx03xx", "xx0303xxxx0303xx[2]", SpriteId3));
        Items.Add(new ItemData(4, "xx04xx04xx", "xx0404xxxx0404xx[壁]", SpriteId4));
        Items.Add(new ItemData(5, "xx05xx05xx", "xx0505xxxx0505xx[3]", SpriteId5));
        Items.Add(new ItemData(6, "xx06xx06xx", "xx0606xxxx0606xx[4]", SpriteId6));
        Items.Add(new ItemData(7, "xx07xx07xx", "xx0707xxxx0707xx[5]", SpriteId7));
        Items.Add(new ItemData(8, "xx08xx08xx", "xx0808xxxx0808xx[×]", SpriteId8));
        Items.Add(new ItemData(9, "xx09xx09xx", "xx0909xxxx0909xx[6]", SpriteId9));
        Items.Add(new ItemData(10, "xx10xx10xx", "xx1010xxxx1010xx[7]", SpriteId10));
        Items.Add(new ItemData(11, "xx11xx11xx", "xx1111xxxx1111xx[8]", SpriteId11));
        Items.Add(new ItemData(12, "xx12xx12xx", "xx1212xxxx1212xx[●]", SpriteId12));
        Items.Add(new ItemData(13, "xx13xx13xx", "xx1313xxxx1313xx[9]", SpriteId13));
        Items.Add(new ItemData(14, "xx14xx14xx", "xx1414xxxx1414xx[A]", SpriteId14));
        Items.Add(new ItemData(15, "xx15xx15xx", "xx1515xxxx1515xx[B]", SpriteId15));
    
        Items[0].SetFlag(1);
        Items[1].SetFlag(1);
        Items[2].SetFlag(1);
        Items[3].SetFlag(1);
        Items[4].SetFlag(1);
        Items[5].SetFlag(1);
        Items[6].SetFlag(1);
        Items[7].SetFlag(1);
        Items[8].SetFlag(1);
        Items[9].SetFlag(1);
        Items[10].SetFlag(1);
        Items[11].SetFlag(1);
        Items[12].SetFlag(1);
        Items[13].SetFlag(1);
        Items[14].SetFlag(1);
    }

    void FixedUpdate(){
    if(PreviewedCanvas == true){

        InputVertical = Input.GetAxis("Vertical");
        InputHorizontal = Input.GetAxis("Horizontal");

        //Debug.Log(InputVertical.ToString());


        //上下左右系の入力処理
        //上[Verticalが0.5以上 ＆ 前のフレームが上じゃない]
        if( (InputVertical > 0.5f) && !(BeforeVertical > 0.5f) ){
            Debug.Log("Input Up");

            if(CursorY > 0){
            Vector2 CursorPosition = Cursor.GetComponent<RectTransform>().anchoredPosition;
            CursorPosition.y += 200.0f;
            Cursor.GetComponent<RectTransform>().anchoredPosition = CursorPosition;
            CursorY -= 1;
            PreviewItemInfo();
            }
            

        //下[Veticalが-0.5以下]
        }else if((InputVertical < -0.5f) && !(BeforeVertical < -0.5f)){
            Debug.Log("Input Down");

            if(CursorY < MaxCursorY){
            Vector2 CursorPosition = Cursor.GetComponent<RectTransform>().anchoredPosition;
            CursorPosition.y -= 200.0f;
            Cursor.GetComponent<RectTransform>().anchoredPosition = CursorPosition;
            CursorY += 1;
            PreviewItemInfo();
            }

        //右
        }else if((InputHorizontal > 0.5f) && !(BeforeHorizontal > 0.5f)){
            Debug.Log("Input Right");

            if(CursorX < MaxCursorX){
            Vector2 CursorPosition = Cursor.GetComponent<RectTransform>().anchoredPosition;
            CursorPosition.x += 200.0f;
            Cursor.GetComponent<RectTransform>().anchoredPosition = CursorPosition;
            CursorX += 1; 
            PreviewItemInfo();
            }

        //左
        }else if((InputHorizontal < -0.5f) && !(BeforeHorizontal < -0.5f) ){
            Debug.Log("Input Left");

            if(MaxCursorX > 0){
            Vector2 CursorPosition = Cursor.GetComponent<RectTransform>().anchoredPosition;
            CursorPosition.x -= 200.0f;
            Cursor.GetComponent<RectTransform>().anchoredPosition = CursorPosition;
            CursorX -= 1;
            PreviewItemInfo();
            }

        }
        BeforeVertical = InputVertical;
        BeforeHorizontal = InputHorizontal;
    }
    }

    void Update(){
        //スペースキーの入力処理
        if(Input.GetKeyDown(KeyCode.Space)){
            Debug.Log("InputSpace");

            if(PreviewedCanvas == false){
            ItemMenuCanvas.SetActive(true);

            
            foreach(ItemData Item in Items){
            if(Item.GetFlag() == 1){

                //オブジェクトを生成する
                GameObject CreatedItem = (GameObject)Instantiate(PrefabItemPanel,new Vector3(0.0f,0.0f,0.0f),Quaternion.identity);
                
                //画像を設定する
                Image ItemImage = CreatedItem.transform.Find("ItemImage").GetComponentInChildren<Image>();
                ItemImage.sprite = Item.GetSprite();

                //SetParent & localScale
                CreatedItem.transform.SetParent(MainPanel.transform);
                CreatedItem.GetComponent<RectTransform>().localScale = new Vector3(1.0f,1.0f,1.0f);
                
                //生成したものをデータに
                PreviewItems.Add(Item);

                Debug.Log("CreatedItemPanel");
            }
            }
            
            PreviewedCanvas = true;
            PreviewItemInfo();

            }else{
                PreviewItems.Clear();//PreviewItemsを空に
                foreach(Transform ChildPanel in MainPanel.transform){
                GameObject.Destroy(ChildPanel.gameObject);    
                }//MainPanelを空に
                PreviewedCanvas = false;
                ItemMenuCanvas.SetActive(false);
            }
        }

    }

    void PreviewItemInfo(){
        //カーソルの位置からアイテムを求める
        //計算式：(CursorY * (MaxCursorX + 1)) + CursorX
        int ItemPanelNum = (CursorY * (MaxCursorX + 1)) + CursorX;

        TextMeshProUGUI InfoText = ItemInfoText.GetComponent<TextMeshProUGUI>();

        //アイテムがあるか確認する
        //参照するセル数の部分が登録されているデータの数を超えていたら処理をしない
        if(ItemPanelNum < PreviewItems.Count){
            Debug.Log("Preview ItemInfo");

            //アイテムの名前を表示させる
            InfoText.text = PreviewItems[ItemPanelNum].GetName() + "\n";
            
            //アイテム情報を表示する
            InfoText.text += PreviewItems[ItemPanelNum].GetInfo();
            
        
        }else{
            //アイテム情報を空にする
            InfoText.text = "";
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
