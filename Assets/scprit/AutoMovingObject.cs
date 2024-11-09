using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMovingObject : MonoBehaviour
{
    // ������ �����, �� ������� ������ ����� ������������
    public Transform[] points;
    private int currentPointIndex = 0;

    // �������� ����������� �������
    public float moveSpeed = 5f;
    // �������� ����� ������� �����������
    public float pauseDuration = 2f;

    private bool isPaused = false;

    void Update()
    {
        // ���� ���� �����, ���������� ���������� ��������
        if (isPaused || points.Length == 0) return;

        // ���������� ������� ������� �����
        Transform targetPoint = points[currentPointIndex];
        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPoint.position) < 0.1f)
        {
            currentPointIndex++;

            if (currentPointIndex >= points.Length)
            {
                currentPointIndex = 0;
                StartCoroutine(PauseBeforeRestart());
            }
        }
    }

    // �������� ��� ����� ����� ����� ������
    IEnumerator PauseBeforeRestart()
    {
        isPaused = true;
        yield return new WaitForSeconds(pauseDuration);
        isPaused = false;
    }
}
