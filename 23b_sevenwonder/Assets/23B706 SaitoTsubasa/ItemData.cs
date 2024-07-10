using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData 
{
    [SerializeField]
    private int ItemId;         //アイテムのID番号
    [SerializeField]
    private string ItemName;    //アイテムの名前
    [SerializeField]
    private int ItemFlag;       //アイテムの取得フラグ
    [SerializeField]
    private Sprite ItemSprite;  //アイテムの画像
    [SerializeField]
    private string ItemInfo;    //アイテムの詳細説明

    public ItemData(int id,string name,string Info,Sprite sprite){
        this.ItemId = id;
        this.ItemName = name;
        this.ItemInfo = Info;
        this.ItemSprite = sprite;
    }

    public int GetId(){
        return this.ItemId;
    }

    //アイテム名関連のメソッド
    public string GetName(){
        return ItemName;
    }
    public void SetName(string name){
        this.ItemName = name;
    }

    //フラグ関連のメソッド
    public int GetFlag(){
        return this.ItemFlag;
    }
    public void SetFlag(int flag){
        this.ItemFlag = flag;
    }

    //画像関連のもの
    public Sprite GetSprite(){
        return this.ItemSprite;
    }

    //アイテムの説明関連
    public string GetInfo(){
        return this.ItemInfo;
    }
    public void SetInfo(string info){
        this.ItemInfo = info;
    }
}
