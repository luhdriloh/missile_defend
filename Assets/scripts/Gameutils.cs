using UnityEngine;
using System.Collections;

public class GameUtils : MonoBehaviour
{
    /// <summary>
    /// Normalizes the force vector so that we get the same speed all around
    /// </summary>
    /// <returns>A new normalized force vector</returns>
    /// <param name="vector">Vector.</param>
    /// <param name="newHypotenuse"></param>
    public static Vector2 NormalizeVector(Vector2 vector, float newHypotenuse)
    {

        float oldHypotenuse = Mathf.Sqrt(Mathf.Pow(vector.x, 2) + Mathf.Pow(vector.y, 2));
        float oldYRatio = vector.y / oldHypotenuse;
        float oldXRatio = vector.x / oldHypotenuse;

        float newX = newHypotenuse * oldXRatio;
        float newY = newHypotenuse * oldYRatio;

        return new Vector2(newX, newY);
    }
}
