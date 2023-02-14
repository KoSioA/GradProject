using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UiElement : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public IItem item;
    private void Update()
    {
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        ToolTip.ShowToolTipStatic(item.ToString());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ToolTip.HideToolTipStatic();
    }
}
