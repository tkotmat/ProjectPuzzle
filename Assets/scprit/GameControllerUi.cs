using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerUi : MonoBehaviour
{
    public void QuitGame()
    {
        // Выводим сообщение в консоль для проверки в редакторе Unity
        Debug.Log("Игра закрывается");

        // Закрываем игру
        Application.Quit();
    }
}
