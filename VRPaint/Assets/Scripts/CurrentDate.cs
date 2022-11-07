using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrentDate : MonoBehaviour
{
    string month;
    string day;
    public TMP_Text dayText;
    public TMP_Text monthText;
    // Start is called before the first frame update
    void Start()
    {
        month = System.DateTime.Now.ToString("MMMM");
        day = System.DateTime.Now.ToString("dd");
        dayText.text = "";
        monthText.text = "";
        StartCoroutine(StartingMyCurrentDate());
    }

    public IEnumerator StartingMyCurrentDate()
    {
        while (!SetUpText.instance.gameCanStart)
        {
            yield return new WaitForSeconds(0.2f);
        }
        yield return new WaitForSeconds(2f);
        dayText.text = day.ToString();
        monthText.text = month.ToString();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (SetUpText.instance.gameHasEnded)
        {
            StartCoroutine(DelayToMakeTextDark());
        }
    }

    public IEnumerator DelayToMakeTextDark()
    {
        yield return new WaitForSeconds(1f);
        dayText.text = "";
        monthText.text = "";
    }
}
