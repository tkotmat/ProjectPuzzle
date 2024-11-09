using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DestroyPlayer : MonoBehaviour
{
    private Canvas canvas;
    private GameObject panel;

    private void Awake()
    {
        canvas = GetComponent<Canvas>();

    }

    // ��� ����, ������� �������� ������� ������
    [SerializeField] private string playerTag = "Player";

    // ����������� ��� ������������ � ������� �����������
    private void OnCollisionEnter(Collision collision)
    {
        // ���������, ����� �� ������ � ����������� ������ ���
        if (collision.gameObject.CompareTag(playerTag))
        {
            // ���������� ������ ������
            Destroy(collision.gameObject);

            if (canvas != null)
            {
                // ������� ������ Panel ������ Canvas �� �����
                panel = canvas.transform.Find("Panel")?.gameObject;

                if (panel != null)
                {
                    Debug.Log("Panel ������!");
                }
            }
        }
    }
}
