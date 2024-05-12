using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace Feedback
{
    public interface IFeedback
    {
        void Play(Vector2 position, Action<int> onFinishCallback,int feedbackParallelID = 0);
        
        //IFeedback実装の際は実行終了時にonFinishCallback.Invoke(handoverID)と書いてあげれば良い
        //フィードバックを呼び出す時は hoge.Play(フィードバックを呼び出す座標,_ => {})で呼び出す(コールバックがいらない場合)
        //　　　　　　　　　　　　　　 hoge.Play(フィードバックを呼び出す座標,関数名)で呼び出す(コールバックが必要な場合)
        //またはFeedbackManager.Instance.PlayFeedback(FeedbackManagerに登録したフィードバックの名前,フィードバックを呼び出す座標)で呼び出せる

        //使い分けはinspectorを汚したくない場合はFeedbackManager.PlayFeedbackを使い、
        //inspectorで設定したい場合はhoge.Play()  (hogeはIFeedbackを実装した関数)を使う
    }
}

