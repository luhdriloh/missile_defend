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
            Vector3 position = cam.ScreenToWorldPoint(Input.mousePosition);
            GameObject newMissile = Instantiate(missile, GameConstants.PlayerMissileSpawnLocation, Quaternion.identity);

            // forward is short hand for the z
            Quaternion target = Quaternion.LookRotation(GameConstants.PlayerMissileSpawnLocation - position, Vector3.forward);
            newMissile.transform.rotation = target;

            // this produces a vector towards wherever the mouse is. need to normalize it somehow
            newMissile.GetComponent<MissileMovementScript>().SetForceVector(position - GameConstants.PlayerMissileSpawnLocation);

            // ONLY rotate around z remove the other
            newMissile.transform.eulerAngles = new Vector3(0, 0, newMissile.transform.eulerAngles.z);
        }
    }
}
