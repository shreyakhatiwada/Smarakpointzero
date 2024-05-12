using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTouch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began){
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit)){
                if(hit.collider!=null){
                    DestroyObject();
                }
            }
        }
        
        // Desktop Test
        if(Input.GetMouseButtonDown(0)){
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit)){
                if(hit.collider!=null){
                    DestroyObject();
                }
            }
        }
        
    }

    void DestroyObject(){
        //kills the game object in 5 seconds after loading the object
        Destroy(gameObject);
    }
}
