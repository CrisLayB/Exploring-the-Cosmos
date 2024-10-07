using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject[] Panels;
    private RectTransform current;

    private int index;

    // Positions for animation
    private Vector2 bottomPosition = new Vector2(0, -Screen.height); // Bottom (offscreen)
    private Vector2 middlePosition = new Vector2(0, 0);              // Middle (onscreen)
    private Vector2 topPosition = new Vector2(0, Screen.height);      // Top (offscreen)

    void Start()
    {
        foreach (GameObject panel in Panels) {
            panel.SetActive(false);
        }

        StartCoroutine(RollCredits());
    }

    public IEnumerator RollCredits() {
        while(true) {
            

            ChangePanel(index);
            current = Panels[index].GetComponent<RectTransform>();

            // Start panel at bottom position
            current.anchoredPosition = bottomPosition;
            // Animate from bottom to middle
            current.LeanMoveLocal(middlePosition, 1f).setEase(LeanTweenType.easeInCubic);


            yield return new WaitForSeconds(6f);

            current.LeanMoveLocal(topPosition, 1f).setEase(LeanTweenType.easeOutCubic);
            yield return new WaitForSeconds(1f);

            index = (index + 1) % Panels.Length;
        }
    }

    private void ChangePanel(int i) {
        for (int j = 0; j < Panels.Length; j ++) {
            if (j == i) {
                Panels[j].SetActive(true);
            } else {
                Panels[j].SetActive(false);
            }
        }
    }
}
