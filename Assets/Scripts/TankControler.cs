using System.Collections;
using System.Collections.Generic;
using UnityEngine;  //Kurs2
using UnityEngine.UI; //Kurs2

public class TankControler : MonoBehaviour
{
    public float speed;
    public float angularSpeed;
    public float shotPower;
    public GameObject bullet;
    public Transform spawner;
    public GameObject newBullet;
   // public GameObject barrel, tower;
    public float rotation_speed;
    public float speed_barrel;
    public int ammo;
    public Text ammoText;
    // Use this for initialization
    void Start()
    {

    }

    void Update()
    {

        transform.Translate(Vector3.forward * speed * Input.GetAxis("Vertical") * Time.deltaTime); // poruszanie przód tył
        transform.Translate(Vector3.right * speed * Input.GetAxis("Horizontal") * Time.deltaTime); //poruszanie lewo prawo

        // RUCHY ROTACYJNE(Q&E)
        if (Input.GetKey(KeyCode.E))
            transform.Rotate(Vector3.up * angularSpeed);
        if (Input.GetKey(KeyCode.Q))
            transform.Rotate(Vector3.down * angularSpeed);

        //RUCHY ROTACYJNE TOWER'A (J&L)
        if (Input.GetKey(KeyCode.L))
            transform.Rotate(Vector3.up * rotation_speed);
        if (Input.GetKey(KeyCode.J))
            transform.Rotate(Vector3.down * rotation_speed);

        //RUCHY PIONOWE BARREL'A (I&K)
        if (Input.GetKey(KeyCode.I))
            transform.Rotate(Vector3.left * speed_barrel);
        if (Input.GetKey(KeyCode.K))
            transform.Rotate(Vector3.right * speed_barrel);

        ammoText.text = "AMMO: " + ammo; // dodaje liczbe amunicji do obiektu "Text ammoText", którą wyświetla na ekranie 

        //STRZELANIE
        if (Input.GetKeyDown(KeyCode.Space) && ammo > 0)
        {
            newBullet = Instantiate(bullet, spawner.position, spawner.transform.rotation);
            newBullet.GetComponent<Rigidbody>().AddForce(spawner.transform.forward * shotPower);
            ammo--; // za każdym strzałem odejmuje 1 ammo
        }

    }
    // skrzynka z ammo  
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "AmmoBox")
        {
            ammo = ammo + 30;
            Destroy(collision.gameObject);
        }
    }
}
// 1.Poruszanie towerem lewo prawo + poruszanie barrelem góra dół
// 2.HP GRACZA, CZOŁGI KAMIKADZE, WYSWIETLANIE HP GRACZA JAKO TEXT + SLIDER
