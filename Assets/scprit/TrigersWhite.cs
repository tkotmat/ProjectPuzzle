using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigersWhite : MonoBehaviour
{
    [SerializeField] private List<GameObject> staticObjects; // Список объектов
    [SerializeField] private Material WhiteMaterial;

    private MeshRenderer[] gravikObiectRenderers; // Массив рендереров
    private Material previousMaterial;
    private Collider[] staticObjectColliders; // Массив коллайдеров

    private void Awake()
    {
        int objectCount = staticObjects.Count;
        gravikObiectRenderers = new MeshRenderer[objectCount];
        staticObjectColliders = new Collider[objectCount];

        for (int i = 0; i < objectCount; i++)
        {
            gravikObiectRenderers[i] = staticObjects[i].transform.GetChild(0).GetComponent<MeshRenderer>();
            staticObjectColliders[i] = staticObjects[i].GetComponent<Collider>();
        }

        // Сохраняем предыдущий материал для первого объекта
        previousMaterial = gravikObiectRenderers[0].material;

        foreach (var collider in staticObjectColliders)
        {
            collider.enabled = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        foreach (MeshRenderer renderer in gravikObiectRenderers)
        {
            renderer.material = WhiteMaterial;
        }

        foreach (var collider in staticObjectColliders)
        {
            if (collider != null)
            {
                collider.enabled = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        foreach (var renderer in gravikObiectRenderers)
        {
            renderer.material = previousMaterial;
        }

        foreach (Collider collider in staticObjectColliders)
        {
            if (collider != null && collider.enabled == true)
            {
                collider.enabled = false;
            }
        }
    }
}
