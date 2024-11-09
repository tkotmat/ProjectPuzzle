using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseOnTrigger : MonoBehaviour
{
    // ���������� ��� �������� �������, ������� ����� ������������ (��������, ���� �����)
    public GameObject pauseMenu;

    // ��� ���� ������, ������� �������� ����� ��� ������� ��������
    public string playerTag = "Player";

    private void Start()
    {
        // ����������, ��� ���� ����� ������ ��� �������
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // ���������, ��� ������� �������� ������ � ����� ������
        if (other.CompareTag(playerTag))
        {
            // ������ ���� �� �����
            Time.timeScale = 0;

            // ���������� ���� �����
            if (pauseMenu != null)
            {
                pauseMenu.SetActive(true);
            }
        }
    }

    // ������� ��� ������ ���� � �����
    public void ResumeGame()
    {
        // �������� ���� �����
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(false);
        }

        // ������������ ����
        Time.timeScale = 1;
    }
}
