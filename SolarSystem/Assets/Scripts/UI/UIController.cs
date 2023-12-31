using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Canvas canvas;

    public List<TargetIndicator> targetIndicators = new List<TargetIndicator>();

    public Camera MainCamera;

    public GameObject TargetIndicatorPrefab;
    public Color color;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (targetIndicators.Count > 0)
        {
            for (int i = 0; i < targetIndicators.Count; i++)
            {
                targetIndicators[i].UpdateTargetIndicator();
            }
        }
    }

    public void AddTargetIndicator(GameObject target)
    {
        TargetIndicator indicator = GameObject.Instantiate(TargetIndicatorPrefab, canvas.transform.GetChild(0)).GetComponent<TargetIndicator>();
        indicator.InitialiseTargetIndicator(target, MainCamera, canvas);
        indicator.OffScreenTargetIndicator.color = color;
        indicator.TargetIndicatorImage.color = color;
        targetIndicators.Add(indicator);
    }
}
