using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerUi : MonoBehaviour
{
    public void QuitGame()
    {
        // ������� ��������� � ������� ��� �������� � ��������� Unity
        Debug.Log("���� �����������");

        // ��������� ����
        Application.Quit();
    }
}
