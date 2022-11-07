using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastItemsOutline : MonoBehaviour
{
   // public Renderer[] allrenderer;
    public Material myWhiteMaterial;
    public GameObject[] allGameObjects;
   
    // Start is called before the first frame update
    void Start()
    {
        //var outline = gameObject.AddComponent<Outline>();

    }
    //int count;
    //public IEnumerator Flash()
    //{
    //    float t = 0;

    //    while (t < 1)
    //    {
    //        t += Time.deltaTime;
    //        Color tempColor = Color.Lerp(myWhite, Color.black, t);
    //        yield return null;


    //        if (rend.Length > 0)
    //        {
    //            foreach (Renderer r in rend)
    //            {
    //                r.material.SetColor("_EmissionColor", tempColor);

    //            }

    //        }
    //        else
    //        {
    //            myRend.material.SetColor("_EmissionColor", tempColor);
    //        }

    //    }
    //}

    //public IEnumerator LastItems()
    //{
    //    yield return null;
    //    while(SetUpText.instance.numOfItems < 115)
    //    {
    //        yield return new WaitForSeconds(0.2f);
    //    }

    //    foreach(GameObject gameObj in allGameObjects)
    //    {
    //       if(gameObj.GetComponent<Renderer>().material == myWhiteMaterial)
    //        {
    //            var outline = gameObj.AddComponent<Outline>();
    //            outline.OutlineMode = Outline.Mode.OutlineAll;
    //            outline.OutlineColor = Color.yellow;
    //            outline.OutlineWidth = 5f;
    //        }
    //        else
    //        {
    //            yield return new WaitForSeconds(0.2f);
    //        }
    //    }

    //}

    // Update is called once per frame
    void Update()
    {
        
    }
}
