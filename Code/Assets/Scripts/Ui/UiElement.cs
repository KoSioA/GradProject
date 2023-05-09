using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UiElement : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public IItem item;
    public void OnPointerEnter(PointerEventData eventData)
    {
        ToolTip.ShowToolTipStatic(item.ToString());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        string name = "none";
        if (eventData.pointerCurrentRaycast.gameObject != null)
        {
            name = eventData.pointerCurrentRaycast.gameObject.name;
        }
        if (name == "ToolTip" || name == "Background" || name == "ToolTipText")
        {
            return;
        }
        ToolTip.HideToolTipStatic();
    }
}
