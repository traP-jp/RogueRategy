using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Image))]
public class SpriteAnimation : MonoBehaviour
{
    
    [SerializeField] Sprite animationSprite;
    [SerializeField] Vector2Int spriteSplitCount;
    [SerializeField] bool initializeOnStart = false;
    [SerializeField] bool isLoop = false;
    [Header("nからn+1枚目のanimにかける時間")][SerializeField] float[] animationIntervalTime;
    [SerializeField] float constantInterval = 0;
    [SerializeField] float magnification = 1;

    Sprite[] animationSprites;
    Image animationImage;
    private void Awake()
    {
        animationImage = GetComponent<Image>();
    }
    private void Start()
    {
        animationSprites = getSpritesFromLargeSprite(animationSprite, spriteSplitCount.x, spriteSplitCount.y);
        if (initializeOnStart)
        {
            Initialize();
        }
    }
    public void Initialize()
    {
        StartCoroutine(doAnimation());
    }
    IEnumerator doAnimation()
    {
        do
        {
            for (int i = 0; i < animationSprites.Length; i++)
            {
                animationImage.sprite = animationSprites[i];
                yield return new WaitForSeconds(animationIntervalTime[i] + constantInterval);
            }
        } while (isLoop);

    }

    Sprite[] getSpritesFromLargeSprite(Sprite sprite,int XCount,int YCount)
    {
        int oneSpriteSizeX =(int)( sprite.rect.width / XCount);
        int oneSpriteSizeY = (int)(sprite.rect.height / YCount);
        Sprite[] sprites = new Sprite[XCount * YCount];
        int spriteNumber = 0;
        for (int y = YCount - 1; y >= 0; y--)
        {
            for (int x = 0; x < XCount; x++)
            {
                Rect rect = new Rect(oneSpriteSizeX * x, oneSpriteSizeY * y, oneSpriteSizeX, oneSpriteSizeY);
                sprites[spriteNumber] = Sprite.Create(sprite.texture, rect, new Vector2(0.5f, 0.5f), sprite.pixelsPerUnit, 0, SpriteMeshType.FullRect);
                spriteNumber++;
            }
        }
        GetComponent<RectTransform>().sizeDelta = new Vector2(oneSpriteSizeX * magnification, oneSpriteSizeY * magnification);
        return sprites;
    }
}
