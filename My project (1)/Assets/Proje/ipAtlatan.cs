using System.Diagnostics;
using UnityEngine;

public class IpAtlatan : MonoBehaviour
{
    public Animator animator;  // Animator bileþeni
    private bool isIdle = true; // Idle durumunda mý?

    // Start is called before the first frame update
    void Start()
    {
        // Animator bileþenini al
        animator = GetComponent<Animator>();

        // Animasyonu baþlat
        StartIdleAnimation();
    }

    // Update is called once per frame
    void Update()
    {
        // Eðer idle durumdaysa animasyonu kontrol et
        if (isIdle)
        {
            // Idle animasyonunu oynat
            animator.SetBool("isIdle", true);
        }
        else
        {
            // Idle dýþý bir animasyon durumu varsa, isIdle parametresini false yap
            animator.SetBool("isIdle", false);
        }
    }

    // Idle animasyonunu baþlatan fonksiyon
    void StartIdleAnimation()
    {
        // Baþlangýçta idle animasyonunu oynatmak için isIdle'i true yapýyoruz
        isIdle = true;
    }

    // Idle animasyonunu bitirdikten sonra çalýþacak bir fonksiyon
    public void OnIdleAnimationFinished()
    {
        // Idle animasyonu bittiðinde yapýlacak iþlemler
        // Örneðin: baþka bir animasyonu baþlatabiliriz
        
    }
}
