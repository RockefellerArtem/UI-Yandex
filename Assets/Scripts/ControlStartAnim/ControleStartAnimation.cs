using System;
using System.Collections;
using Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;

public class ControleStartAnimation : MonoBehaviour, IAnimation
{
    [SerializeField] private Animator _animator;

    [SerializeField] private Camera _camera;
    
    [SerializeField] private Resources _resources;
    [SerializeField] private HitEffect _hitEffectPrefab;

    private int _coinsPerClick = 1;


    private void Update()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit)) 
        {
            if (hit.collider.TryGetComponent(out ControleStartAnimation clickable)) 
            {
                _resources.CollectCoins(1, transform.position);
                clickable.Hit();
                gameObject.SetActive(false);
            }
        }

    }
    
    public void StartAnimation()
    {
        StartCoroutine(AnimationStart());
    }
    
    public void Hit()
    {
        HitEffect hitEffect = Instantiate(_hitEffectPrefab, transform.position, Quaternion.identity);
        hitEffect.Init(_coinsPerClick);
    }

    private IEnumerator AnimationStart()
    {
        _animator.SetTrigger("Up");
        yield return null;
        _animator.SetTrigger("Down");
    }
}


