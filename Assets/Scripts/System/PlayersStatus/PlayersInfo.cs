using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using System;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PlayerStatus")]
public class PlayersInfo:ScriptableObject
{
    //問題点:ゲーム中に変更した値がプレイをやめた時に元に戻らない
    //色々やってみたけど失敗したので仮置きでこの状態にしておきます

    //バトルシーンと準備シーン両方で保持する必要があるものをここに入れる
    public List<CardInfo> playersDeck;//playerのカードの順番を保存

    public float nowHP;
    public float maxHP;
    public float attack;
    public float defense;
    public float speed;
    public float bulletSpeed;

    /*
    [SerializeField]CardInfo[] _playersDeck;
    [SerializeField] float _nowHP;
    [SerializeField] float _maxHP;
    [SerializeField] float _attack;
    [SerializeField] float _defense;
    [SerializeField] float _speed;
    [SerializeField] float _bulletSpeed;
    */
}
