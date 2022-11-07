using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsideRoom : MonoBehaviour
{
    public Material wallMaterial,wallMaterial2,wallMaterial3;
    Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = gameObject.GetComponent<Renderer>();

        if (RandomWallColor() == 0)
        {
            rend.material = wallMaterial;
        }else if (RandomWallColor() == 1)
        {
            rend.material = wallMaterial2;
        }
        else
        {
            rend.material = wallMaterial3;
        }

        StartCoroutine(ColorOnOutsideRoom());
    }

    public IEnumerator ColorOnOutsideRoom()
    {
        while (!SetUpText.instance.gameHasEnded)
        {
            yield return new WaitForSeconds(0.2f);
        }
        yield return new WaitForSeconds(3f);
        rend.material = SetUpText.instance.myBlackMaterial;
    }



    public int RandomWallColor()
    {
        int random = Random.Range(0,3);
        return random;

    }
}
