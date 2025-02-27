using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public float rotationSpeed = 30f; // �������� ��������
    public float rotationAngle = 90f; // ���� �������� � ��������
    private bool isRotating = false; // ����, �����������, ���������� �� ��������
    private bool isClosed = true; // ��������� �����
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

    // �������� ��� �������� ������
    private IEnumerator RotateModel(float targetAngle)
    {
        if (isClosed)
        {   
            isRotating = true; // ������������� ���� �������� � true
            float currentAngle = 0f; // ������� ���� ��������

            // ���������� ����������� ��������
            float direction = targetAngle > 0 ? 1f : -1f;

            while (Mathf.Abs(currentAngle) < Mathf.Abs(targetAngle))
            {
                // ��������� ��� ��������
                float step = rotationSpeed * Time.deltaTime * direction;
                _door.RotateAround(_bone.position, Vector3.up, step);
                currentAngle += step;
                yield return null; // ���� ���������� �����
            }

            // ������������� ������ � �������� ���������
            _door.RotateAround(_bone.position, Vector3.up, targetAngle - currentAngle);
            isRotating = false; // ������������� ���� �������� � false
            isClosed = !isClosed;

        }
        else
        {
            targetAngle = -1 * targetAngle;
            isRotating = true; // ������������� ���� �������� � true
            float currentAngle = 0f; // ������� ���� ��������

            // ���������� ����������� ��������
            float direction = targetAngle > 0 ? 1f : -1f;

            while (Mathf.Abs(currentAngle) < Mathf.Abs(targetAngle))
            {
                // ��������� ��� ��������
                float step = rotationSpeed * Time.deltaTime * direction;
                _door.RotateAround(_bone.position, Vector3.up, step);
                currentAngle += step;
                yield return null; // ���� ���������� �����
            }

            // ������������� ������ � �������� ���������
            _door.RotateAround(_bone.position, Vector3.up, targetAngle - currentAngle);
            isRotating = false; // ������������� ���� �������� � false
            isClosed = !isClosed;
        }
    }
}
