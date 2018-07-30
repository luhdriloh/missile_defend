using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileCommandScript : MonoBehaviour
{
    public GameObject missile;
    private Camera cam;

    // Use this for initialization
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 position = (Vector2)cam.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log("mouse position is: (" + position.x + ", " + position.y + ")");
            GameObject x = Instantiate(missile, position, Quaternion.identity);

            Quaternion target = Quaternion.Euler(0, 0, 45f);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 1);

            Debug.Log("position: " + x.ToString());


        }
    }
}
