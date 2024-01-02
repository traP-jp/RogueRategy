using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

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
    IEnumerator StopBGMProcess(float turnOffTime)
    {
        float nowTime = 0;
        float beginningVolume = BGMPlayer.volume;
        while (nowTime < turnOffTime)
        {
            BGMPlayer.volume = beginningVolume * (1 - nowTime / turnOffTime);
            nowTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        BGMPlayer.Stop();
    }
    public void StopEnvironment(float turnOffTime)
    {
        StartCoroutine(StopEnvironmentProcess(turnOffTime));
    }
    IEnumerator StopEnvironmentProcess(float turnOffTime)
    {
        float nowTime = 0;
        float beginningVolume = environmentPlayer.volume;
        while (nowTime < turnOffTime)
        {
            environmentPlayer.volume = beginningVolume * (1 - nowTime / turnOffTime);
            nowTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        environmentPlayer.Stop();
    }
}
