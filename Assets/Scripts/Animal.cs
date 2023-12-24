using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    [SerializeField] private float HP = 100.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Weapon"))
        {
            this.HP -= (other.GetComponent<Sword>() ? 15.0f : 25.0f);
            if (this.HP < 0)
            {
                Destroy(this.gameObject);
                GameObject item = Resources.Load<GameObject>("KFC");
                Vector3 pos = new Vector3(this.transform.position.x, this.transform.position.y + 1.0f, this.transform.position.z);
                GameObject NEW = Instantiate(item, pos, Quaternion.identity);
                NEW.GetComponent<Rigidbody>().isKinematic = true;
                NEW.transform.SetParent(null);
                NEW.GetComponent<Item>().inSlot = false;
                NEW.GetComponent<Item>().currentSlot = null;
            }
        }
    }
}
