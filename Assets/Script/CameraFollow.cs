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

    public Transform wallLeft;
    public Transform wallRight;
	
    private Vector3 desiredPosition;

    private bool canMoveCamera = true;

	private Vector3 initialCameraPosition;
    // Start is called before the first frame update
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
	
	if ((cameraLeftEdge - wallLeft.position.x < 0.01f)) // ta parando aqui :(
		return;

        // Atualiza a posição da câmera
        transform.position = smoothedPosition;
	}
}

