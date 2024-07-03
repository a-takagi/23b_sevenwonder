using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemList : MonoBehaviour
{
    
    //アイテムのデータを管理する構造体
    public struct ItemData{
        public int ItemId;
        public string ItemName;
        public string ItemInfo;
        public int ItemFlag;
    }

    //アイテムの構造体を配列にして全てのアイテムを管理
    public ItemData[] ItemDataList = new ItemData[30];

    // Start is called before the first frame update
    void Start()
    {

        //アイテムの仮情報設定
        ItemDataList[0] = new ItemData(){ItemId = 1,ItemName = "ひのきの棒",ItemInfo="旅の始まりのお供",ItemFlag=1};
        ItemDataList[1] = new ItemData(){ItemId = 2,ItemName = "鍵",ItemInfo="どこかを開けられる気がする",ItemFlag=0};


        //一覧を出力する処理
        int i = 0;
        foreach(ItemData RealityItemData in ItemDataList){
            // instanceSlot.name = "ItemSlot" + i++;
            // instanceSlot.tranceform.localScale = new Vector3(1f,1f,1f);
            // instanceSlot.GetComponent<ProcessiongSlot>().SetItemData(item);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
