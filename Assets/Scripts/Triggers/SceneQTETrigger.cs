using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneQTETrigger : MonoBehaviour
{
    
    [SerializeField] int _sceneNumber;


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "player")
        {
            //���������� ����� ����� ������� ���������
            //�������� ������� � ���������� �������� ������ �����
            //Action(sceneNum)
        }
    }


    
}
