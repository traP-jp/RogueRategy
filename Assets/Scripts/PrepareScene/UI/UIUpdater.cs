using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace PrepareSceneOnly
{
    public class UIUpdater : SingletonMonoBehaviour<UIUpdater>
    {
        [SerializeField] PlayerHPUpdater playerHPUpdater;
        [SerializeField] PlayersInfo playersInfo;

        

        private void Start()
        {
            //もしプレイヤーのHPが変化したならプレイヤーのHPTankをアップデートする
            playersInfo.ObserveEveryValueChanged(x => x.nowHP)
                       .Subscribe(x => playerHPUpdater.UpdateHPTank(Mathf.RoundToInt(x)));
        }
    }
}

