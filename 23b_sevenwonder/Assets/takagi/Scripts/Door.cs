using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField]
    GameObject[] SpawnPoint;

    [SerializeField]
    int SpawnNum=0;

    [SerializeField]
    string SceneName;

    // Start is called before the first frame update
    void Start()
    {
        PlayerSpawn(SpawnNum);
        
    }

    // Update is called once per frame
    void Update()
    {

        }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            //Debug.Log("Door‚ÉPlayer‚ªG‚ê‚½");

            if (Input.GetButtonDown("Fire1"))
            {
                //Fire1ƒ{ƒ^ƒ“‚ª‰Ÿ‚³‚ê‚½
                Debug.Log("Door‚ÉÚG‚µ‚ÄFire1‚ª‰Ÿ‚³‚ê‚½:Scene‘JˆÚ‚µ‚Ü‚·B");
                SceneChange();
            }
        }
    }

    private void PlayerSpawn(int n)
    {
        GameObject tmp=GameObject.Find("Player");
        tmp.transform.SetPositionAndRotation(SpawnPoint[n].transform.position, Quaternion.identity);
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
        async.allowSceneActivation = false;    // ƒV[ƒ“‘JˆÚ‚ğ‚µ‚È‚¢

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

        async.allowSceneActivation = true;    // ƒV[ƒ“‘JˆÚ‹–‰Â

    }

}
