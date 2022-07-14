using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{

    [SerializeField] Color32 hasPackageColor = new Color32(1,1,1,1);
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);

    bool hasPackage = false;
    [SerializeField] float timeDespawn = 1f;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Ayylmao they touched");

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package picked up");
            hasPackage = true;
            Destroy(collision.gameObject, timeDespawn);
            spriteRenderer.color = hasPackageColor;
        }

        if(collision.tag == "Customer" && hasPackage)
        {
            Debug.Log("Product Delivered");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }

    }
}
