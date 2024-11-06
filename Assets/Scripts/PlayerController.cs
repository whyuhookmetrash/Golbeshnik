using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 5f;
    public float rotationSpeed = 100f;
    public float acceleration = 2f;
    public float mouseSensitivity = 1f;
    public float verticalRotationSpeed = 100f;

    private float currentSpeed;
    private Transform cameraTransform;
    private float verticalRotation;
    private Vector2 lastMousePosition; // Хранит предыдущее положение мыши

    void Start()
    {
        cameraTransform = Camera.main.transform;
        lastMousePosition = Input.mousePosition;
    }

    void Update()
    {
        // Получаем ввод с клавиатуры
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Получаем относительное движение мыши
        Vector2 mouseDelta = (Vector2)Input.mousePosition - lastMousePosition;
        lastMousePosition = Input.mousePosition; // Обновляем предыдущее положение

        // Вращение камеры и игрока с помощью мыши
        float mouseX = mouseDelta.x * mouseSensitivity; // Используем относительное движение
        float mouseY = mouseDelta.y * mouseSensitivity;

        cameraTransform.Rotate(Vector3.up * mouseX);
        transform.Rotate(Vector3.up * mouseX);

        // Вращение камеры по вертикали
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -80f, 80f);
        cameraTransform.localEulerAngles = new Vector3(verticalRotation, cameraTransform.localEulerAngles.y, 0);

        // Движение в направлении, заданном камерой
        Vector3 horizontalDirection = cameraTransform.forward; // Используем только горизонтальное направление
        horizontalDirection.y = 0; // Обнуляем вертикальную составляющую
        horizontalDirection.Normalize(); // Нормализуем вектор

        Vector3 movement = horizontalDirection * verticalInput + cameraTransform.right * horizontalInput;
        transform.Translate(movement * speed * Time.deltaTime);

        // Ускорение с помощью Shift
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed += acceleration * Time.deltaTime * 2f;
        }
        else
        {
            currentSpeed += acceleration * Time.deltaTime;
        }
        speed = Mathf.Clamp(currentSpeed, 0f, 10f);
    }
}
    

