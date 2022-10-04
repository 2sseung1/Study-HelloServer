using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ButtonEvent : MonoBehaviour
{
    protected Button _button;

    void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnClickEvent);
    }

    protected abstract void OnClickEvent();
}