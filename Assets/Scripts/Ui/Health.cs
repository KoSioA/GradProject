using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public GameObject text;
    public GameObject slider;


    private void Update()
    {
        slider.transform.GetComponent<Slider>().value = Player.instance.health;
        text.GetComponent<TextMeshProUGUI>().text = Player.instance.health + "/" + Player.instance.maxHealth;
    }
}
