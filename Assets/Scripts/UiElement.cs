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
        string name = eventData.pointerCurrentRaycast.gameObject.name;
        if (name == "ToolTip" || name == "Background" || name == "ToolTipText")
        {
            return;
        }
        ToolTip.HideToolTipStatic();
    }
}
