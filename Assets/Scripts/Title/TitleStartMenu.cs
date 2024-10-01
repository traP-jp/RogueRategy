using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleStartMenu : MonoBehaviour,IMenuSelectInterface
{
    int _selectNum = 0;
    int _maxSelectNum = 2;
    [SerializeField] private GameObject _cursor;
    List<GameObject> _selectList = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i <= _maxSelectNum; i++)
        {
            //子オブジェクトを取得
            _selectList.Add(transform.GetChild(i).gameObject);
        }
        SetCorsorPosition();
    }

    public void OnDecide()
    {
        if (_selectNum == 0)
        {
            Debug.Log("START");
        }
        else if (_selectNum == 1)
        {
            Debug.Log("CONTINUE");
        }
        else if (_selectNum == 2)
        {
            Debug.Log("EXIT");
        }
    }
    void SetCorsorPosition()
    {
        //カーソルの位置を変更
        _cursor.transform.position = _selectList[_selectNum].transform.position;
    }
    public void OnDown()
    {
        if (_selectNum < _maxSelectNum)
        {
            _selectNum++;
        }
        else
        {
            _selectNum = 0;
        }
        SetCorsorPosition();
    }

    public void OnUp()
    {
        if (_selectNum > 0)
        {
            _selectNum--;
        }
        else
        {
            _selectNum = _maxSelectNum;
        }
        SetCorsorPosition();
    }
}
