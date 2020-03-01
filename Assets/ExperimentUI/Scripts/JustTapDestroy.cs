using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JustTapDestroy : MonoBehaviour
{
    public AudioClip[] aMusic;
    public AudioSource aReaction;
    string aName;
    int index;

    public bool indexActive;

    void Start()
    {
        //get audi component which is set to anyobject
        aReaction = GetComponent<AudioSource>();
        indexActive = true;
    }

    void Update()
    {
        //tap for android
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                //all name of tag, we can use for each new sound
                aName = hit.transform.gameObject.tag;
                switch (aName)
                {
                    //tag for song
                    case "Box":
                        aReaction.clip = aMusic[index];
                        aReaction.Play();
                        break;
                }
            }

           if (hit.collider.tag == "Box")
                {
                //destroy to object, no diactive mesh rendering. we have to destroy this to put our mouse.
                    Destroy(hit.transform.gameObject);
                }
            }
    }
}

