using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBorder : MonoBehaviour
{   
    [SerializeField] private float yposition;
    
    [SerializeField] CardShower cardShower;
    // Start is called before the first frame update
    private bool isMoved = false;

    public void MoveCard()
    {
        if (isMoved)
        {
            transform.Translate(Vector3.down * yposition);
            cardShower.LayoutCards();
        }
        else
        {
            transform.Translate(Vector3.up * yposition);
        }

        isMoved = !isMoved;
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
