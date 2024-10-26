using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "ScriptableObject/EnhanceContent", fileName = "EnhanceContent")]
public class EnhanceContent : ScriptableObject
{
    [SerializeReference, SubclassSelector]  private List<IEnhanceInterface> _enhanceInterfaces;
    public List<IEnhanceInterface> EnhanceInterfaces => _enhanceInterfaces;
    // Start is called before the first frame update
    [SerializeField] private int _price;
    public int Price => _price;
    [SerializeField] private string _explainText;
    public string ExplainText => _explainText;
    [SerializeField] private Sprite _icon;
    public Sprite Icon => _icon;
}
