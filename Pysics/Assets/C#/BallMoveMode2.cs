using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class BallMoveMode2 : MonoBehaviour
{

    public float AN = 2f;
    public float BN = 2f;
    public bool isStop = false;
    public Rigidbody rigibody;
    public Text showtext;
    public GameObject b;
    public Rigidbody rb;
    public float pAM;
    public UIcontroal1 uIcontroal;
    private bool isStart;
    public float massA;
    public float totalspeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = b.GetComponent<Rigidbody>();
        //rigibody.AddForce(new Vector3(N,0,0), ForceMode.VelocityChange);
    }

    // Update is called once per frame
    void Update()
    {
        rigibody.mass = uIcontroal.sliderAM.value;
        rb.mass = uIcontroal.sliderBM.value;
        AN = uIcontroal.sliderSpeedA.value;
        BN = uIcontroal.sliderSpeedB.value;
        isStart = uIcontroal.isStart;
        if (isStart) {
            if (!isStop) {
                rigibody.AddForce(new Vector3(AN,0,0));
            } else {
                //rigibody.velocity = new Vector3(0,0,0);
            }
        } else {
            isStop = false;
            rigibody.velocity = new Vector3(0, 0, 0);
            rb.velocity = new Vector3(0,0,0);
            this.transform.position = new Vector3(-169.89f, 0.5f, 0);
            b.transform.position = new Vector3(0, 0.5f, 0);
            rb.GetComponent<Collider>().isTrigger = true;
            pAM = 0;
        }
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append("물체 A 속도: " +  rigibody.velocity.magnitude + "m/s\n");
        stringBuilder.Append("물체 A 질량: " +  rigibody.mass + "kg\n");
        stringBuilder.Append("물체 A 운동량 : " + rigibody.velocity.magnitude * rigibody.mass + "kg·m/s\n");
        stringBuilder.Append("물체 B 속도: " +  rb.velocity.magnitude + "m/s\n");
        stringBuilder.Append("물체 B 질량: " +  rb.mass + "\n");
        stringBuilder.Append("물체 B 운동량 : " +  rb.velocity.magnitude * rb.mass + "kg·m/s\n");
        stringBuilder.Append("물체 A 충돌 순간 운동량 : " + pAM + "kg·m/s\n");
        stringBuilder.Append("총 운동량 : " + pAM + "kg·m/s\n");
        showtext.text = stringBuilder.ToString();
    }

    void OnTriggerEnter(Collider other) 
	{
        pAM = rigibody.velocity.magnitude * rigibody.mass;
        GameObject game = other.gameObject;
		if (game.tag ==  "Finish")
		{
            totalspeed = pAM / (rigibody.mass + rb.mass);
            //float aq = 
            isStop = true;

            Rigidbody i = game.GetComponent<Rigidbody>();

            i.isKinematic = false;
            game.GetComponent<Collider>().isTrigger = false;
            i.velocity = new Vector3(totalspeed, 0, 0);
            rigibody.velocity = new Vector3(totalspeed, 0, 0);
            AN = 0;

            //rigibody.velocity = new Vector3(0,0,0);
        }
    }
}
