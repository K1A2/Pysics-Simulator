using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class BallMoveMode1 : MonoBehaviour
{

    public float N = 2f;
    public bool isStop = false;
    public Rigidbody rigibody;
    public Text showtext;
    public GameObject b;
    public Rigidbody rb;
    public float pAM;
    public UIcontroal uIcontroal;
    private bool isStart;
    public float massA;

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
        N = uIcontroal.sliderSpeed.value;
        isStart = uIcontroal.isStart;
        if (isStart) {
            if (!isStop) {
                rigibody.AddForce(new Vector3(N,0,0));
            } else {
                rigibody.velocity = new Vector3(0,0,0);
            }
        } else {
            isStop = false;
            this.transform.position = new Vector3(-169.89f, 0.5f, 0);
            b.transform.position = new Vector3(0, 0.5f, 0);
            rigibody.isKinematic = false;
            rb.isKinematic = true;
            rb.GetComponent<Collider>().isTrigger = true;
        }
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append("물체 A 속도: " +  rigibody.velocity.magnitude + "m/s\n");
        stringBuilder.Append("물체 A 질량: " +  rigibody.mass + "kg\n");
        stringBuilder.Append("물체 A 운동량 : " + rigibody.velocity.magnitude * rigibody.mass + "kg·m/s\n");
        stringBuilder.Append("물체 B 속도: " +  rb.velocity.magnitude + "m/s\n");
        stringBuilder.Append("물체 B 질량: " +  rb.mass + "\n");
        stringBuilder.Append("물체 B 운동량 : " +  rb.velocity.magnitude * rb.mass + "kg·m/s\n");
        stringBuilder.Append("물체 A 충돌 순간 운동량 : " + pAM + "kg·m/s\n");
        showtext.text = stringBuilder.ToString();
    }

    void OnTriggerEnter(Collider other) 
	{
        pAM = rigibody.velocity.magnitude * rigibody.mass;
        GameObject game = other.gameObject;
		if (game.tag ==  "Finish")
		{
            //float aq = 
            isStop = true;

            Rigidbody i = game.GetComponent<Rigidbody>();

            rigibody.isKinematic = true;
            i.isKinematic = false;
            game.GetComponent<Collider>().isTrigger = false;
            i.velocity = new Vector3(pAM / rb.mass, 0, 0);
            N = 0;

            //rigibody.velocity = new Vector3(0,0,0);
        }
    }
}
