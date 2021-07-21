using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loading_canvas : MonoBehaviour
{
    public GameObject[] object_view;
    void OnEnable()
    { 
        StartCoroutine(Process());
    }
    IEnumerator Process()
    {
        object_view[0].SetActive(true);
        object_view[1].SetActive(false);
        object_view[2].SetActive(false);
        yield return new WaitForSeconds(0.5f);
        object_view[0].SetActive(false);
        object_view[1].SetActive(true);
        object_view[2].SetActive(false);
        yield return new WaitForSeconds(0.5f);
        object_view[0].SetActive(false);
        object_view[1].SetActive(false);
        object_view[2].SetActive(true);
        yield return new WaitForSeconds(0.5f);
        object_view[0].SetActive(false);
        object_view[1].SetActive(false);
        object_view[2].SetActive(false);
        gameObject.SetActive(false);
    }

}
