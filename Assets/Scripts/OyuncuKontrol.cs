using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyuncuKontrol : MonoBehaviour
{
    public UnityEngine.UI.Button btn;
    public UnityEngine.UI.Text durum;
    public AudioClip AltınSes, DusmeSes;
    public OyunKontrol oyunK;
    private float hiz = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (oyunK.oyunAktif)// oyun devam ediyorsa tuslar ile haraeket edebilirsin
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");
            x *= Time.deltaTime * hiz;
            y *= Time.deltaTime * hiz;
            transform.Translate(x, 0f, y);//cismin hareket yonu yukarı dogru olmaz o yuzden y eksenini 0 z eksınını de y eksenı yaparız
        }
    }
    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag.Equals("altin"))//altın topladığında her toplamanad puan kazan
        {
            GetComponent <AudioSource>().PlayOneShot(AltınSes, 1f);//seslerden altın sesine cal valımu de 0 ile 1 arasında gırmesını soyler
            oyunK.AltinArttır();
            Destroy(c.gameObject);
        }
        else if (c.gameObject.tag.Equals("dusman"))// tag dusman ise oyuna devam edemez 
        {
            GetComponent<AudioSource>().PlayOneShot(DusmeSes, 1f);
            oyunK.oyunAktif = false;
            durum.text = "Oyunu Kaybettiniz";
            btn.gameObject.SetActive(true);

        }
    }
}
