using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMovingObject : MonoBehaviour
{
    // Список точек, по которым объект будет перемещаться
    public Transform[] points;
    private int currentPointIndex = 0;

    // Скорость перемещения объекта
    public float moveSpeed = 5f;
    // Задержка между циклами перемещения
    public float pauseDuration = 2f;

    private bool isPaused = false;

    void Update()
    {
        // Если идет пауза, прекращаем дальнейшие действия
        if (isPaused || points.Length == 0) return;

        // Определяем текущую целевую точку
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

    // Корутину для паузы перед новым циклом
    IEnumerator PauseBeforeRestart()
    {
        isPaused = true;
        yield return new WaitForSeconds(pauseDuration);
        isPaused = false;
    }
}
