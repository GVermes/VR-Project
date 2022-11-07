using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfActivated : MonoBehaviour
{
    int count;
    public Renderer[] rend;
    public Color c;
    
    public bool changeBallColor;
    Renderer myRend;
    public bool useSpecialWhite;
    public Color specialWhite;
    public bool canPlaySound;
    public Material specialMaterial;

    public static bool flasher;

    // Start is called before the first frame update
    void Start()
    {
        canPlaySound = true;
        count = 0;
        StartCoroutine(StartEndGame());

        //getting list of all items in the work - not collided yet at the start
        SetUpText.instance.notYetCollided.Add(gameObject);

        //geting list of animators in the room
        if (gameObject.GetComponent<Animator>())
        {
            SetUpText.instance.allObjectsAnimator.Add(gameObject.GetComponent<Animator>());
        }
        if (gameObject.GetComponentInParent<Animator>())
        {
            SetUpText.instance.allObjectsAnimator.Add(gameObject.GetComponentInParent<Animator>());
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if (SetUpText.instance.gameCanStart)
        {
            if (collision.gameObject.CompareTag("Ball") || (collision.gameObject.CompareTag("RBall")))
            {
                if (count == 0)
                {

                    //changing ball color
                    if (changeBallColor)
                    {
                        collision.gameObject.SendMessage("ChangeColor", c);
                    }
                   
                    Activate();

                }
                else
                {
                    StartCoroutine(Flash());
                }
                count++;
            }
        }

    }
   // flashing, getting collided items and so on
    void Activate()
    {
        if (SetUpText.instance.canStartColoring == true)
        {
            SetUpText.instance.notYetCollided.Remove(gameObject);
            if (!SetUpText.instance.gameHasEnded)
            {
                StartCoroutine(SetUpText.instance.SetScore_Animation());
            }


            if (specialMaterial != null)
            {
                // FOR DIFFERENT MATERIALS WITH CHILDREN
                if (rend.Length > 0)
                {
                    foreach (Renderer rendChild in rend)
                    {
                        //sticky.gameObject.GetComponent<Renderer>().material = roomMaterial;
                        rendChild.material = specialMaterial;
                        rendChild.material.EnableKeyword("_EMISSION");
                        SetUpText.instance.allItemsGameObject.Add(rendChild);
                    }
                }
                else // DIFFERENT MATERIALS FOR INDIVIDUALS
                {
                    myRend = GetComponent<Renderer>();
                    myRend.material = specialMaterial;
                    myRend.material.EnableKeyword("_EMISSION");
                    SetUpText.instance.allItemsGameObject.Add(myRend);
                }
            }

            // ORIGINAL TEXTURE ROOM MATERIAL WITH CHILDREN
            else if (rend.Length > 0)
            {
                foreach (Renderer rendChild in rend)
                {
                    //sticky.gameObject.GetComponent<Renderer>().material = roomMaterial;
                    rendChild.material = SetUpText.instance.roomMaterial;
                    rendChild.material.EnableKeyword("_EMISSION");
                    SetUpText.instance.allItemsGameObject.Add(rendChild);
                }
            }
            else // INDIVIDUAL OBJECTS
            {
                myRend = GetComponent<Renderer>();
                myRend.material = SetUpText.instance.roomMaterial;
                myRend.material.EnableKeyword("_EMISSION");
                SetUpText.instance.allItemsGameObject.Add(myRend);
            }
           // activated = true;
            StartCoroutine(Flash());

        }
      
    }

    public IEnumerator Flash()
    {        
        float t = 0f;
        Color myWhite = count >=1 ? SetUpText.instance.lowWhite : SetUpText.instance.goodWhite;
        //SPECIAL LOWER WHITE
        if (count >= 1 && useSpecialWhite) myWhite = specialWhite;

        while (t < 1)
        {
            t += Time.deltaTime;
            Color tempColor = Color.Lerp(myWhite, Color.black, t);
            yield return null;


            if (rend.Length > 0)
            {
                foreach (Renderer r in rend)
                {
                    r.material.SetColor("_EmissionColor", tempColor);

                }

            }
            else
            {
                myRend.material.SetColor("_EmissionColor", tempColor);
            }
         
        }
    }

    
    public Color selectedColor;
    public IEnumerator FlashColorfull()
    {
        float t = 0f;

        if(RandomColor() == 0)
        {
            selectedColor = SetUpText.instance.c0;
        }
        else if (RandomColor() == 1)
        {
            selectedColor = SetUpText.instance.c1;
        }
        else if (RandomColor() == 2)
        {
            selectedColor = SetUpText.instance.c2;
        }
        else if (RandomColor() == 3)
        {
            selectedColor = SetUpText.instance.c3;
        }
        else if (RandomColor() == 4)
        {
            selectedColor = SetUpText.instance.c4;
        }
        else if (RandomColor() == 5)
        {
            selectedColor = SetUpText.instance.c5;
        }

        while (t < 1)
        {
            t += Time.deltaTime;
            Color tempColor = Color.Lerp(SetUpText.instance.whiteForTheEndColor, selectedColor, t);
            yield return null;


            if (rend.Length > 0)
            {
                foreach (Renderer r in rend)
                {
                    r.material.SetColor("_EmissionColor", tempColor);

                }

            }
            else
            {
                myRend.material.SetColor("_EmissionColor", tempColor);
            }

        }
    }

    public int RandomColor()
    {
        int random = Random.Range(0, 5);
        return random;
    }


    
    public IEnumerator StartEndGame()
    {
        while (!SetUpText.instance.gameHasEnded)
        {
            yield return new WaitForSeconds(0.2f);
        }
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(EveryItemFlashColorsEndScene());
    }

    
    public IEnumerator EveryItemFlashColorsEndScene()
    {
        for (int i = 0; i < SetUpText.instance.allItemsGameObject.Count; i++)
        {
            RandomColor();
            yield return new WaitForSeconds(RandomNum());
            if (flasher)
            {
                SetUpText.instance.flashingSpeaker.pitch = Random.Range(0.75f, 1.4f);
                SetUpText.instance.flashingSpeaker.PlayOneShot(SetUpText.instance.flashingWallClip, 1);
                flasher = !flasher;
                SetUpText.instance.flashingSpeaker.volume -= 0.04f;
                
            }
           
            StartCoroutine(FlashColorfull());
        }
    }

    public float RandomNum()
    {
        float random = Random.Range(0f, 1f);
        return random;
    }


    // FOR ENDING SCENE - making walls, ceiling and floor DARK
    public IEnumerator LerpColor()
    {

        if (specialMaterial != null)
        {
            // FOR DIFFERENT MATERIALS WITH CHILDREN
            if (rend.Length > 0)
            {
                foreach (Renderer rendChild in rend)
                {
                   // rendChild.material = SetUpText.instance.darkerMaterial;
                    if (gameObject.CompareTag("Walls"))
                    {
                        float t = 0f;
                        while (t < 1)
                        {
                            t += Time.deltaTime;
                            rendChild.material.color = Color.Lerp(rendChild.material.color, SetUpText.instance.darkOrange.color, t);
                            yield return null;
                        }
                        rendChild.material = SetUpText.instance.darkOrange;
                    }

                }
            }// DIFFERENT MATERIALS FOR INDIVIDUALS
            else if (gameObject.CompareTag("Walls"))
            {
                float t = 0f;
                while (t < 1)
                {
                    t += Time.deltaTime;
                    myRend.material.color = Color.Lerp(myRend.material.color, SetUpText.instance.darkOrange.color, t);
                    yield return null;
                }
               
                myRend.material = SetUpText.instance.darkOrange;
            }else if (gameObject.CompareTag("Ceiling"))
            {
                float t = 0f;
                while (t < 1)
                {
                    t += Time.deltaTime;
                    myRend.material.color = Color.Lerp(myRend.material.color, SetUpText.instance.darkYellow.color, t);
                    yield return null;
                }
                myRend.material = SetUpText.instance.darkYellow;
            }else if (gameObject.CompareTag("Floor"))
            {
                float t = 0f;
                while (t < 1)
                {
                    t += Time.deltaTime;
                    myRend.material.color = Color.Lerp(myRend.material.color, SetUpText.instance.darkYellow.color, t);
                    yield return null;
                }
                myRend.material = SetUpText.instance.darkYellow;
            }

        }

    }

    public IEnumerator SoundsCD()
    {
        canPlaySound = false;
        yield return new WaitForSeconds(10f);
        canPlaySound = true;
    }



}
