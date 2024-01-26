using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    [SerializeField] Color32 hasFuelColor = new Color(1,1,1,1);
    [SerializeField] Color32 normalColor = new Color(1,1,1,1);

    SpriteRenderer spriteRenderer;
    bool hasFuel = false;
    Driver driver;


    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        driver = GetComponent<Driver>();
    }
    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("AUCH!");
        driver.moveSpeed = driver.normalSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Fuel" && !hasFuel){
            Debug.Log("Picked up fuel!");
            hasFuel = true;
            spriteRenderer.color = hasFuelColor;
            Destroy(other.gameObject);
        }
        else if(other.tag =="Nitro" && hasFuel){
            Debug.Log("Nitro Boost!");
            hasFuel = false;
            spriteRenderer.color = normalColor;
            driver.moveSpeed = driver.nitroSpeed;
        }
    }
}
