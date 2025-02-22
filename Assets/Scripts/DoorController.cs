using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public float rotationSpeed = 30f; // Скорость вращения
    public float rotationAngle = 90f; // Угол вращения в градусах
    private bool isRotating = false; // Флаг, указывающий, происходит ли вращение
    private bool isClosed = true; // Состояние двери
    [SerializeField] public Transform _door = null;
    [SerializeField] public Transform _bone = null;
    void Start()
    {
        //_door = transform.Find("DoorBone/Door");
        //_bone = transform.Find("DoorBone/Bone");

    }


    public void ToggleDoor()
    {
        if (!isRotating)
        {
            StartCoroutine(RotateModel(rotationAngle));
        }
    }

    // Корутину для вращения модели
    private IEnumerator RotateModel(float targetAngle)
    {
        if (isClosed)
        {   
            isRotating = true; // Устанавливаем флаг вращения в true
            float currentAngle = 0f; // Текущий угол вращения

            // Определяем направление вращения
            float direction = targetAngle > 0 ? 1f : -1f;

            while (Mathf.Abs(currentAngle) < Mathf.Abs(targetAngle))
            {
                // Вычисляем шаг вращения
                float step = rotationSpeed * Time.deltaTime * direction;
                _door.RotateAround(_bone.position, Vector3.up, step);
                currentAngle += step;
                yield return null; // Ждем следующего кадра
            }

            // Устанавливаем модель в конечное положение
            _door.RotateAround(_bone.position, Vector3.up, targetAngle - currentAngle);
            isRotating = false; // Устанавливаем флаг вращения в false
            isClosed = !isClosed;

        }
        else
        {
            targetAngle = -1 * targetAngle;
            isRotating = true; // Устанавливаем флаг вращения в true
            float currentAngle = 0f; // Текущий угол вращения

            // Определяем направление вращения
            float direction = targetAngle > 0 ? 1f : -1f;

            while (Mathf.Abs(currentAngle) < Mathf.Abs(targetAngle))
            {
                // Вычисляем шаг вращения
                float step = rotationSpeed * Time.deltaTime * direction;
                _door.RotateAround(_bone.position, Vector3.up, step);
                currentAngle += step;
                yield return null; // Ждем следующего кадра
            }

            // Устанавливаем модель в конечное положение
            _door.RotateAround(_bone.position, Vector3.up, targetAngle - currentAngle);
            isRotating = false; // Устанавливаем флаг вращения в false
            isClosed = !isClosed;
        }
    }
}
