using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClicker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        {
            foreach (Touch t in Input.touches)
            {
                if (t.phase == TouchPhase.Began)
                {
                    Vector3 point = new Vector3(t.position.x, t.position.y, 0);
                    Ray ray = Camera.main.ScreenPointToRay(point);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit))
                    {
                        hit.collider.SendMessage("OnMouseDown", null, SendMessageOptions.DontRequireReceiver);
                    }
                }
            }
        }
    }
}
