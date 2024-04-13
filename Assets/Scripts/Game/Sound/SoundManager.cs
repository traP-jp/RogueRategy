using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;
using UniRx;
public class SoundManager :SingletonMonoBehaviour<SoundManager>
{
    [System.Serializable]
    public class SoundData
    {
        public string soundName;
        public AudioClip audioClip;
        public float volume;
    }
    [SerializeField] AudioSource BGMPlayer;
    [SerializeField] AudioSource SEPlayer;
    [SerializeField] AudioSource environmentPlayer;
    [SerializeField] SoundData[] BGMSoundDatas;
    [SerializeField] SoundData[] SESoundDatas;
    [SerializeField] SoundData[] environmentSoundDatas;
    [SerializeField] AudioMixer  audioMixer;
    [SerializeField][Header("音の最小デシベル")] float minimumDB;

    Dictionary<string, int> BGMNameToIndex = new Dictionary<string, int>();
    Dictionary<string, int> SENameToIndex = new Dictionary<string, int>();
    Dictionary<string, int> environmentNameToIndex = new Dictionary<string, int>();
    private void Awake()
    {
        for (int i = 0; i < BGMSoundDatas.Length; i++)
        {
            BGMNameToIndex.Add(BGMSoundDatas[i].soundName, i);
        }
        for (int i = 0; i < SESoundDatas.Length; i++)
        {
            SENameToIndex.Add(SESoundDatas[i].soundName, i);
        }
        for (int i = 0; i < environmentSoundDatas.Length; i++)
        {
            environmentNameToIndex.Add(environmentSoundDatas[i].soundName, i);
        }
    }
    private void Start()
    {
        StopBGM(10);
    }
    public void PlayBGM(string BGMName)
    {
        SoundData soundData = BGMSoundDatas[BGMNameToIndex[BGMName]];
        BGMPlayer.clip = soundData.audioClip;
        BGMPlayer.volume = soundData.volume;
        BGMPlayer.Play();
    }
    public void PlaySE(string SEName)
    {
        SoundData soundData = SESoundDatas[SENameToIndex[SEName]];
        SEPlayer.clip = soundData.audioClip;
        SEPlayer.volume = soundData.volume;
        SEPlayer.Play();
    }
    public void PlaySE(string SEName,Action onFinished)
    {
        SoundData soundData = SESoundDatas[SENameToIndex[SEName]];
        SEPlayer.clip = soundData.audioClip;
        SEPlayer.volume = soundData.volume;
        SEPlayer.Play();
        SEPlayer.ObserveEveryValueChanged(s => s.isPlaying).Take(2).Subscribe(_ => { },()=> onFinished.Invoke()) ;//SE終了のコールバック
    }
    public void PlayEnvironment(string environmentName)
    {
        SoundData soundData = environmentSoundDatas[environmentNameToIndex[environmentName]];
        environmentPlayer.clip = soundData.audioClip;
        environmentPlayer.volume = soundData.volume;
        environmentPlayer.Play();
    }

    public void StopBGM(float turnOffTime)
    {
        //turnOffTime秒かけて音を消す。
        StartCoroutine(StopBGMProcess(turnOffTime));
    }
    public void StopBGM()
    {
        BGMPlayer.Stop();
    }
    IEnumerator StopBGMProcess(float turnOffTime)
    {
        float nowTime = 0;
        float beginningDB = 20 * Mathf.Log10(BGMPlayer.volume);//ボリュームをデシベルに変換
        while (nowTime < turnOffTime)
        {
            float ratio = nowTime / turnOffTime;//BGMストップの進行度0-1
            BGMPlayer.volume = Mathf.Pow(10, Mathf.Lerp(beginningDB, minimumDB, ratio) / 20f);//デシベルの線形変化をボリュームに変換
            nowTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        BGMPlayer.Stop();
    }

    public void StopEnvironment(float turnOffTime)
    {
        StartCoroutine(StopEnvironmentProcess(turnOffTime));
    }
    public void StopEnvironment()
    {
        environmentPlayer.Stop();
    }
    IEnumerator StopEnvironmentProcess(float turnOffTime)
    {
        float nowTime = 0;
        float beginningDB = 20 * Mathf.Log10(environmentPlayer.volume);//ボリュームをデシベルに変換
        while (nowTime < turnOffTime)
        {
            float ratio = nowTime / turnOffTime;//Environmentストップの進行度0-1
            environmentPlayer.volume = Mathf.Pow(10, Mathf.Lerp(beginningDB, minimumDB, ratio) / 20f);//デシベルの線形変化をボリュームに変換
            nowTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        environmentPlayer.Stop();
    }


}
