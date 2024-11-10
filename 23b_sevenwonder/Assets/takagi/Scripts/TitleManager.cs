using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    //選択中のボタンを囲む画像
    public GameObject selectButtonImage;
    public GameObject HowToPlay;

    //ボタンのY座標
    float[] buttonX = { -300f, 300f };
    int selectX = 0;

    //Horizontalのキー入力
    private float h;

    //キー入力の反応時間
    bool isKeyDown = false;
    float keytimer = 0;
    float keyInterval = 0.2f; //秒

    //次のシーンを選択したら、キー入力を受け付けない
    bool isSelected = false;

    //操作画面
    bool isSousa = false;

    //SoundManager
    SoundManager sm;

    //次のシーン名
    string nextscene;

    // Start is called before the first frame update
    void Start()
    {
        //SoundManagerを探す
        sm = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        if (sm == null)
        {
            Debug.Log("SoundManager missing");
        }
        else
        {
            Debug.Log("SoundManager OK");
        }
        //BGMを再生開始
        sm.StartBGM();

        //初期化
        //QuickLoadしないよ
        PlayerPrefs.SetInt("QuickLoad", 0);
        selectX = 0; //カーソルの初期位置
        HowToPlay.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //キー入力用のタイマー
        keytimer -= Time.deltaTime;
        //Debug.Log("keytimer:" + keytimer);

        if (keytimer < 0)
        {
            isKeyDown = false;
        }

        //キー入力を受け付けていたら
        if (isKeyDown == false)
        {
            h = Input.GetAxis("Horizontal");      //左右矢印キーの値(-1.0~1.0)

            if (h < -0.3f)
            {
                //矢印左
                selectX--;
                if (selectX < 0)
                {
                    selectX = 0;
                }
                else
                {
                    //選択枠が移動できる
                    //SEを鳴らす
                    sm.SEPlay("ピ");
                }
                Debug.LogWarning("selectX changed:" + selectX);
                isKeyDown = true;
                keytimer = keyInterval;
            }
            if (h > 0.3f)
            {
                //矢印キー右
                selectX++;
                if (selectX > 1)
                {
                    selectX = 1;
                }
                else
                {
                    //選択枠が移動できる
                    //SEを鳴らす
                    sm.SEPlay("ピ");
                }
                Debug.LogWarning("selectX changed:" + selectX);
                isKeyDown = true;
                keytimer = keyInterval;


            }
            selectButtonImage.GetComponent<RectTransform>().anchoredPosition = new Vector3(buttonX[selectX], -400f, 0);

            //Fire1キーで次のシーンへ
            if (Input.GetButtonDown("Fire1"))
            {
                if (isSousa == false)
                {
                    switch (selectX)
                    {
                        case 0:
                            Sousa();
                            isKeyDown = true;
                            keytimer = keyInterval;
                            break;
                        case 1:
                            QuickLoad();
                            break;
                    }
                }
                else
                {
                    //操作説明からの遷移
                    ResetStart();
                }

            }
        }

    }

    public void Sousa()
    {
        Debug.LogWarning("Sousa");
        if (isSousa == false)
        {
            //ゲームスタート
            sm.SEPlay("入手");

            HowToPlay.SetActive(true);

            //選択した
            isSousa = true;
        }

    }

    public void ResetStart()
    {
        Debug.LogWarning("ResetStart");
        if (isSelected == false)
        {
            //ゲームスタート
            sm.SEPlay("入手");
            sm.FadeOutBgm();

            //初期のシーンに飛ばす
            nextscene = "roka-1";

            StartCoroutine("LoadScene");

            //選択した
            isSelected = true;
        }

    }

    public void QuickLoad()
    {
        Debug.LogWarning("QuickLoad");
        if (isSelected == false)
        {
            //ゲームスタート
            sm.SEPlay("入手");
            sm.FadeOutBgm();

            //次のシーンを選択する
            nextscene = SelectNextScene();

            StartCoroutine("LoadScene");

            //QuickLoadするよ
            PlayerPrefs.SetInt("QuickLoad", 1);
            PlayerPrefs.Save();

            //選択した
            isSelected = true;
        }

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

    string SelectNextScene()
    {
        string scenename = "";
        int num;

        num=PlayerPrefs.GetInt("NowSpawnNum");
        
        if(num == 4)
        {
            scenename = "e-healthroom-1";
        }else if (num == 6 || num==24)
        {
            scenename = "e-stafferoom-1";
        }else if (num == 12)
        {
            scenename = "e-library-2";
        }else if (num == 20)
        {
            scenename = "e-pcroom-3";
        }else if (num == 22)
        {
            scenename = "e-kahanshin";
        }else if (num == 14)
        {
            scenename = "w-room-2";
        }else if (num == 16)
        {
            scenename = "w-room4-4-2";
        }else if(num>=7 && num<16)
        {
            scenename = "roka-2";
        }else if((num>=17 && num < 23) || (num>=25 && num<=26)) 
        {
            scenename = "roka-3";
        }
        else
        {
            scenename = "roka-1";
        }

        return scenename;
    }
}
