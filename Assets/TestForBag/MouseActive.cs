using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseActive : MonoBehaviour
{
    public int index;
    public GameObject activeRat;
    public GameObject[] destroyRats;

    GameObject indexRats;

    void OnMouseDown()
    {
        if (GameObject.Find("ChangeColor").GetComponent<TagChoose>().activeDestroy == true)
        {
            activeRat.SetActive(true);

            for (int i = 0; i < index; i++)
            {
                indexRats = destroyRats[i];
                Destroy(indexRats);
            }
        }
        }

    }

