using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemManager : SingletonMonoBehaviour<ItemManager>
{
    private List<ItemData> Items = new List<ItemData>();

    

    //参照系
    [SerializeField] private GameObject GameManager;
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
    private GameManager gm;
    public bool KaiwaFlag = false;
    private bool PreviewedCanvas = false;
    private float InputVertical;
    private float InputHorizontal;
    private float BeforeVertical = 0.0f;
    private float BeforeHorizontal = 0.0f;

    //アイテムの情報
    private List<ItemData> PreviewItems = new List<ItemData>();

    [SerializeField]
    private Sprite KeySprite;
    [SerializeField]
    private Sprite OmamoriSprite;
    [SerializeField]
    private Sprite CoinSprite;
    [SerializeField]
    private Sprite KokkuriSheetSprite;
    [SerializeField]
    private Sprite SyukudaiSprite;

    //コンストラクタ
    public ItemManager(){
        //Items.Add(new ItemData(1,"ひのき棒","旅の始まりのお供",SpriteId1));
        //Items.Add(new ItemData(2,"鍵","どこかで開けられる気がする",SpriteId2));
    }

    void Awake()
    {
        if (this != Instance)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    //TMProのフォント作成方法
    //https://yurinchi2525.com/2023011howtoaddtextmeshpro/

    void Start(){
        Items.Add(new ItemData(1,"保健室の鍵","東棟1階にある保健室の鍵[0]",KeySprite));
        Items.Add(new ItemData(2,"お守り","いざという危機から身を守ってくれるかも[1]",OmamoriSprite));
        Items.Add(new ItemData(3, "10円玉", "こっくりさんを行うために必要なコイン(～～で行う)[2]", CoinSprite));
        Items.Add(new ItemData(4, "こっくりさんの紙", "こっくりさんを呼び出すのに必要な用紙", KokkuriSheetSprite));
        Items.Add(new ItemData(5, "宿題", "提出しないと先生に怒られちゃう！[3]", SyukudaiSprite));


        GameObject tmp;
        tmp = GameObject.Find("GameManager");
        gm = tmp.GetComponent<GameManager>();
        if (!gm)
        {
            Debug.Log("ItemManager.cs: GameManagerが見つかりません");
        }
    }

    void FixedUpdate(){
    if(PreviewedCanvas == true){

        InputVertical = Input.GetAxis("Vertical");
        InputHorizontal = Input.GetAxis("Horizontal");

        Debug.Log(InputVertical.ToString());
        Debug.Log(InputHorizontal.ToString());

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

            if(CursorX > 0){
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


        //会話フラグはGameManagerから取ってくる
        KaiwaFlag = gm.GetKaiwaFlag();

        //Debug.Log(KaiwaFlag.ToString());

        if (KaiwaFlag == false){
        //入力処理
        if(Input.GetButtonDown("Fire3")){
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
            
            //カーソルの初期化
            //CursorXとCursorYを初期化 ＆ カーソルのオブジェクト自体の位置も初期化 

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

    public void SetKaiwaFlag(bool flag){
        KaiwaFlag = flag;
        gm.SetKaiwaFlag(flag);
    }
    
    //鍵を手に入れた時
    public void GetKey(){
        Items[0].SetFlag(1);
    }
    //鍵を失った時
    public void LostKey(){
        Items[0].SetFlag(0);
    }

    //お守り用
    public void GetOmamori(){
        Items[1].SetFlag(1);
    }
    public void LostOmamori(){
        Items[1].SetFlag(0);
    }

    //10円玉用
    public void GetCoin(){
        Items[2].SetFlag(1);
    }
    public void LostCoin(){
        Items[2].SetFlag(0);
    }

    //こっくりさんの紙用
     public void GetKokkuriSheet(){
        Items[3].SetFlag(1);
    }
     public void LostKokkuriSheet(){
        Items[3].SetFlag(0);
    }

    //宿題用
     public void GetSyukudai(){
        Items[4].SetFlag(1);
    }
     public void LostSyukudai(){
        Items[4].SetFlag(0);
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

    public bool GetItemCanvasPreviewed(){
        return PreviewedCanvas;
    }
    
}
