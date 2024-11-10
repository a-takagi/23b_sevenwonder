using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PcRoomDoor : MonoBehaviour
{

    [SerializeField]
    GameObject SpawnPoint;

    [SerializeField]
    int DoorNum=1;

    [SerializeField]
    string SceneName;


    bool isSceneChange = false;

    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        //GameManager�̎擾
        GameObject tmp;
        tmp = GameObject.Find("GameManager");
        gm=tmp.GetComponent<GameManager>();
        if (!gm)
        {
            Debug.Log("Door.cs: GameManagerがありません");
        }

        //�V�[�����Ńh�A�O����X�^�[�g���邩���߂�
        //�{�ԗp�Ɍ�ŕύX���邱��
        if (SceneManager.GetActiveScene().name == "roka-1")
        { 
            //�Z�ɂȂ̂ŃX�|�[���|�C���g�͐ݒ肵�Ȃ�
        }
        else
        {
            //PlayerSpawn();
        }
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(gm.GetisPcKey() == true){
        if (isSceneChange == false)
        {

            if (collision.name == "Player")
            {
                //Debug.Log("Door��Player���G�ꂽ");
                Debug.Log("Door�ɐڐG�����̂�:Scene�J�ڂ��܂��B");
                gm.SetNowSpawnNum(DoorNum);
                isSceneChange = true;

                SceneChange();
            }
        }
        }
    }

    private void PlayerSpawn()
    {
        GameObject tmp=GameObject.Find("Player");
        tmp.transform.SetPositionAndRotation(SpawnPoint.transform.position, Quaternion.identity);
    }

    // Use this for initialization
    private void SceneChange()
    {
            StartCoroutine("LoadScene");
    }

    IEnumerator LoadScene()
    {

        int i = 0;

        Debug.Log("LoadScene");

        AsyncOperation async = SceneManager.LoadSceneAsync(SceneName);
        async.allowSceneActivation = false;    // �V�[���J�ڂ����Ȃ�

        while (async.progress < 0.9f)
        {
            Debug.Log(async.progress);
            //loadingText.text = "Now Loading... "+(async.progress * 100).ToString("F0") + "%";
            //loadingText.text = "Now Loading";
            i++;
            if (i > 10) i = 0;
            for (int j = 0; j < i; j++)
            {
                //loadingText.text += ".";
            }
            //loadingBar.fillAmount = async.progress;
            yield return new WaitForEndOfFrame();
        }

        Debug.Log("Scene Loaded");

        //loadingText.text = "Now Loading... "+"100%";
        //loadingBar.fillAmount = 1;

        yield return new WaitForSeconds(0.02f);

        async.allowSceneActivation = true;    // �V�[���J�ڋ���
        gm.setPlayerSpawnFlag(false);
    }

}
