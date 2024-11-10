using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    //�I�𒆂̃{�^�����͂މ摜
    public GameObject selectButtonImage;
    public GameObject HowToPlay;

    //�{�^����Y���W
    float[] buttonX = { -300f, 300f };
    int selectX = 0;

    //Horizontal�̃L�[����
    private float h;

    //�L�[���͂̔�������
    bool isKeyDown = false;
    float keytimer = 0;
    float keyInterval = 0.2f; //�b

    //���̃V�[����I��������A�L�[���͂��󂯕t���Ȃ�
    bool isSelected = false;

    //������
    bool isSousa = false;

    //SoundManager
    SoundManager sm;

    //���̃V�[����
    string nextscene;

    // Start is called before the first frame update
    void Start()
    {
        //SoundManager��T��
        sm = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        if (sm == null)
        {
            Debug.Log("SoundManager missing");
        }
        else
        {
            Debug.Log("SoundManager OK");
        }
        //BGM���Đ��J�n
        sm.StartBGM();

        //������
        //QuickLoad���Ȃ���
        PlayerPrefs.SetInt("QuickLoad", 0);
        selectX = 0; //�J�[�\���̏����ʒu
        HowToPlay.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //�L�[���͗p�̃^�C�}�[
        keytimer -= Time.deltaTime;
        //Debug.Log("keytimer:" + keytimer);

        if (keytimer < 0)
        {
            isKeyDown = false;
        }

        //�L�[���͂��󂯕t���Ă�����
        if (isKeyDown == false)
        {
            h = Input.GetAxis("Horizontal");      //���E���L�[�̒l(-1.0~1.0)

            if (h < -0.3f)
            {
                //���
                selectX--;
                if (selectX < 0)
                {
                    selectX = 0;
                }
                else
                {
                    //�I��g���ړ��ł���
                    //SE��炷
                    sm.SEPlay("�s");
                }
                Debug.LogWarning("selectX changed:" + selectX);
                isKeyDown = true;
                keytimer = keyInterval;
            }
            if (h > 0.3f)
            {
                //���L�[�E
                selectX++;
                if (selectX > 1)
                {
                    selectX = 1;
                }
                else
                {
                    //�I��g���ړ��ł���
                    //SE��炷
                    sm.SEPlay("�s");
                }
                Debug.LogWarning("selectX changed:" + selectX);
                isKeyDown = true;
                keytimer = keyInterval;


            }
            selectButtonImage.GetComponent<RectTransform>().anchoredPosition = new Vector3(buttonX[selectX], -400f, 0);

            //Fire1�L�[�Ŏ��̃V�[����
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
                    //�����������̑J��
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
            //�Q�[���X�^�[�g
            sm.SEPlay("����");

            HowToPlay.SetActive(true);

            //�I������
            isSousa = true;
        }

    }

    public void ResetStart()
    {
        Debug.LogWarning("ResetStart");
        if (isSelected == false)
        {
            //�Q�[���X�^�[�g
            sm.SEPlay("����");
            sm.FadeOutBgm();

            //�����̃V�[���ɔ�΂�
            nextscene = "roka-1";

            StartCoroutine("LoadScene");

            //�I������
            isSelected = true;
        }

    }

    public void QuickLoad()
    {
        Debug.LogWarning("QuickLoad");
        if (isSelected == false)
        {
            //�Q�[���X�^�[�g
            sm.SEPlay("����");
            sm.FadeOutBgm();

            //���̃V�[����I������
            nextscene = SelectNextScene();

            StartCoroutine("LoadScene");

            //QuickLoad�����
            PlayerPrefs.SetInt("QuickLoad", 1);
            PlayerPrefs.Save();

            //�I������
            isSelected = true;
        }

    }


    IEnumerator LoadScene()
    {

        int i = 0;

        Debug.Log("LoadScene");

        AsyncOperation async = SceneManager.LoadSceneAsync(nextscene);
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

        yield return new WaitForSeconds(1f);

        async.allowSceneActivation = true;    // �V�[���J�ڋ���

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
