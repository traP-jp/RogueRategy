using System;
using UnityEngine;
using DG.Tweening;
using TMPro;

namespace Game.UI.Damage
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class DamageNumAnimation : MonoBehaviour
    {
        [SerializeField] float _moveDistance;
        [SerializeField] float _duration;
        void Start()
        {
            TextMeshProUGUI tmPro = GetComponent<TextMeshProUGUI>();
            Sequence animSeq = DOTween.Sequence();
            animSeq.Append(transform.DOLocalMoveY(_moveDistance, _duration).SetEase(Ease.OutCubic))
                .Join(tmPro.DOFade(0, _duration).SetEase(Ease.InCubic))
                .OnComplete(() => Destroy(gameObject));
            animSeq.Play();
        }
    }
}