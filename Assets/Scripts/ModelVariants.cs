using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ModelVariants : MonoBehaviour
{
    [SerializeField] private List<ControleStartAnimation> _controleStartAnimations;
    [SerializeField] private Animator _animator;
    
    [SerializeField] private GameObject[] _models;
    [SerializeField] private TMP_Dropdown _dropdown;

    private GameObject _currenSelected;

    private void Start()
    {
        InitializationSelect();
    }

    public void Select(int index) 
    {
        _currenSelected.SetActive(false);
        _currenSelected = _models[index];
        _currenSelected.SetActive(true);
    }

    private void InitializationSelect()
    {
        _currenSelected = _models[0];

        List<TMP_Dropdown.OptionData> _optionDataList = new List<TMP_Dropdown.OptionData>();
        foreach (var item in _models)
        {
            TMP_Dropdown.OptionData data = new TMP_Dropdown.OptionData();
            data.text = item.name;
            _optionDataList.Add(data);
        }
        _dropdown.options = _optionDataList;

        _dropdown.onValueChanged.AddListener(Select);   
    }

    public void StartAnimations()
    {
        for (int i = 0; i < _controleStartAnimations.Count; i++)
        {
            _controleStartAnimations[i].gameObject.SetActive(true);
            _controleStartAnimations[i].StartAnimation();
        }
    }
}
