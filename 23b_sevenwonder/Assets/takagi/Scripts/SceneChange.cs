using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    [SerializeField] string nextscene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ChangeScene();
        }
    }

    public void ChangeScene()
    {
        StartCoroutine("LoadScene");
    }

    IEnumerator LoadScene()
    {

        int i = 0;

        Debug.Log("LoadScene");

        AsyncOperation async = SceneManager.LoadSceneAsync(nextscene);
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

        yield return new WaitForSeconds(1f);

        async.allowSceneActivation = true;    // シーン遷移許可

    }
}
