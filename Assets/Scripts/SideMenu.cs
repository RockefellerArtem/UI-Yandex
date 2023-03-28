using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class SideMenu : MonoBehaviour
{
    [SerializeField] private Animator _animator;


    [Header("Dialog Window")] 
    [SerializeField] private GameObject _window;
    [SerializeField] private TMP_InputField _inputName;
    [SerializeField] private Button _enterButton;
    [SerializeField] private TMP_Text _showInputNameText;

    [SerializeField] private Button _showWindow;
    
    private bool _isActive = true;

    private string _name;

    private void Start()
    {
        InitializationButton();
    }

    private void InitializationButton()
    {
        _enterButton.onClick.AddListener(InputName);
        _showWindow.onClick.AddListener(HandlerClickShowButton);
    }


    public void Switch() {
        
        _isActive = !_isActive;

        if (_isActive) {
            _animator.SetTrigger("Show");
        }
        else {
            _animator.SetTrigger("Hide");
        }

    }

    private void InputName()
    {
        _name = _inputName.text;
        
        if (_name == null) return;
        
        _showInputNameText.text = _name;
        
        SetEnableWindow(false);
    }

    private void HandlerClickShowButton()
    {
        SetEnableWindow(true);
    }

    private void SetEnableWindow(bool isActive)
    {
        _window.SetActive(isActive);
    }

}
