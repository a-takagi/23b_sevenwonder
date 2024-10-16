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
        // �ŏ��ɑS�ẴI�u�W�F�N�g���A�N�e�B�u�ɂ���
        tarohanaobj.SetActive(false);
        tarohanakaiwa1obj.SetActive(false);
        tarohanakaiwa2obj.SetActive(false);
        tarohanakaiwa3obj.SetActive(false);

        // GameManager�̎擾
        GameObject tmp; 
        tmp = GameObject.Find("GameManager");
        gm = tmp.GetComponent<GameManager>();
        if (!gm)
        {
            Debug.Log("Library.cs: GameManager��������܂���");
        }

        // 2��ڈȍ~�̏���
        if (gm.GetLibrarySecond() == true)
        {
            kiranum = 3;
            tarohanaobj.SetActive(true);
            kirakira1.SetActive(false);
            kirakira2.SetActive(false);
            kirakira3.SetActive(false);
            TaroHana3Show(); // 2��ڈȍ~�͕ʂ̉�b��\��
        }
        else
        {
            // ����̉�b����
            StartFirstConversation();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // �K�v�ɉ����čX�V�����������ɒǉ�
    }

    public void IncreaseKira()
    {
        kiranum++;
        if (kiranum >= 3)
        {
            tarohanaobj.SetActive(true);
        }
        gm.SetLibrarySecond(true);
    }

    // ����̉�b�t���[
    void StartFirstConversation()
    {
        tarohanakaiwa1obj.SetActive(true); // �ŏ��̉�b��\��
        StartCoroutine(WaitAndShowTaroHana2()); // ��b�I����Ɏ��̉�b��\��
    }

    // tarohanakaiwa1�̌��tarohanakaiwa2��\������R���[�`��
    IEnumerator WaitAndShowTaroHana2()
    {
        yield return new WaitForSeconds(5); // 5�b�ҋ@�i��b���I���܂ł̎��ԁj
        tarohanakaiwa1obj.SetActive(false); // �ŏ��̉�b���\����
        tarohanakaiwa2obj.SetActive(true);  // ���̉�b��\��
    }

    // 2��ڈȍ~�̉�b
    public void TaroHana3Show()
    {
        tarohanakaiwa3obj.SetActive(true); // 2��ڈȍ~�̉�b��\��
    }
}
