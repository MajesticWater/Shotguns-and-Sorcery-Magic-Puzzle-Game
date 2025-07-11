using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangeScript : MonoBehaviour
{
    [SerializeField] Material tableColor;
    [SerializeField] GameObject explosion;
    [SerializeField] float offset = 5;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "butterfly")
        {
            other.GetComponent<Renderer>().material = tableColor;
            Instantiate(explosion, new Vector3(transform.position.x, transform.position.y + offset, transform.position.z), transform.rotation);
        }
    }
}
