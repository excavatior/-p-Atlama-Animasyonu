using System.Diagnostics;
using UnityEngine;

public class IpAtlatan : MonoBehaviour
{
    public Animator animator;  // Animator bile�eni
    private bool isIdle = true; // Idle durumunda m�?

    // Start is called before the first frame update
    void Start()
    {
        // Animator bile�enini al
        animator = GetComponent<Animator>();

        // Animasyonu ba�lat
        StartIdleAnimation();
    }

    // Update is called once per frame
    void Update()
    {
        // E�er idle durumdaysa animasyonu kontrol et
        if (isIdle)
        {
            // Idle animasyonunu oynat
            animator.SetBool("isIdle", true);
        }
        else
        {
            // Idle d��� bir animasyon durumu varsa, isIdle parametresini false yap
            animator.SetBool("isIdle", false);
        }
    }

    // Idle animasyonunu ba�latan fonksiyon
    void StartIdleAnimation()
    {
        // Ba�lang��ta idle animasyonunu oynatmak i�in isIdle'i true yap�yoruz
        isIdle = true;
    }

    // Idle animasyonunu bitirdikten sonra �al��acak bir fonksiyon
    public void OnIdleAnimationFinished()
    {
        // Idle animasyonu bitti�inde yap�lacak i�lemler
        // �rne�in: ba�ka bir animasyonu ba�latabiliriz
        
    }
}
