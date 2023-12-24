using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCooking : MonoBehaviour
{
    private bool isCooked = false;
    private void OnTriggerEnter(Collider other)
    {
        if (!isCooked && (other.CompareTag("Meet") || other.GetComponent<Drink>() != null))
        {
            StartCoroutine(CookingCoroutine(other.gameObject));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isCooked = false;
    }

    private IEnumerator CookingCoroutine(GameObject collidedObject)
    {
        Transform cruTransform = collidedObject.transform.Find("Cru");
        Transform cuitTransform = collidedObject.transform.Find("Cuit");

        if (cruTransform != null && cuitTransform != null)
        {
            yield return new WaitForSeconds(5f);

            cruTransform.gameObject.SetActive(false);
            cuitTransform.gameObject.SetActive(true);

            isCooked = true;
        }

        else if(collidedObject.GetComponent<Drink>() != null)
        {
            yield return new WaitForSeconds(5f);

            collidedObject.GetComponent<Drink>().set_drinkable();

            isCooked = true;
        }

    }
}

