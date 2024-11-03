using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadialButtonDisplay : MonoBehaviour
{
    public GameObject parentPanel;
    public GameObject buttonPrefab;
    public GameObject centerPoint;
    public Vector2 panelCenter;
    public GameObject[] buttons;
    public float radius => GetComponent<RectTransform>().rect.width/3.5f;
    public float spawnAngle;



    public int totalButtons;
    
    // Start is called before the first frame update
    void Start()
    {
        parentPanel = gameObject;
        panelCenter = centerPoint.transform.position;
        buttons = new GameObject[totalButtons];
            
        for (int i = 0; i < totalButtons; i++)
        {
            GameObject currentButton = Instantiate(buttonPrefab, parentPanel.transform);
            currentButton.GetComponentInChildren<Text>().text = Key.CircleOfFifths[i];
            currentButton.GetComponent<ButtonClickScript>().buttonID = i;
            spawnAngle = ((360f / totalButtons) * i + 180f/totalButtons) * Mathf.Deg2Rad;
            Vector2 spawnVector = new Vector2(Mathf.Sin(spawnAngle), Mathf.Cos(spawnAngle)) * radius;
            currentButton.transform.position = panelCenter + spawnVector;
            
            buttons[i] = currentButton;
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
