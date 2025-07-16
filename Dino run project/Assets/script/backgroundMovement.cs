using System.Runtime.CompilerServices;
using UnityEngine;

public class backgroundMovement : MonoBehaviour
{
    [SerializeField] private MeshRenderer _meshRenderer;

    [SerializeField] private float animateSpeed = 1f;
    void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void  Update()
    {
        _meshRenderer.material.mainTextureOffset += new Vector2(animateSpeed * Time.deltaTime, 0);
    }
}


    
    
    


