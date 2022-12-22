using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class UICoinsText : MonoBehaviour
{
    private TextMeshProUGUI tmproText;

    private void Awake()
    {
        tmproText = GetComponent<TextMeshProUGUI>();
    }
    private void Start()
    {
        GameManager.Instance.OnCoinsChanged += HandleOnCoinsChanged;
    }

    private void HandleOnCoinsChanged(int coinsCollected)
    {
        tmproText.text = coinsCollected.ToString();
    }
}
