using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PlayerStatus")]
public class PlayersInfo:ScriptableObject
{
    //バトルシーンと準備シーン両方で保持する必要があるものをここに入れる
    [NonSerialized]public List<CardInfo> playersDeck;//playerのカードの順番を保存
    [NonSerialized]public List<Item> playersItem;
    [NonSerialized]public float nowHP;
    [NonSerialized]public float maxHP;
    [NonSerialized]public float attack;
    [NonSerialized]public float defense;
    [NonSerialized]public float speed;
    [NonSerialized]public float bulletSpeed;


    [SerializeField] CardInfo[] _playersDeck;
    [SerializeField] Item[] _playersItem;
    [SerializeField] float _nowHP;
    [SerializeField] float _maxHP;
    [SerializeField] float _attack;
    [SerializeField] float _defense;
    [SerializeField] float _speed;
    [SerializeField] float _bulletSpeed;

    public int progressRate = 0;
    public int money = 0;

    private void OnEnable()
    {
        nowHP = _nowHP;
        maxHP = _maxHP;
        attack = _attack;
        defense = _defense;
        speed = _speed;
        bulletSpeed = _bulletSpeed;
        playersDeck = new List<CardInfo>(_playersDeck);
        playersItem = new List<Item>(_playersItem);
    }

}
