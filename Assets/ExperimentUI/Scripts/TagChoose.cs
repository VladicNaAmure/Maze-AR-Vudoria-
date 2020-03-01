using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagChoose : MonoBehaviour
{
    public AudioClip[] aMusic;
    public AudioSource aReaction;
    string aName;
    int index;

    public bool activeDestroy;

    void Start()
    {
        //we want each time to start without destroy of tap
        activeDestroy = false;
        // get source component for sound
        aReaction = GetComponent<AudioSource>();
    }

    void Update()
    {
        //tap of android
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                //use this for each object with tags and difference musics
                aName = hit.transform.gameObject.tag;
                switch (aName)
                {
                    case "Box":
                        aReaction.clip = aMusic[index];
                        aReaction.Play();
                        break;
                        //for example
                    /*case "BoxDisable":
                        aReaction.clip = aMusic[index];
                        aReaction.Play();
                        break;
                        //if a few objects
                    default:
                        break;*/
                }
            }

            if (activeDestroy == true)
            {
                if (hit.collider.tag == "Box")
                {
                    // expirements
                    //Diactive object
                    //hit.collider.gameObject.GetComponent<MeshRenderer>().enabled = false;
                    //solution to destroy objects
                    Destroy(hit.transform.gameObject);
                    //Rats destroy and active player
                    //transform.gameObject.tag = "BoxDisable";
                }
                // if we want to add new tag
                /*if (hit.collider.tag == "BoxDisable")
                {
                    //Diactive object
                    hit.collider.gameObject.GetComponent<MeshRenderer>().enabled = false;
                    transform.gameObject.tag = "Box";
                }*/
            }
            else
            {
                if (hit.collider.tag == "Box")
                {
                    //MeshRender is needed to change in name of Script to enable or disable
                    hit.collider.gameObject.GetComponent<FCP_ExampleScript>().enabled = false;

                    //hit.collider.transform.gameObject.tag = "BoxDisable";
                    //Signal of texture add
                }
                // if we want to add new tag
                /*if (hit.collider.tag == "BoxDisable")
                {
                    //MeshRender is needed to change in name of Script to enable or disable
                    hit.collider.gameObject.GetComponent<FCP_ExampleScript>().enabled = false;
                    hit.collider.transform.gameObject.tag = "Box";
                    //Signal of texture add
                }*/
            }
        }
    }

    //swith of for destroy and fix color mode
    public void ActiveDestroy()
    {
        activeDestroy = !activeDestroy;
    }

}

