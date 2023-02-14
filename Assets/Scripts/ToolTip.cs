using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ToolTip : MonoBehaviour
{
    public static ToolTip instance;
    public Transform Text;
    public Transform Background;
    public int padding;

    private TextMeshProUGUI toolTipText;
    private RectTransform background;
    private RectTransform rectTransform;
    private RectTransform canvasRect;
    private void Awake()
    {
        instance = this;
        toolTipText = Text.GetComponent<TextMeshProUGUI>();
        background = Background.GetComponent<RectTransform>();
        rectTransform = this.transform.GetComponent<RectTransform>();
        canvasRect = GameObject.Find("Canvas").GetComponent<RectTransform>();
        HideToolTip();
    }
    public void SetText(string toolTipString)
    {
        toolTipText.SetText(toolTipString);
        toolTipText.ForceMeshUpdate();

        Vector2 textSize = toolTipText.GetRenderedValues(false);
        textSize += new Vector2(padding * 2, padding * 2);

        background.sizeDelta = textSize;
    }

    private void Update()
    {
        Vector2 anchoredPosition = Input.mousePosition / canvasRect.localScale.x;
        anchoredPosition += new Vector2(1, 1);

        if(anchoredPosition.x + background.rect.width > canvasRect.rect.width)
        {
            anchoredPosition.x = canvasRect.rect.width - background.rect.width;
        }
        if (anchoredPosition.y + background.rect.height > canvasRect.rect.height)
        {
            anchoredPosition.y = canvasRect.rect.height - background.rect.height;
        }   

        rectTransform.anchoredPosition = anchoredPosition;
    }

    private void ShowToolTip(string text)
    {
        gameObject.SetActive(true);
        SetText(text);
    }
    private void HideToolTip()
    {
        gameObject.SetActive(false);
    }

    public static void ShowToolTipStatic(string text)
    {
        instance.ShowToolTip(text);
    }
    public static void HideToolTipStatic()
    {
        instance.HideToolTip();
    }
}
