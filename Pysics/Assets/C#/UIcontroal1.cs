using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIcontroal1 : MonoBehaviour
{

    public Slider sliderAM;
    public Slider sliderBM;
    public Slider sliderSpeedA;
    public Slider sliderSpeedB;
    public Text textAM;
    public Text textBM;
    public Text textSpeedA;
    public Text textSpeedB;
    public Text textIsStart;
    public Button start;
    public Dropdown dropdown;
    public bool isStart = false;



    // Start is called before the first frame update
    void Start()
    {
        sliderSpeedA.onValueChanged.AddListener (delegate {SpeedValueChangeCheckA ();});
        sliderSpeedB.onValueChanged.AddListener (delegate {SpeedValueChangeCheckB ();});
        sliderAM.onValueChanged.AddListener (delegate {AMassValueChangeCheck ();});
        sliderBM.onValueChanged.AddListener (delegate {BMassValueChangeCheck ();});
        start.onClick.AddListener(delegate {StartOrStop();});
        dropdown.onValueChanged.AddListener(delegate {ScenValueChange ();});
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScenValueChange() {
        switch(dropdown.value) {
            case 1: {
                SceneManager.LoadScene("Mode1");
                break;
            }
        }
    }

    public void SpeedValueChangeCheckA()
	{
		textSpeedA.text = sliderSpeedA.value + "N";
	}

    public void SpeedValueChangeCheckB()
	{
		textSpeedB.text = sliderSpeedB.value + "N";
	}

    public void AMassValueChangeCheck()
	{
		textAM.text = sliderAM.value + "kg";
	}

    public void BMassValueChangeCheck()
	{
		textBM.text = sliderBM.value + "kg";
	}

    public void StartOrStop() {
        if (isStart) {
            isStart = false;
            textIsStart.text = "시작";
        } else {
            isStart = true;
            textIsStart.text = "중지";
        }
    }
}
