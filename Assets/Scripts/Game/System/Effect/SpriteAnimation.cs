using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpriteAnimation : MonoBehaviour
{
    
    [SerializeField] Sprite animationSprite;
    [SerializeField] Vector2Int spriteSplitCount;
    [SerializeField] bool initializeOnStart = false;
    [SerializeField] bool isLoop = false;
    //何番目からループするか
    [SerializeField] int loopPoint = 0;
    int usedLoopPoint = 0;
    public enum WhichComponent{
        image,
        spriteRenderer
    }
    public WhichComponent component;
    [Header("nからn+1枚目のanimにかける時間")][SerializeField] float[] animationIntervalTime;
    [SerializeField] float constantInterval = 0;
    [SerializeField] float magnification = 1;

    Sprite[] animationSprites;
    Image animationImage;
    SpriteRenderer spriteRenderer;
    private void Start()
    {
        if (initializeOnStart)
        {
            Initialize();
        }
    }
    public void Initialize()
    {
        if(component == WhichComponent.image)
        {
            animationImage = GetComponent<Image>();
        }
        else
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
        animationSprites = getSpritesFromLargeSprite(animationSprite, spriteSplitCount.x, spriteSplitCount.y);
        StartCoroutine(doAnimation(_ => { }));
    }
    public void Initialize(Action<int> onFinishCallback,int parallelFeedbackID = -1)
    {
        animationSprites = getSpritesFromLargeSprite(animationSprite, spriteSplitCount.x, spriteSplitCount.y);
        StartCoroutine(doAnimation(onFinishCallback,parallelFeedbackID));
    }
    IEnumerator doAnimation(Action<int> onFinishCallback,int parallelFeedbackID = -1)
    {   
        if(component == WhichComponent.image)
        {
            do
            {
                for (int i = usedLoopPoint; i < animationSprites.Length; i++)
                {
                    animationImage.sprite = animationSprites[i];
                    yield return new WaitForSeconds(animationIntervalTime[i] + constantInterval);
                }
                usedLoopPoint = loopPoint;
            } while (isLoop);
        }
        //SpriteRendererの処理
        else{
            do
        {
            for (int i = usedLoopPoint; i < animationSprites.Length; i++)
            {
                spriteRenderer.sprite = animationSprites[i];
                yield return new WaitForSeconds(animationIntervalTime[i] + constantInterval);
            }
            usedLoopPoint = loopPoint;
        } while (isLoop);
        }
        onFinishCallback.Invoke(parallelFeedbackID);
        Destroy(gameObject);
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
        if(component == WhichComponent.image)
        {
            GetComponent<RectTransform>().sizeDelta = new Vector2(oneSpriteSizeX * magnification, oneSpriteSizeY * magnification);
        }
        else
        {
            
        }
        return sprites;
    }
}
