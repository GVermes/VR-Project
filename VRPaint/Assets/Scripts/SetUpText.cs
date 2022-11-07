using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class SetUpText : MonoBehaviour
{

    // GM SCRIPT

    public Color goodWhite;
    public Color lowWhite;
    public Color darkColorRoom;
    public static SetUpText instance;
    public Material roomMaterial,darkerMaterial,darkRed,darkYellow,darkOrange,darkGreen,darkBabyGreen,darkBrownGreen,darkLightBrown,darkWindowCurtain,darkGray,darkNitendo,darkPlantPot,darkBlue,darkGrey,darkBrown;
    public bool gameHasEnded;
    public GameObject finalShow;
    public Animator anim;
    public bool gameCanStart;
    public bool canStartColoring;
    public bool clockCanStart;

    public Material defaultWhite;
    public Material defaultLight;
    public Material grayLight;

    public List<GameObject> notYetCollided = new List<GameObject>();
    public List<Renderer> allItemsGameObject = new List<Renderer>();
    public List<Animator> allObjectsAnimator = new List<Animator>();
    public Material arcade, cat, invader, man, robot1, robot2;
    public AudioSource youWinSpeaker;
    public AudioSource shutdownSpeaker;
    public AudioSource speaker;
    public AudioSource flashingSpeaker;
    public AudioSource fireworkStarSpeaker;

    public AudioClip tenToGoClip;
    public AudioClip fiveToGoClip;
    public AudioClip oneToGoClip;
    public AudioClip fourClip;
    public AudioClip threeClip;
    public AudioClip twoClip;
    public AudioClip flashingWallClip;
    public AudioClip fireworkStartSoundClip;

    public AudioSource raspberrySource;
    public Color c0, c1, c2, c3, c4, c5;
    public Color whiteForTheEndColor;

    public GameObject fireworkObject;

    public Animator endingAnim;
    

    private void Awake()
    {
        instance = this;
    }

    public TMP_Text itemsText;

    public int numOfItems;
    // Start is called before the first frame update
    void Start()
    {
        eachBlackSource.pitch = 1.2f;
        fireworkStarSpeaker.pitch = 0.8f;
        flashingSpeaker.volume = 1f;
        winText.SetActive(false);
        clockCanStart = false;
        canStartColoring = false;
       
        defaultWhite.color = Color.black;
        gameCanStart = false;
        numOfItems = 0;
        gameHasEnded = false;
        darkerMaterial.color = Color.white;
        AllDarkLightsDeactivated();
        StartCoroutine(Tracking());
    }
    void Update()
    {
        SetUpCountText();
    }

    public void AllDarkLightsDeactivated()
    {
        mainLightDark.SetActive(false);
        bedLightDark.SetActive(false);
        outsideLightLeftLightDark.SetActive(false);
        outsideRightLightDark.SetActive(false);
        darkScreenTv.SetActive(false);
        darkScreenArcade.SetActive(false);
    }

    
    public IEnumerator Tracking()
    {
        int count10 = 0;
        int count5 = 0;
        int count1 = 0;
        int count4 = 0;
        int count3 = 0;
        int count2 = 0;
        while (numOfItems < 120)
        {
            yield return new WaitForSeconds(0.2f);

            if(numOfItems == 110)
            {
                if (count10 < 1)
                {
                    speaker.PlayOneShot(tenToGoClip, 1);
                    count10++;
                }
                
            }

            if(numOfItems == 115)
            {
                if (count5 < 1)
                {
                    speaker.PlayOneShot(fiveToGoClip, 1);
                    count5++;
                }
            }
            if (numOfItems == 116)
            {
                if (count4 < 1)
                {
                    speaker.PlayOneShot(fourClip, 1);
                    count4++;
                }
            }
            if (numOfItems == 117)
            {
                if (count3 < 1)
                {
                    speaker.PlayOneShot(threeClip, 1);
                    count3++;
                }
            }
            if (numOfItems == 118)
            {
                if (count2 < 1)
                {
                    speaker.PlayOneShot(twoClip, 1);
                    count2++;
                }
            }


            if (numOfItems == 119)
            {
                if (count1 < 1)
                {
                    speaker.PlayOneShot(oneToGoClip, 1);
                    count1++;
                }
            }
        }
        AnimationListFalse();
        finalShow.SetActive(true);
       
    }
    //turning all animations false
    public void AnimationListFalse()
    {
        for(int i = 0; i < allObjectsAnimator.Count; i++)
        {
            allObjectsAnimator[i].SetBool("colliding", false);
        }
    }
    //turning all animations true
    public void AnimationListTrue()
    {
        for (int i = 0; i < allObjectsAnimator.Count; i++)
        {
            allObjectsAnimator[i].SetBool("colliding", true);
        }
    }
    public Material myBlackMaterial;
    public GameObject mainLightDark, bedLightDark, outsideLightLeftLightDark, outsideRightLightDark,darkScreenTv,darkScreenArcade;
    public AudioSource eachBlackSource;
    public AudioClip eachBlackClip;
    public static int shutdownCount =  0;
    public IEnumerator MakeAllMaterialsBlack()
    {
        bgEndMusicSpeaker.Pause();
        shutdownSpeaker.Play();
        for (int i = 0; i< allItemsGameObject.Count; i++)
        {
 
            yield return null;
            
            allItemsGameObject[i].material = myBlackMaterial;

            if (shutdownCount == 0)
            {
                eachBlackSource.pitch -= 0.015f;
                eachBlackSource.PlayOneShot(eachBlackClip,1);
            }
    
            shutdownCount++;
            if (shutdownCount > 7)
            {
                shutdownCount = 0;
            }
            
        }
       
        //final end scene
        StartCoroutine(MakeLightsDarkTrue());
        StartCoroutine(ManageEndSoundMusic());

    }

    public IEnumerator MakeLightsDarkTrue()
    {
        yield return new WaitForSeconds(0.5f);
        OnlyLightsAndScreenTrue();
        yield return new WaitForSeconds(11f);
        endingAnim.SetBool("overlayImage", true);
    }
    

    public void OnlyLightsAndScreenTrue()
    {
        mainLightDark.SetActive(true);
        bedLightDark.SetActive(true);
        outsideLightLeftLightDark.SetActive(true);
        outsideRightLightDark.SetActive(true);
        darkScreenTv.SetActive(true);
        darkScreenArcade.SetActive(true);
    }

    public AudioSource bgEndMusicSpeaker;
    public AudioSource fireworkSpeaker;
    public GameObject winText;


    public IEnumerator ManageEndSoundMusic()
    {
        yield return new WaitForSeconds(12f);
        
        fireworkSpeaker.volume = 0.2f;
        
        bgEndMusicSpeaker.Stop();
        yield return new WaitForSeconds(1f);
        fireworkSpeaker.Stop();
        raspberrySource.Stop();
        fireworkObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        youWinSpeaker.Play();
        winText.SetActive(true);
        //yourTimeText.SetActive(true);
    }

    public float RandomSeconds()
    {
        //0.2 starting
        //end 
        float rand = Random.Range(0, 0.02f);
        return rand;
    }

    public void SetUpCountText()
    {
        if (!gameCanStart)
        {
            itemsText.text = "";
        }
        else
        {
            itemsText.text = numOfItems.ToString() + "/120";
        }
        
    }

    public IEnumerator SetScore_Animation()
    {
        anim.SetBool("score", true);
        numOfItems++;
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("score", false);
    }
}
