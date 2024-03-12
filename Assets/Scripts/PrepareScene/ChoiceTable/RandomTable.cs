using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace PrepareSceneOnly
{
    [System.Serializable]
    public class RandomTable<S>
    {
        [SerializeField] OneRarityTable<S>[] table;

        [System.Serializable]
        class OneRarityTable<T>
        {
            public string rarityName;
            public float probability;
            public T[] tableItems;
        }
        public S GetRandomData()
        {
            //設定した確率で選んだデータを返す
            //重み付き乱数
            float probabilitySum = 0;
            foreach (var oneTable in table)
            {
                probabilitySum += oneTable.probability;
            }

            float randomValue = Random.Range(0, probabilitySum);
            float nowSum = 0;
            int resultIndex = -1;
            for(int i = 0;i<table.Length; i++)
            {
                nowSum += table[i].probability;
                if (randomValue < nowSum)
                {
                    resultIndex = i;
                    break;
                }
            }
            if (resultIndex == -1) resultIndex = table.Length - 1;
            var resultItemList = table[resultIndex].tableItems;
            return resultItemList[Random.Range(0, resultItemList.Length)];
        }
    }
}

