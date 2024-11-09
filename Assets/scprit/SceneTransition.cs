using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    private List<GameObject> tagbject;
    private void Awake()
    {
        tagbject = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player"));
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // ���� � ������ 0 ��������, ��������� ��������� �����
            if (tagbject.Count <= 1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            // ���� � ������ ����� 1 �������, ���������� ������� ������ � ��������� ������
            else if (tagbject.Count > 1)
            {
                Destroy(other.gameObject); // ���������� ������ ������
                tagbject.Remove(other.gameObject); // ������� ��� �� ������
            }
        }
    }
}
