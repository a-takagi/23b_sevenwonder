using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : SingletonMonoBehaviour<SoundManager>
{

    //BGMのファイル名　拡張子無し
    //Assets/Resources/Sound/BGMの中に入れること
    string[] BGMFileName = new string[]
    {
        "186_BPM80", //全体のBGM
        "迫りくる危機", //追いかけられてるとき
    };

    //SEのファイル名　拡張子無し
    //Assets/Resources/Sound/SEの中に入れること
    string[] SEFileName = new string[]
    {
        "アナログパスワード入力_2", //ピ
        "Horror_START_2", //スタート音
        "怪談オープニング風SE", //赤ちゃんの泣き声に
        "不気味なピアノの音", //入手
        //"携帯電話のバイブレーション1", //携帯
        //"部屋のドアを開く・閉める" //ガチャ
    };

    bool isFadeOut=false;
    private float FadeOutSeconds = 1.0f;
    float FadeDeltaTime = 0f;

    private AudioSource audiosource;

    //SE専用のAudioSource　FadeOutしないために
    public GameObject SE;
    private AudioSource seaudiosource;

    public void Awake()
    {
        if (this != Instance)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        seaudiosource = SE.GetComponent<AudioSource>();


    }

    void Update()
    {
        //Debug.Log("volume:" + audiosource.volume);
        //Debug.Log("isFadeOut" + isFadeOut);

        if (isFadeOut)
        {
            FadeDeltaTime += Time.deltaTime;
            if(FadeDeltaTime >= FadeOutSeconds)
            {
                FadeDeltaTime = FadeOutSeconds;
                isFadeOut = false;
                BGMStop();
            }
            audiosource.volume = (float)(1.0f - FadeDeltaTime / FadeOutSeconds);
        }
        else
        {
            audiosource.volume = 1.0f;
        }
    }

    public void StartBGM()
    {
        //シーン名に応じて再生する
        switch (SceneManager.GetActiveScene().name)
        {
            case "Title":
                //SelectBGM("Title");
                break;
            case "TGS":
                //SelectBGM("Title");
                break;
            case "GameOver":
                //SelectBGM("GameOver");
                break;
            default:
                break;
        }

    }

    public void BGMPlay()
    {
        audiosource.Play();
    }

    public void BGMStop()
    {
        audiosource.Stop();
    }

    public void FadeOutBgm()
    {
        Debug.Log("FadeOutBgm is called");
        FadeDeltaTime = 0f;
        isFadeOut = true;
    }

    /**
    * SelectBGM
    * 引数　string name ; BGM名
    */
    public void SelectBGM(string name)
    {
        int i;
        Debug.Log("BGMPlay:" + name + " length:" + BGMFileName.Length);
        if (audiosource == null)
        {
            audiosource = GetComponent<AudioSource>();
        }
        switch (name)
        {
            case "通常":
                i = 0; //通常
                break;
            case "追っかけ":
                i = 1; //追いかけられる時
                break;
            default:
                i = 0;
                break;
        }
        if (i >= BGMFileName.Length)
        {
            i = BGMFileName.Length - 1;
        }
        AudioClip tmp;
        tmp = Resources.Load("Sound/BGM/" + BGMFileName[i]) as AudioClip;
        if (!tmp)
        {
            Debug.Log("Sound/BGM/" + BGMFileName[i] + " is Missing");
        }
        else
        {
            audiosource.clip = tmp;
        }
        BGMPlay();
    }

    /**
    * SEPlay
    * 引数　string name ; SE名
    */
    public void SEPlay(string name)
    {
        int i=0;
        Debug.Log("SEPlay:" + name + " length:" + SEFileName.Length);
        if (seaudiosource == null)
        {
            seaudiosource = SE.GetComponent<AudioSource>();
        }
        switch (name)
        {
            case "ピ":
                i = 0; //ピ
                break;
            case "スタート":
                i = 1; //スタート
                break;
            case "赤ちゃん":
                i = 2; //赤ちゃん
                break;
            case "入手":
                i = 3; //入手不気味なピアノ
                break;
            case "ガチャ":
                //i = 4;//ガチャ
                break;
            default:
                i = 0;
                break;
        }
        if (i >= SEFileName.Length)
        {
            i = SEFileName.Length - 1;
        }
        Debug.Log("aa");
        AudioClip tmp;
        tmp = Resources.Load("Sound/SE/" + SEFileName[i]) as AudioClip;
        if (!tmp)
        {
            Debug.Log(name + " is Missing");
        }
        seaudiosource.PlayOneShot(tmp);
    }



}
