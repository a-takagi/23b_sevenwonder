using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    //public int ItemId0; // 取得するアイテムのID

    //private ItemManager itemManager;

    private void Start()
    {
        // シーン内のItemManagerを取得
        //itemManager = FindObjectOfType<ItemManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //f (other.CompareTag("Player"))
        {
            // アイテムを取得
            //itemManager.AddItem(ItemId0);
            //Debug.Log($"アイテムID: {ItemId0} を取得しました。");
            
            // アイテムをシーンから削除（または非アクティブ化）
            //gameObject.SetActive(false);
        }
    }
}