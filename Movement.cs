using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Movement : MonoBehaviour
{
    [Header("Default Charecter Mat")]
    public Material charecterMat;

    [Header("Panel")]
    public GameObject pnlStart;

    [Header("Animation's")]
    public Animator player;
    public Animator animator;
    public Animator bonusAnim;
    public Animator bonusAnim2;

    [Header("Trigger Object's Color")]
    public Color objectColor;
    public GameObject[] bodyElements;
    public Color[] bodyColor;

    [Header("Script's")]
    public Fallow fallowScript;
    public Particle particleScript;
    public Touchs touchsScript;

    [Header("Other's")]
    public Text finalTxt;
    public ParticleSystem endParticle;
    public int y = 0;
    public int bodyInt;
    public int successRate = 0;   
    public Rigidbody rigid;
    public GameObject twoSidedArrow;
    bool startAction;

    void Start()
    {
        //Application.targetFrameRate = 60;
        //FPS'e limit koyma (Ekran kartýmýn Mhz'si yüksek olmasýn diye)
        rigid = GetComponent<Rigidbody>();
        //Rigidbody component'ini buluyoruz
        //Time.timeScale = 0;

        charecterMat.color = Color.black;
        charecterMat.color = new Color(charecterMat.color.r, charecterMat.color.g, charecterMat.color.b, 0.3f);
        charecterMat.SetFloat("_Metallic", 0);
        //Karakterin bölmelerindeki materyallere bazý iþlemler gerçekleþtiriyoruz
        touchsScript.enabled = false;
        StartCoroutine(ColorsShow());
        bodyInt = 0;
    }
    void Update()
    {
        if (Input.touchCount > 0)
        {
            startAction = true;
            pnlStart.SetActive(false);
            touchsScript.enabled = true;
        }

        if (startAction == true)
        {
            transform.Translate(Vector3.forward * 6 * Time.deltaTime);

            if (Input.GetKey("a"))
            {
                transform.Translate(Vector3.left * 6 * Time.deltaTime);
            }
            if (Input.GetKey("d"))
            {
                transform.Translate(Vector3.right * 6 * Time.deltaTime);
            }

            if (transform.position.x > 4.04f)
                transform.position = new Vector3(4.04f, transform.position.y, transform.position.z);
            if (transform.position.x < -4.04f)
                transform.position = new Vector3(-4.04f, transform.position.y, transform.position.z);
            //Karakterin maximum x poziyonlarýný belirliyoruz. Zeminin sýnýrýndan çýkamasýn diye.

            player.SetFloat("go", 0.5f);
            twoSidedArrow.SetActive(false);
        }
        //Karakterin hareket sistemi(Bilgisayar kontrolleri)
    }
    public void press()
    {
        for (int i = 0; i <= 5; i++)
        {
            if (bodyColor[i] == bodyElements[i].GetComponent<SkinnedMeshRenderer>().material.color)
            {
                successRate += 16;
            }
        }
        finalTxt.text = "Succes Rate % " + (successRate+4);
        //Bu fonksiyonda baþarý oranýný hesaplayýp yazdýrýyoruz.
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "end")
        {
            StartCoroutine(EndTriggerNumerator());

            press();

            Destroy(fallowScript);
            Invoke("SetCamAnim", .7f);
            endParticle.Play();
            touchsScript.enabled = false;
        }
        if (other.gameObject.tag != "obstacle")
        {
            Color objec = other.GetComponent<MeshRenderer>().material.color;
            objectColor = other.GetComponent<MeshRenderer>().material.color;

            particleScript.enabled = true;
            particleScript.SendMessage("push", objec);

            bodyElements[bodyInt].GetComponent<SkinnedMeshRenderer>().material.color = objectColor;
            bodyInt++;
            Destroy(other.gameObject);

            if (bodyColor[y] == bodyElements[y].GetComponent<SkinnedMeshRenderer>().material.color)
            {
                bonusAnim.SetTrigger("true");
                y++;
            }
            else
            {
                bonusAnim2.SetTrigger("false");
                y++;
            }
        }
        /*if (other.gameObject.tag == "obstacle")
        {
            print("sa");
            bodyElements[bodyInt - 1].GetComponent<SkinnedMeshRenderer>().material.color = charecterMat.color;
            bodyInt--;
            successRate -= 1;
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
        }*/

        //Fizik iþlemleri
    }
    public void SetCamAnim()
    {
        animator.SetTrigger("cam");
    }
    public void StartButton()
    {
        Time.timeScale = 1;
        pnlStart.SetActive(false);
        touchsScript.enabled = true;
        twoSidedArrow.SetActive(true);
    }
    public IEnumerator EndTriggerNumerator()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(0);
    }
    public IEnumerator ColorsShow()
    {
        yield return new WaitForSeconds(4f);
        pnlStart.SetActive(false);
        touchsScript.enabled = true;
        startAction = true;
    }
}
