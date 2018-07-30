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

            // find the x, and y forces to make the speed constant
            Vector2 force = position - GameConstants.PlayerMissileSpawnLocation;
            Vector2 normalizedForce = NormalizeVector(force, GameConstants.PlayerMissileSpeed);

            Debug.Log("correct\nx: " + force.x + "\ty: " + force.y);
            Debug.Log("incorrect\nx: " + normalizedForce.x + "\ty: " + normalizedForce.y + "\n");
            

            // this produces a vector towards wherever the mouse is. need to normalize it somehow
            newMissile.GetComponent<MissileMovementScript>().SetForceVector(normalizedForce);

            // lets find the length of the force vector
            float length = Mathf.Sqrt(Mathf.Pow(position.x - GameConstants.PlayerMissileSpawnLocation.x, 2) + Mathf.Pow(position.y - GameConstants.PlayerMissileSpawnLocation.y, 2));
            //Debug.Log("The length of the force vector:" + length);

            // ONLY rotate around z remove the other
            newMissile.transform.eulerAngles = new Vector3(0, 0, newMissile.transform.eulerAngles.z);
            // Debug.Log("The euler angle is" + newMissile.transform.eulerAngles.z);
        }
    }

    private Vector2 NormalizeVector(Vector2 vector, float newHypotenuse)
    {
        float oldHypotenuse = Mathf.Sqrt(Mathf.Pow(vector.x, 2) + Mathf.Pow(vector.y, 2));
        float oldYRatio = Mathf.Abs(vector.y / oldHypotenuse);
        float oldXRatio = Mathf.Abs(vector.x / oldHypotenuse);

        float newX = newHypotenuse * oldXRatio * GetNumberSign(vector.x);
        float newY = newHypotenuse * oldYRatio * GetNumberSign(vector.y);

        return new Vector2(newX, newY);
    }

    private int GetNumberSign(float num)
    {
        return (int)(num / Mathf.Abs(num));
    }
}
