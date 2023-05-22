using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UiElementDragAndDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler//, IPointerDownHandler
{
    private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    public Transform oldParent;
    private const string invContent = "InventoryContent";
    private const string baseContent = "BaseContent";
    private const string upgradeContent = "Upgrades";
    public int position = -1;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GameObject.FindWithTag("MainCanvas").GetComponent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if(this.GetComponent<UiElement>().item.rarity == 0)
        {
            return;
        }
        canvasGroup.alpha = 0.5f;
        canvasGroup.blocksRaycasts = false;
        this.oldParent = this.transform.parent;
        this.transform.SetParent(canvas.transform);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (this.GetComponent<UiElement>().item.rarity == 0)
        {
            return;
        }
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        UpgradeWindow.instance.UpdateWithoutOpening();
        Ui.instance.LoadTurrets();
        Destroy(eventData.pointerDrag.gameObject);
        //canvasGroup.alpha = 1f;
        //canvasGroup.blocksRaycasts = true;
        Ui.instance.UpdateAllWindows();
    }

    public void OnDrop(PointerEventData eventData)
    {
        Transform dropppedObject = eventData.pointerDrag.transform;
        Debug.Log("UiElDragNDrop");
        Debug.Log(this.transform.parent.name);
        if (eventData.pointerDrag.GetComponent<UiElement>().item == null)
        {
            return;
        }
        IItem item = eventData.pointerDrag.GetComponent<UiElement>().item;
        switch (this.transform.parent.name)
        {
            case invContent:
                if (dropppedObject.GetComponent<UiElementDragAndDrop>().oldParent.name == invContent)
                {
                    break;
                }
                Detach(item);
                Player.instance.inventory.Add(item);
                break;
            case upgradeContent:
                Detach(item);
                break;
        }
        Destroy(dropppedObject.gameObject);
        UpgradeWindow.instance.UpdateWithoutOpening();
        Ui.instance.LoadTurrets();
    }
    private void Detach(IItem item)
    {
        if (Player.instance.inventory.Contains(item))
        {
            Player.instance.inventory.Remove(item);
        }

        if (BaseScript.instance.inventory.Contains(item))
        {
            BaseScript.instance.inventory.Remove(item);
        }
        if (item.type != "upgrade")
        {
            return;
        }
        Debug.Log("Detaching Upgrade");
        for(int i = 0; i < UpgradeWindow.instance.tower.upgrades.Length; i++)
        {
            UpgradeItem upgrade = UpgradeWindow.instance.tower.upgrades[i];
            if (upgrade == (UpgradeItem)item)
            {
                UpgradeWindow.instance.tower.upgrades[i] = null;
            }
        }
        if(position == -1)
        {
            return;
        }
        UpgradeWindow.instance.tower.AddUpgrade((UpgradeItem)item, position);
    }
}
