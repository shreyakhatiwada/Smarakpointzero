using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadOnTouch : MonoBehaviour
{
    public GameObject Prefab;
    public bool isPressed = false;

    // Update is called once per frame
    void Start()
    {
        Prefab.SetActive(false);
    }

    void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                isPressed = !isPressed;
                if (hit.collider != null)
                {
                    if (isPressed)
                    {
                        SpawnObject();
                    }
                    else
                    {
                        DespawnObject();
                    }
                }
            }
        }

        // Desktop Test
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                isPressed = !isPressed;
                if (hit.collider != null)
                {
                    if (isPressed)
                    {
                        SpawnObject();
                    }
                    else
                    {
                        DespawnObject();
                    }
                }
            }
        }
    }

    void SpawnObject()
    {
        // Instantiate(Prefab, transform.position, Quaternion.identity);
        Prefab.SetActive(true);
    }

    void DespawnObject()
    {
        // Destroy(Prefab);
        Prefab.SetActive(false);
    }
}
