using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using DG.Tweening;
using Cysharp.Threading.Tasks;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PhaseUIManager : MonoBehaviour
{
    [SerializeField] private GameObject pointer;
    [SerializeField] private GameObject phaseUI;
    bool canSetpointer = true;
    private List<GameObject> phaseUIs = new List<GameObject>();
    // Start is called before the first frame update
    public async UniTask MakePhaseUI(int maxPhase){
        for(int i = 0; i < maxPhase; i++){
            GameObject phase = Instantiate(phaseUI, new Vector3(0, 0, 0), Quaternion.identity);
            phase.transform.SetParent(this.transform, false);
            phaseUIs.Add(phase);
        }
        await UniTask.Delay(1);
        MovePointer(0);
    }
    public void MovePointer(int phase){
        pointer.transform.DOMove(phaseUIs[phase].transform.position, 0.5f).SetEase(Ease.OutExpo);
        phaseUIs[phase].GetComponent<Animator>().SetTrigger("ToNowPoint");
        if(phase >= 1){
            phaseUIs[phase - 1].GetComponent<Animator>().SetTrigger("ToDonePoint");
        }
    }
    
    // Update is called once per frame
}
