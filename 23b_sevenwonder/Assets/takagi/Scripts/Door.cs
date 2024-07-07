using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{

    [SerializeField]
    GameObject SpawnPoint;

    [SerializeField]
    int DoorNum=1;

    [SerializeField]
    string SceneName;

    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        //GameManagerの取得
        GameObject tmp;
        tmp = GameObject.Find("GameManager");
        gm=tmp.GetComponent<GameManager>();
        if (!gm)
        {
            Debug.Log("Door.cs: GameManagerが見つかりません");
        }

        //シーン名でドア前からスタートするか決める
        //本番用に後で変更すること
        if (SceneManager.GetActiveScene().name == "takagitest")
        { 
            //校舎なのでスポーンポイントは設定しない
        }
        else
        {
            PlayerSpawn();
        }
        
    }

    // Update is called once per frame
    void Update()
    {

        }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            //Debug.Log("DoorにPlayerが触れた");

            if (Input.GetButtonDown("Fire1"))
            {
                //Fire1ボタンが押された
                Debug.Log("Doorに接触してFire1が押された:Scene遷移します。");
                gm.SetSpawnPointNum(DoorNum);
                gm.SetSpawnFlag(false);
                SceneChange();
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
        async.allowSceneActivation = false;    // シーン遷移をしない

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

        yield return new WaitForSeconds(0.5f);

        async.allowSceneActivation = true;    // シーン遷移許可

    }

}
