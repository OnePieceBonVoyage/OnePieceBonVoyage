using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraFollow : MonoBehaviour
{
    public Transform target1;
    public Transform target2;
    public Vector3 offset;

    public float smoothSpeed = 0.125f;
    public float yOffset = 0f;

    public Transform wallLeft;
    public Transform wallRight;

    private Vector3 desiredPosition;
    private Vector3 initialCameraPosition;

    private bool canMoveCamera = true;

    void Start()
    {
        initialCameraPosition = transform.position;
    }

    private float cameraLeftEdge;
    private float cameraRightEdge;
    private float cameraWidth;

    void LateUpdate()
    {
        UpdateCamera();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private Vector3 lastPosition = new Vector3();

    private int ComparePositionX(Vector3 pos1, Vector3 pos2)
    {
        if (pos1.x > pos2.x) return 1;
        if (pos1.x < pos2.x) return -1;
        return 0;
    }

    private enum Direcao { LTR, RTL }

    void UpdateCamera()
    {
        Vector3 middlePoint = (target1.position + target2.position) / 2f;

        // Calcula a posição desejada para a câmera
        desiredPosition = transform.position;
        desiredPosition.x = middlePoint.x;

        // Utiliza o SmoothDamp para suavizar o movimento da câmera
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        cameraRightEdge = Camera.main.ViewportToWorldPoint(new Vector3(1, 0.5f, smoothedPosition.x)).x;
        cameraLeftEdge = Camera.main.ViewportToWorldPoint(new Vector3(0, 0.5f, smoothedPosition.x)).x;

        Direcao direcao;

        if (ComparePositionX(lastPosition, smoothedPosition) != 1)
            direcao = Direcao.LTR;
        else
            direcao = Direcao.RTL;

        Debug.Log(direcao);

        if (direcao == Direcao.RTL)
        {
            if (wallLeft.position.x > cameraLeftEdge) return;
        }
        else if (direcao == Direcao.LTR)
        {
            if (wallRight.position.x < cameraRightEdge) return;
        }

        // Atualiza a posição da câmera
        transform.position = smoothedPosition;
        lastPosition = transform.position;
    }
}