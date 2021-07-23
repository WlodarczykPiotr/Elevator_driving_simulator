using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomatyczneDzwi : MonoBehaviour
{
    [SerializeField]
    private GameObject fotokomorka, drzwiLewe, drzwiPrawe;

    [SerializeField]
    private static Animator leweDrzwi, praweDrzwi;
    
    private AudioSource dzwiekDrzwiWindy;
    
    // Start is called before the first frame update
    private void Start()
    {
        leweDrzwi = drzwiLewe.GetComponent<Animator>();
        praweDrzwi = drzwiPrawe.GetComponent<Animator>();
        dzwiekDrzwiWindy = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter (Collider kolizja)
    {
        if (kolizja.gameObject.tag == "gracz")
        {
            CzyOtworzycDrzwi(true);
            dzwiekDrzwiWindy.Play();
        }
    }

    private void OnTriggerExit(Collider kolizja)
    {
        if (kolizja.gameObject.tag == "gracz")
        {
            CzyOtworzycDrzwi(false);
            dzwiekDrzwiWindy.Play();
        }
    }

    public static void CzyOtworzycDrzwi (bool czyOtwarte)
    {
        leweDrzwi.SetBool("czyOtworzyc", czyOtwarte);
        praweDrzwi.SetBool("czyOtworzyc", czyOtwarte);
    }
}
