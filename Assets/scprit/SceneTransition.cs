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
            // Если в списке 0 объектов, загружаем следующую сцену
            if (tagbject.Count <= 1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            // Если в списке более 1 объекта, уничтожаем текущий объект и обновляем список
            else if (tagbject.Count > 1)
            {
                Destroy(other.gameObject); // Уничтожаем объект игрока
                tagbject.Remove(other.gameObject); // Удаляем его из списка
            }
        }
    }
}
