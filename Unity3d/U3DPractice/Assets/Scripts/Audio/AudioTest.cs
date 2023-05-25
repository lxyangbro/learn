using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 测试脚本
/// </summary>
public class AudioTest : MonoBehaviour
{

    AudioClip BGM_1;
    AudioClip BGM_2;

    AudioClip Sound_1;
    AudioClip Sound_2;

    AudioClip BGS_1;
    AudioClip BGS_2;

    AudioClip MS_1;
    AudioClip MS_2;

    AudioClip Voice_1;
    AudioClip Voice_2;
    AudioClip Voice_3;


    void Awake()
    {
        BGM_1 = Resources.Load<AudioClip>("Audio/BGM/BGM_1");
        BGM_2 = Resources.Load<AudioClip>("Audio/BGM/BGM_2");

        Sound_1 = Resources.Load<AudioClip>("Audio/Sound/Sound_1");
        Sound_2 = Resources.Load<AudioClip>("Audio/Sound/Sound_2");

        BGS_1 = Resources.Load<AudioClip>("Audio/BGS/BGS_1");
        BGS_2 = Resources.Load<AudioClip>("Audio/BGS/BGS_2");

        MS_1 = Resources.Load<AudioClip>("Audio/MS/MS_1");
        MS_2 = Resources.Load<AudioClip>("Audio/MS/MS_2");

        Voice_1 = Resources.Load<AudioClip>("Audio/Voice/Voice_1");
        Voice_2 = Resources.Load<AudioClip>("Audio/Voice/Voice_2");
        Voice_3 = Resources.Load<AudioClip>("Audio/Voice/Voice_3");
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(0,0,150,80),"播放BGM_1"))
        {
            AudioManager.Instance.PlayBGM(BGM_1);
        }

        if (GUI.Button(new Rect(0, 100, 150, 80), "播放BGM_2"))
        {
            AudioManager.Instance.PlayBGM(BGM_2);
        }

        if (GUI.Button(new Rect(0, 200, 150, 80), "暂停BGM"))
        {
            AudioManager.Instance.PauseBGM();
        }

        if (GUI.Button(new Rect(0, 300, 150, 80), "取消暂停BGM"))
        {
            AudioManager.Instance.UnPauseBGM();
        }

        if (GUI.Button(new Rect(0, 400, 150, 80), "停止BGM"))
        {
            AudioManager.Instance.StopBGM();
        }






        if (GUI.Button(new Rect(200, 0, 150, 80), "播放Sound_1"))
        {
            AudioManager.Instance.PlaySound(Sound_1);
        }

        if (GUI.Button(new Rect(200, 100, 150, 80), "播放Sound_2"))
        {
            //AudioManager.Instance.PlaySound(Sound_2,GameObject.Find("Gold"));

            AudioManager.Instance.PlaySound(Sound_2,new Vector3(1,2,3));
        }








        if (GUI.Button(new Rect(400, 0, 150, 80), "播放BGS_1"))
        {
            AudioManager.Instance.PlayBGS(BGS_1);
        }

        if (GUI.Button(new Rect(400, 100, 150, 80), "播放BGS_2"))
        {
            AudioManager.Instance.PlayBGS(BGS_2);
        }

        if (GUI.Button(new Rect(400, 200, 150, 80), "暂停BGS"))
        {
            AudioManager.Instance.PauseBGS();
        }

        if (GUI.Button(new Rect(400, 300, 150, 80), "取消暂停BGS"))
        {
            AudioManager.Instance.UnPauseBGS();
        }

        if (GUI.Button(new Rect(400, 400, 150, 80), "停止BGS"))
        {
            AudioManager.Instance.StopBGS();
        }



        if (GUI.Button(new Rect(600, 0, 150, 80), "播放MS_1"))
        {
            AudioManager.Instance.PlayMS(MS_1);
        }

        if (GUI.Button(new Rect(600, 100, 150, 80), "播放MS_2"))
        {
            AudioManager.Instance.PlayMS(MS_2);
        }



        if (GUI.Button(new Rect(800, 0, 150, 80), "播放角色语音1"))
        {
            AudioManager.Instance.PlayVoice(Voice_1);
        }

        if (GUI.Button(new Rect(800, 100, 150, 80), "播放角色语音2"))
        {
            AudioManager.Instance.PlayVoice(Voice_2);
        }

        if (GUI.Button(new Rect(800, 200, 150, 80), "播放角色语音3"))
        {
            AudioManager.Instance.PlayVoice(Voice_3);
        }

        if (GUI.Button(new Rect(800, 300, 150, 80), "停止角色语音"))
        {
            AudioManager.Instance.StopVoice();
        }



    }










}
