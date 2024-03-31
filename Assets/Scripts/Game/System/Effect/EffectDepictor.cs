using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDepictor : SingletonMonoBehaviour<EffectDepictor>
{
    [SerializeField] Camera camera;
    [SerializeField] Transform parentTransform;
    [SerializeField] NameAndEffect[] effects;
    [System.Serializable]
    class NameAndEffect
    {
        public string name;
        public SpriteAnimation effect;
    }
    Dictionary<string, SpriteAnimation> nameToEffect = new Dictionary<string, SpriteAnimation>();
    private void Start()
    {
        foreach (var nameAndEffect in effects)
        {
            nameToEffect.Add(nameAndEffect.name, nameAndEffect.effect);
        }
    }

    public void DepictEffect(Vector2 position,string effectName)
    {
        Vector2 pos = position;
        if (nameToEffect[effectName].component == SpriteAnimation.WhichComponent.image) pos = camera.WorldToScreenPoint(position);
        SpriteAnimation spriteAnimation = Instantiate(nameToEffect[effectName], pos, Quaternion.identity, parentTransform);
        spriteAnimation.Initialize();
    }
}
