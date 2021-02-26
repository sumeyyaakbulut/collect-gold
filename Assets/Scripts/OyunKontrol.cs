using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyunKontrol : MonoBehaviour
{
    public UnityEngine.UI.Button btn;
    public UnityEngine.UI.Text durum;
    public bool oyunAktif = true;
    public int altinSayisi = 0;
    public UnityEngine.UI.Text altinSayisiText;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource> ().Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AltinArttır()
    {
        altinSayisi += 1;
        altinSayisiText.text = "" + altinSayisi;
        if (altinSayisi==6)
        {
            durum.text = "Oyunu Kazandınız TEBRİKLER";
            btn.gameObject.SetActive(true);
            oyunAktif = false;
        }
    }
}
