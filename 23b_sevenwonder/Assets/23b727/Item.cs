using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    //public int ItemId0; // �擾����A�C�e����ID

    //private ItemManager itemManager;

    private void Start()
    {
        // �V�[������ItemManager���擾
        //itemManager = FindObjectOfType<ItemManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //f (other.CompareTag("Player"))
        {
            // �A�C�e�����擾
            //itemManager.AddItem(ItemId0);
            //Debug.Log($"�A�C�e��ID: {ItemId0} ���擾���܂����B");
            
            // �A�C�e�����V�[������폜�i�܂��͔�A�N�e�B�u���j
            //gameObject.SetActive(false);
        }
    }
}