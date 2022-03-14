using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusManager : MonoBehaviour {

    public int Anger = 0;
    public int Point = 0;
    public Text PointText;
    public Text PointPopupText;
    private float pointInterval = 100f;
    private float pointTimeCount = 0;
    public PlayerCarController PlayerCarController;
    public Image AngerGagePanel;
    public AudioSource ImpactAudio;
    public AudioSource ImpactPropsAudio;
    public AudioSource GetPointAudio;

    private float SlowTime=-1;
    private float FastLv1Time=-1;

	// Use this for initialization
	void Start () {
        AngerGagePanel.fillAmount = 0;
	}
	
	// Update is called once per frame
	void Update () {
        pointTimeCount += Time.deltaTime;
        if (pointTimeCount > pointInterval / PlayerCarController.Speed) {
            Point += PlayerCarController.Speed;
            PointText.text = Point.ToString();
            PointPopupText.text = PlayerCarController.Speed.ToString();
            PointPopupText.gameObject.SetActive(true);
            GetPointAudio.Play();
            pointTimeCount = 0;
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            ImpactAudio.Play();
            ChangeAngerGage(10);
            collision.gameObject.tag = "BrokenEnemy";
        }
        else if (collision.gameObject.tag == "Props" && collision.rigidbody.velocity.magnitude>0.1f) {
            ImpactPropsAudio.Play();
            ChangeAngerGage(4);
            collision.gameObject.tag = "BrokenProps";
        }
    }

    public void ChangeAngerGage(int val) {
        Anger += val;
        if (Anger < 0) {
            Anger = 0;
        }
        AngerGagePanel.fillAmount = Anger / 100.0f;
    }
}
