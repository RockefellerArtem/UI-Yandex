using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialManager : MonoBehaviour
{

    [SerializeField] private List<Renderer> _renderers;

    public void SetMaterial(Material material) 
    {
        for (int i = 0; i < _renderers.Count; i++)
        {
            _renderers[i].material = material;
        }
    }
}
