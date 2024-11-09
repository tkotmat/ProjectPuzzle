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

    // Имя тега, который присвоен объекту игрока
    [SerializeField] private string playerTag = "Player";

    // Срабатывает при столкновении с обычным коллайдером
    private void OnCollisionEnter(Collision collision)
    {
        // Проверяем, имеет ли объект с коллайдером нужный тег
        if (collision.gameObject.CompareTag(playerTag))
        {
            // Уничтожаем объект игрока
            Destroy(collision.gameObject);

            if (canvas != null)
            {
                // Находим объект Panel внутри Canvas по имени
                panel = canvas.transform.Find("Panel")?.gameObject;

                if (panel != null)
                {
                    Debug.Log("Panel найден!");
                }
            }
        }
    }
}
