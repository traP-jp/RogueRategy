using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayersInfo
{
    //バトルシーンと準備シーン両方で保持する必要があるものをここに入れる
    //一旦Staticクラスを使ったデータの共有を実装します。ただこの方法もデメリットが多いため、リファクタリングをした方がいいかも?
    public static List<CardInfo> playersDeck;//playerのカードの順番を保存

    public static float nowHP;
    public static float maxHP;
    public static float attack;
    public static float defense;
    public static float speed;
    public static float bulletSpeed;

}
