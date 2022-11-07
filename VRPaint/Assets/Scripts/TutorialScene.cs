using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialScene : MonoBehaviour
{
    bool startButton = false;
    AudioSource speaker;
    public Animator canvasAnim;
    public GameObject text;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        speaker = GetComponent<AudioSource>();
        yield return new WaitForSeconds(0.5f);
        speaker.Play();
        yield return new WaitForSeconds(3f);
        text.SetActive(true);
        startButton = true;
    }

    private void Update()
    {
        if (startButton = true && OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            StartCoroutine("FadeAway");
        }
    }

    public IEnumerator FadeAway()
    {
        canvasAnim.SetBool("startOverlayTutorial", true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(2);
    }
}
