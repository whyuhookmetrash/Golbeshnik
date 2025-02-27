using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public float openAngle = 90f; // ���� �������� �����
    public float speed = 2f; // �������� �������� �����
    private Quaternion closedRotation; // ��������� ����� � �������� ���������
    private Quaternion openRotation; // ��������� ����� � �������� ���������
    bool isClosed = true; // ��������� �����
    public bool Condition
    {
        get { return isClosed; }
        set
        {
            isClosed = value;
        }
    }
    void Start()
    {
        closedRotation = transform.rotation;
        openRotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y + openAngle, transform.eulerAngles.z);
    }


    public void OpenDoor()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, openRotation, Time.deltaTime * speed);
        isClosed = false;
    }

    public void CloseDoor()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, closedRotation, Time.deltaTime * speed);
        isClosed = true;
    }
}
