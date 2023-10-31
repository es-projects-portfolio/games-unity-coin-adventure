using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayClosePanel : MonoBehaviour
{
    public GameObject panelClose;
    public GameObject panelOpen1;
    public GameObject panelOpen2;
    public GameObject YesButton;
    public void OnClick()
    {
        YesButton.SetActive(false);
        StartCoroutine(ClosePanelDelayed());
    }

    public IEnumerator ClosePanelDelayed()
    {
        yield return new WaitForSeconds(4f);    // Wait for 5 seconds
        panelClose.SetActive(false);
        panelOpen1.SetActive(true);
        panelOpen2.SetActive(true);
        YesButton.SetActive(true);
    }
}
