using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayersInfo
{
    //バトルシーンと準備シーン両方で保持する必要があるものをここに入れる
    public static int playerHP { get; set; }
    public static List<Card> playersDeck;//playerのカードの順番を保存
    
}
