using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager Instance;
    public GameObject MainHand;
    public Transform HandPoint_1;
    public Transform HandPoint_2;

    public CanvasGroup Scene_1_Main;
    public Image Scene_1_Qr_Green;
    public GameObject Scene_1_LoadingScreen;
    public GameObject Scene_1_FindProductScreen;
    public TMP_InputField Scene_1_ProductFindScreenInputField;
    public GameObject Scene_1_LoadingProductFind;
    public GameObject Scene_1_ProductFindFinded;

    public CanvasGroup Scene_2_Main;
     public GameObject Scene_2_1;
      public GameObject Scene_2_2;
       public GameObject Scene_2_3;
        public GameObject Scene_2_4;
        public Transform Scene4Tick;

    void Awake()
    {
        Instance=this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Scene_1_Action()
    {
        yield return HandOpenMove();
        OpenCloseCanvasGroup(Scene_1_Main,true);
        yield return new WaitForSeconds(.5f);
        yield return new WaitForSeconds(1.5f);
        Scene_1_Qr_Green.gameObject.SetActive(true);
        DOTween.Sequence()
        .Append(Scene_1_Qr_Green.DOFade(.5f,.2f))
        .Append(Scene_1_Qr_Green.DOFade(0f,.2f))
        .Append(Scene_1_Qr_Green.DOFade(.3f,.2f));
        yield return new WaitForSeconds(.8f);
        Scene_1_Qr_Green.gameObject.SetActive(false);
        Scene_1_LoadingScreen.SetActive(true);
        yield return new WaitForSeconds(2f);
        Scene_1_LoadingScreen.SetActive(false);
        Scene_1_FindProductScreen.SetActive(true);
        string text="Bezelye";
        for(int i=0;i<text.Length;i++){
            Scene_1_ProductFindScreenInputField.text+=text[i].ToString();
            yield return new WaitForSeconds(.1f);
        }
        yield return new WaitForSeconds(1f);
        Scene_1_LoadingProductFind.SetActive(false);
        Scene_1_ProductFindFinded.SetActive(true);
        yield return new WaitForSeconds(3f);
        yield return HandCloseMove();
        OpenCloseCanvasGroup(Scene_1_Main,false);

    }

    public IEnumerator Scene_2_Action()
    {
        yield return HandOpenMove();
        OpenCloseCanvasGroup(Scene_2_Main,true);
        yield return new WaitForSeconds(1f);
        Scene_2_1.SetActive(false);
         Scene_2_2.SetActive(true);
         yield return new WaitForSeconds(2f);
         Scene_2_2.SetActive(false);
         Scene_2_3.SetActive(true);
         yield return new WaitForSeconds(1f);
         Scene_2_3.SetActive(false);
         Scene_2_4.SetActive(true);
         Scene4Tick.DOPunchScale(Vector3.one*1.25f,.4f);
         yield return new WaitForSeconds(1f);
         yield return HandCloseMove();

    }

    public IEnumerator HandOpenMove()
    {
        MainHand.transform.DOMove(HandPoint_2.position,.5f);
        yield return new WaitForSeconds(.5f);

    }
     public IEnumerator HandCloseMove()
    {
        MainHand.transform.DOMove(HandPoint_1.position,.5f);
        yield return new WaitForSeconds(.5f);

    }

    public void OpenCloseCanvasGroup(CanvasGroup canvasGroup,bool status)
    {
       if(status)
       {
           canvasGroup.DOFade(1,.5f);
       }
       else
       {
            canvasGroup.DOFade(0,.5f);
       }
    }
}
