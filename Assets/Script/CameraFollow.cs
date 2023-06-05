using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraFollow : MonoBehaviour
{
    public Transform target1;
    public Transform target2;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public float yOffset = 0f;
    private Vector3 desiredPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void LateUpdate()
    {
        // Calcula a posição desejada para a câmera
        //desiredPosition = transform.position;
        //desiredPosition.x = target.position.x;

        // Utiliza o SmoothDamp para suavizar o movimento da câmera
        //Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Atualiza a posição da câmera
        //transform.position = smoothedPosition;

        Vector3 middlePoint = (target1.position + target2.position) / 2f;

        // Calcula a posição desejada para a câmera
        desiredPosition = transform.position;
        desiredPosition.x = middlePoint.x;

        // Utiliza o SmoothDamp para suavizar o movimento da câmera
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Atualiza a posição da câmera
        transform.position = smoothedPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}