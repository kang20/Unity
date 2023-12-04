using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionBtn : MonoBehaviour
{
    public GameObject optionsPanel; // 인스펙터에서 할당할 옵션 패널
    public Button setOptionBtn; // 인스펙터에서 할당할 설정 버튼
    public Button setReturnBtn; // 인스펙터에서 할당할 설정 버튼
    public Button setReturnBtn2; // 인스펙터에서 할당할 설정 버튼
    public GameObject[] buttons; // 숨길 버튼들
    void Start()
    {
        setOptionBtn.onClick.AddListener(OptionOpen); // 리스너 추가
        setReturnBtn.onClick.AddListener(OptionClose); // 리스너 추가
        setReturnBtn2.onClick.AddListener(OptionClose); // 리스너 추가
    }

    void OptionOpen()
    {
        foreach (GameObject button in buttons)
        {
            button.SetActive(false);
        }
        // 기존의 버튼 숨기기
        
        optionsPanel.SetActive(true); // 옵션 패널 활성화, Canvas Group의 Alpha 값을 1로 설정하여 불투명하게 만들 수 있습니다.
        CanvasGroup canvasGroup = optionsPanel.GetComponent<CanvasGroup>();
        if (canvasGroup != null)
        {
            canvasGroup.alpha = 1f; // 패널을 완전히 불투명하게 만듭니다.
            canvasGroup.blocksRaycasts = true; // 패널이 레이캐스트를 막도록 합니다.
        }
    }

    // 옵션 패널을 비활성화하는 메서드
    public void OptionClose()
    {
        foreach (GameObject button in buttons)
        {
            button.SetActive(!button.activeSelf);
        }
        // 기존의 버튼 다시 활성화
        
        optionsPanel.SetActive(false); // 옵션 패널 비활성화 Canvas Group의 Alpha 값을 다시 0으로 설정합니다.
        CanvasGroup canvasGroup = optionsPanel.GetComponent<CanvasGroup>();
        if (canvasGroup != null)
        {
            canvasGroup.alpha = 0f; // 패널을 투명하게 만듭니다.
            canvasGroup.blocksRaycasts = false; // 패널이 레이캐스트를 막지 않도록 합니다.
        }
    }
}
