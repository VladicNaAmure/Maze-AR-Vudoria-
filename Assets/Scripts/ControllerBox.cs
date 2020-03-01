using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerBox : MonoBehaviour
{
    public AudioClip[] aMusic;
    public AudioSource aReaction;
    string aName;

    int index;
    // Start is called before the first frame update
    void Start()
    {
        aReaction = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount>0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                aName = hit.transform.gameObject.tag;
                switch (aName)
                {
                    case "Box":
                        aReaction.clip = aMusic[index];
                        aReaction.Play();
                        break;
                }
            }
            if (hit.collider.tag == "Box")
            {
                hit.collider.gameObject.GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }
}
