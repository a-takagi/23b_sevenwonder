using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private List<ItemData> Items = new List<ItemData>();

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
        Items.Add(new ItemData(1,"ひのき棒","旅の始まりのお供",SpriteId1));
        Items.Add(new ItemData(2,"鍵","どこかで開けられる気がする",SpriteId2));
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
