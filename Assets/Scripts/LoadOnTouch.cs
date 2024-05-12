using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadOnTouch : MonoBehaviour
{
    public int numberOfPrefabs = 10;
    public GameObject[] Prefab;
    private bool isPressed = false;

    // Update is called once per frame
    void Start(){
        for (int i=0; i<numberOfPrefabs; i++){
            Prefab[i].SetActive(false);
        }
    }
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider != null && hit.collider.gameObject == gameObject)
                    {
                        isPressed = !isPressed;
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

        else if (Input.GetMouseButtonDown(0)) // If no touch, check for mouse click (for desktop)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null && hit.collider.gameObject == gameObject)
                {
                    isPressed = !isPressed;
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
        for (int i=0; i<numberOfPrefabs; i++){
            if (Prefab[i] != null)
            {
                Prefab[i].SetActive(true);
            }
        }
    }

    void DespawnObject()
    {
        for (int i=0; i<numberOfPrefabs; i++){
            if (Prefab[i] != null)
            {
                Prefab[i].SetActive(false);
            }
        }

    }
}
