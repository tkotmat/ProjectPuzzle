using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseOnTrigger : MonoBehaviour
{
    // Переменная для хранения объекта, который будет отображаться (например, меню паузы)
    public GameObject pauseMenu;

    // Имя тега игрока, который вызывает паузу при касании триггера
    public string playerTag = "Player";

    private void Start()
    {
        // Убеждаемся, что меню паузы скрыто при запуске
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Проверяем, что триггер коснулся объект с тегом игрока
        if (other.CompareTag(playerTag))
        {
            // Ставим игру на паузу
            Time.timeScale = 0;

            // Отображаем меню паузы
            if (pauseMenu != null)
            {
                pauseMenu.SetActive(true);
            }
        }
    }

    // Функция для снятия игры с паузы
    public void ResumeGame()
    {
        // Скрываем меню паузы
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(false);
        }

        // Возобновляем игру
        Time.timeScale = 1;
    }
}
