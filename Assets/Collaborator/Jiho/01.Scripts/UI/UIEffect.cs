using System;
using UnityEngine;

public class UIEffect : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float edgeThreshold = 0.1f;
    [SerializeField] private float xClamp = 2f, yClamp = 2f;

    private Vector3 lastMousePosition;
    
    void Start()
    {
        lastMousePosition = Input.mousePosition;
    }
    
    private void Update()
    {
        var currentMousePosition = Input.mousePosition;
        var mouseDelta = currentMousePosition - lastMousePosition;
        var newPosition = transform.position + mouseDelta * (moveSpeed * Time.deltaTime);
        
        newPosition.x = Mathf.Clamp(newPosition.x, -xClamp, xClamp);
        newPosition.y = Mathf.Clamp(newPosition.y, -yClamp, yClamp);
        
        transform.position = newPosition;
        lastMousePosition = currentMousePosition;
    }
}
