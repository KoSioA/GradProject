using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BaseUi : MonoBehaviour
{
    public TextMeshProUGUI text;
    void Update()
    {
        text.SetText(BaseScript.instance.inventory.Count.ToString());
    }
}
