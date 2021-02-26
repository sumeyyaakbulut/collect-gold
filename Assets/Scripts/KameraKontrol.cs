using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraKontrol : MonoBehaviour
{
    
    public OyunKontrol oyunK;
    float hassasiyet = 5f;
    float yumusaklık = 2f;
    bool oyunTamam= true;
    // Start is called before the first frame update
    Vector2 gecPos;
    Vector2 camPos;
    GameObject oyuncu;
    void Start()
    {
        oyuncu = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (oyunK.oyunAktif)
        {
            Vector2 farePos = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
            farePos = Vector2.Scale(farePos, new Vector2(hassasiyet * yumusaklık, hassasiyet * yumusaklık));
            gecPos.x = Mathf.Lerp(gecPos.x, farePos.x, 1f / yumusaklık);//belirli bir sure icerisinde belirli noktadan baska noktaya gecmesi saglanmaktadır
                                                                        //daha gercekcı bır goruntu elde edilmeye calısılır gercek x konumundan fare pos gecmesi ve belirli bir sure de gerceklestırmek
            gecPos.y = Mathf.Lerp(gecPos.y, farePos.y, 1f / yumusaklık);
            camPos += gecPos;
            transform.localRotation = Quaternion.AngleAxis(-camPos.y, Vector3.right);//kameramızı yukarı asagı dogru hareket ettırdıgımız zaman fareden aldıgımız y degerine gore alarak kamerayı yukarı asagı cevirmemizi saglar
                                                                                     //- koymamızın sebebi faremiz yukaraı kaldırdıgımız zaman yukarı kalksın asagı ındırdıgımız zaman da asagı gıtsın
            oyuncu.transform.localRotation = Quaternion.AngleAxis(camPos.x, oyuncu.transform.up);//oyuncumuzu saga sola cevirmek ıcın
        }
        
    }
    
}
