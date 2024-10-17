using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Library : MonoBehaviour
{
    [SerializeField]
    GameObject kirakira1;

    [SerializeField]
    GameObject kirakira2;

    [SerializeField]
    GameObject kirakira3;

    [SerializeField]
    GameObject tarohanaobj;

    [SerializeField]
    GameObject tarohanakaiwa1obj;

    [SerializeField]
    GameObject tarohanakaiwa2obj;

    [SerializeField]
    GameObject tarohanakaiwa3obj;

    GameManager gm;

    int kiranum;

    // Start is called before the first frame update
    void Start()
    {
        
        tarohanaobj.SetActive(false);
        //GameManager�̎擾
        GameObject tmp;
        tmp = GameObject.Find("GameManager");
        gm=tmp.GetComponent<GameManager>();
        if (!gm)
        {
            Debug.Log("Library.cs: GameManager��������܂���");
        }
        tarohanakaiwa3obj.SetActive(false);

        //2��ڂ��ǂ����̏���
        if(gm.GetLibrarySecond()==true){
            kiranum=3;
            tarohanaobj.SetActive(true);
            kirakira1.SetActive(false);
            kirakira2.SetActive(false);
            kirakira3.SetActive(false);
            FirstTarohana();
            tarohanakaiwa2obj.SetActive(false);
            TaroHana3Show();
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    //��b���n�߂����p���\�b�h
    public void KaiwaNau(){
        gm.KaiwaNau();
    }

    //��b�I��������p���\�b�h
    public void KaiwaOwatade(){
        gm.KaiwaOwatade();
    }

    // ����̉�b�t���[
    void FirstTarohana()
    {
        StartCoroutine(TaroHana2Show()); // ��b�I����Ɏ��̉�b��\��
    }

    // tarohanakaiwa1�̌��tarohanakaiwa2��\��
    IEnumerator TaroHana2Show()
    {
        yield return new WaitForSeconds(1); // 1�b�ҋ@�i��b���I���܂ł̎��ԁj
        tarohanakaiwa1obj.SetActive(false); // �ŏ��̉�b���\����
        tarohanakaiwa2obj.SetActive(true);  // ���̉�b��\��
        tarohanakaiwa2obj.SetActive(false);  // ���̉�b��\��
    }

    public void IncreaseKira(){
        kiranum++;
        if(kiranum>=3){
        tarohanaobj.SetActive(true);
        }
        gm.SetLibrarySecond(true);
    }
   
    public void TaroHana3Show(){
        //2��ڂ̉�b��\��������
       this.tarohanakaiwa3obj.SetActive(true);
    }
}