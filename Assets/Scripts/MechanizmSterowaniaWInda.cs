using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechanizmSterowaniaWInda : MonoBehaviour
{
    [SerializeField]
    private GameObject winda, przyciskNa1Pietro, przyciskNaParter, przyciskNa2Pietro, przyciskNa3Pietro;

    [SerializeField]
    private bool czyNacisnacPrzycisk = false,
                czyPierwszaJazda = false,
                zParteruNa1 = false,
                zParteruNa2 = false,
                zParteruNa3 = false,
                z1NaParter = false,
                z2NaParter = false,
                z3NaParter = false,
                z1Na2 = false,
                z2Na1 = false,
                z2Na3 = false,
                z1Na3 = false,
                z3Na2 = false,
                z3Na1 = false;
    
    private AudioSource zrodlo;

    private const float o1PietroNizej = 8f, o1PietroWyzej = 10f, o2PietraNizej = 16f, o2PietraWyzej = 20f, o3PietraNizej = 22f, o3PietraWyzej = 24f,
                        czasAwarii = 0.1f, czasAwariio1PietroNizej = 5f, czasAwariio1PietroWyzej = 10f, czasAwariio2PietraNizej = 15f, czasAwariio2PietraWyzej = 20f, czasAwariio3PietraNizej = 20f, czasAwariio3PietraWyzej = 20f;

    [SerializeField]
    private AudioClip dzwiekWindy;

    // Start is called before the first frame update
    private void Start()
    {
        zrodlo = GetComponent<AudioSource>();
    }

    IEnumerator StalaAwaryjna (float czasAwarii)
    {
        czyNacisnacPrzycisk = false;
        AutomatyczneDzwi.CzyOtworzycDrzwi(false);
        zrodlo.PlayOneShot(dzwiekWindy);
        zrodlo.Play();

        yield return new WaitForSeconds(czasAwarii);
    }

    IEnumerator WindaRuszyla(float czas)
    {
        yield return new WaitForSeconds(czas);

        zrodlo.Stop();
        AutomatyczneDzwi.CzyOtworzycDrzwi(true);
        zrodlo.PlayOneShot(dzwiekWindy);
        czyNacisnacPrzycisk = true;

    }

    // Update is called once per frame
    private void Update()
    {
        if (czyNacisnacPrzycisk && Input.GetKey(KeyCode.Alpha1))
        {
            if (!czyPierwszaJazda)
            {
                if (!z1Na2 && !z1Na3)
                {
                    winda.GetComponent<Animator>().SetBool("ZparteruNa1", true);
                    przyciskNa1Pietro.GetComponent<MeshRenderer>().materials[0].EnableKeyword("_EMISSION");

                    Debug.Log("ZparteruNa1");

                    StartCoroutine(StalaAwaryjna(czasAwarii));
                    StartCoroutine(WindaRuszyla(o1PietroWyzej));

                    zParteruNa1 = true;
                    czyPierwszaJazda = true;
                }
            }
            else
            {
                if (z1NaParter && !z1Na2 && !z1Na3)
                {
                    z1NaParter = false;

                    winda.GetComponent<Animator>().SetBool("Z1NaParter", false);
                    przyciskNaParter.GetComponent<MeshRenderer>().materials[0].DisableKeyword("_EMISSION");
                    przyciskNa1Pietro.GetComponent<MeshRenderer>().materials[0].EnableKeyword("_EMISSION");
                    winda.GetComponent<Animator>().SetBool("ZparteruNa1", true);
                    
                    Debug.Log("ZparteruNa1");

                    StartCoroutine(StalaAwaryjna(czasAwarii));
                    StartCoroutine(WindaRuszyla(o1PietroWyzej));

                    zParteruNa1 = true;
                }
                else if (z2NaParter && !z1Na2 && !z1Na3)
                {
                    z2NaParter = false;

                    winda.GetComponent<Animator>().SetBool("Z2NaParter", false);
                    przyciskNaParter.GetComponent<MeshRenderer>().materials[0].DisableKeyword("_EMISSION");
                    przyciskNa1Pietro.GetComponent<MeshRenderer>().materials[0].EnableKeyword("_EMISSION");
                    winda.GetComponent<Animator>().SetBool("ZparteruNa1", true);
                    
                    Debug.Log("ZparteruNa1");

                    StartCoroutine(StalaAwaryjna(czasAwarii));
                    StartCoroutine(WindaRuszyla(o1PietroWyzej));

                    zParteruNa1 = true;

                }
                else if (z3NaParter && !z1Na2 && !z1Na3)
                {
                    z3NaParter = false;

                    winda.GetComponent<Animator>().SetBool("Z3NaParter", false);
                    przyciskNaParter.GetComponent<MeshRenderer>().materials[0].DisableKeyword("_EMISSION");
                    przyciskNa1Pietro.GetComponent<MeshRenderer>().materials[0].EnableKeyword("_EMISSION");
                    winda.GetComponent<Animator>().SetBool("ZparteruNa1", true);
                    
                    Debug.Log("ZparteruNa1");

                    StartCoroutine(StalaAwaryjna(czasAwarii));
                    StartCoroutine(WindaRuszyla(o1PietroWyzej));

                    zParteruNa1 = true;
                }
            }
        }
        else if (czyNacisnacPrzycisk && Input.GetKey(KeyCode.Alpha2))
        {
            if (!czyPierwszaJazda)
            {
                if (!z2Na1 && !z2Na3)
                {
                    winda.GetComponent<Animator>().SetBool("ZparteruNa2", true);
                    przyciskNa2Pietro.GetComponent<MeshRenderer>().materials[0].EnableKeyword("_EMISSION");

                    Debug.Log("ZparteruNa2");

                    StartCoroutine(StalaAwaryjna(czasAwarii));
                    StartCoroutine(WindaRuszyla(o2PietraWyzej));

                    zParteruNa2 = true;
                    czyPierwszaJazda = true;
                }
            }
            else
            {
                if (z1NaParter && !z2Na1 && !z2Na3)
                {
                    z1NaParter = false;

                    winda.GetComponent<Animator>().SetBool("Z1NaParter", false);
                    przyciskNaParter.GetComponent<MeshRenderer>().materials[0].DisableKeyword("_EMISSION");
                    przyciskNa2Pietro.GetComponent<MeshRenderer>().materials[0].EnableKeyword("_EMISSION");
                    winda.GetComponent<Animator>().SetBool("ZparteruNa2", true);

                    Debug.Log("ZparteruNa2");

                    StartCoroutine(StalaAwaryjna(czasAwariio2PietraWyzej));
                    StartCoroutine(WindaRuszyla(o2PietraWyzej));

                    zParteruNa2 = true;
                }
                else if (z2NaParter && !z2Na1 && !z2Na3)
                {
                    z2NaParter = false;

                    winda.GetComponent<Animator>().SetBool("Z2NaParter", false);
                    przyciskNaParter.GetComponent<MeshRenderer>().materials[0].DisableKeyword("_EMISSION");
                    przyciskNa2Pietro.GetComponent<MeshRenderer>().materials[0].EnableKeyword("_EMISSION");
                    winda.GetComponent<Animator>().SetBool("ZparteruNa2", true);

                    Debug.Log("ZparteruNa2");

                    StartCoroutine(StalaAwaryjna(czasAwariio2PietraWyzej));
                    StartCoroutine(WindaRuszyla(o2PietraWyzej));

                    zParteruNa2 = true;
                }
                else if (z3NaParter && !z2Na1 && !z2Na3)
                {
                    z3NaParter = false;
                    winda.GetComponent<Animator>().SetBool("Z3NaParter", false);
                    przyciskNaParter.GetComponent<MeshRenderer>().materials[0].DisableKeyword("_EMISSION");
                    przyciskNa2Pietro.GetComponent<MeshRenderer>().materials[0].EnableKeyword("_EMISSION");
                    winda.GetComponent<Animator>().SetBool("ZparteruNa2", true);

                    Debug.Log("ZparteruNa2");

                    StartCoroutine(StalaAwaryjna(czasAwariio2PietraWyzej));
                    StartCoroutine(WindaRuszyla(o2PietraWyzej));

                    zParteruNa2 = true;
                }
            }
        }
        else if (czyNacisnacPrzycisk && Input.GetKey(KeyCode.Alpha3))
        {
            if (!czyPierwszaJazda)
            {
                if (!z3Na2 && !z3Na1)
                {
                    winda.GetComponent<Animator>().SetBool("ZparteruNa3", true);
                    przyciskNa3Pietro.GetComponent<MeshRenderer>().materials[0].EnableKeyword("_EMISSION");

                    Debug.Log("ZparteruNa3");

                    StartCoroutine(StalaAwaryjna(czasAwarii));
                    StartCoroutine(WindaRuszyla(o3PietraWyzej));

                    zParteruNa3 = true;
                    czyPierwszaJazda = true;
                }
            }
            else
            {
                if (z1NaParter && !z3Na2 && !z3Na1)
                {
                    z1NaParter = false;

                    winda.GetComponent<Animator>().SetBool("Z1NaParter", false);
                    przyciskNaParter.GetComponent<MeshRenderer>().materials[0].DisableKeyword("_EMISSION");
                    przyciskNa3Pietro.GetComponent<MeshRenderer>().materials[0].EnableKeyword("_EMISSION");
                    winda.GetComponent<Animator>().SetBool("ZparteruNa3", true);

                    Debug.Log("ZparteruNa3");

                    StartCoroutine(StalaAwaryjna(czasAwariio3PietraWyzej));
                    StartCoroutine(WindaRuszyla(o3PietraWyzej));

                    zParteruNa3 = true;
                }
                else if (z2NaParter && !z3Na2 && !z3Na1)
                {
                    z2NaParter = false;

                    winda.GetComponent<Animator>().SetBool("Z2NaParter", false);
                    przyciskNaParter.GetComponent<MeshRenderer>().materials[0].DisableKeyword("_EMISSION");
                    przyciskNa3Pietro.GetComponent<MeshRenderer>().materials[0].EnableKeyword("_EMISSION");
                    winda.GetComponent<Animator>().SetBool("ZparteruNa3", true);

                    Debug.Log("ZparteruNa3");

                    StartCoroutine(StalaAwaryjna(czasAwariio2PietraWyzej));
                    StartCoroutine(WindaRuszyla(o3PietraWyzej));

                    zParteruNa3 = true;
                }
                else if(z3NaParter && !z3Na2 && !z3Na1)
                {
                    z3NaParter = false;

                    winda.GetComponent<Animator>().SetBool("Z3NaParter", false);
                    przyciskNaParter.GetComponent<MeshRenderer>().materials[0].DisableKeyword("_EMISSION");
                    przyciskNa3Pietro.GetComponent<MeshRenderer>().materials[0].EnableKeyword("_EMISSION");
                    winda.GetComponent<Animator>().SetBool("ZparteruNa3", true);

                    Debug.Log("ZparteruNa3");

                    StartCoroutine(StalaAwaryjna(czasAwariio3PietraWyzej));
                    StartCoroutine(WindaRuszyla(o3PietraWyzej));

                    zParteruNa3 = true;
                }
            }
        }
        
        if (czyPierwszaJazda)
        {
            if (czyNacisnacPrzycisk && Input.GetKey(KeyCode.Alpha0))
            {
                if (zParteruNa1 && !z1Na2 && !z1Na3)
                {
                    zParteruNa1 = false;

                    winda.GetComponent<Animator>().SetBool("ZparteruNa1", false);
                    przyciskNa1Pietro.GetComponent<MeshRenderer>().materials[0].DisableKeyword("_EMISSION");
                    przyciskNaParter.GetComponent<MeshRenderer>().materials[0].EnableKeyword("_EMISSION");
                    winda.GetComponent<Animator>().SetBool("Z1NaParter", true);

                    Debug.Log("Z1NaParter");

                    StartCoroutine(StalaAwaryjna(czasAwariio1PietroNizej));
                    StartCoroutine(WindaRuszyla(o1PietroNizej));

                    z1NaParter = true;
                }
                else if (z2Na1 && !z1Na2 && !z1Na3)
                {
                    z2Na1 = false;

                    winda.GetComponent<Animator>().SetBool("Z2Na1", false);
                    przyciskNa1Pietro.GetComponent<MeshRenderer>().materials[0].DisableKeyword("_EMISSION");
                    przyciskNaParter.GetComponent<MeshRenderer>().materials[0].EnableKeyword("_EMISSION");
                    winda.GetComponent<Animator>().SetBool("Z1NaParter", true);

                    Debug.Log("Z1NaParter");

                    StartCoroutine(StalaAwaryjna(czasAwariio1PietroNizej));
                    StartCoroutine(WindaRuszyla(o1PietroNizej));

                    z1NaParter = true;
                }
                else if (z3Na1 && !z1Na2 && !z1Na3)
                {
                    z3Na1 = false;

                    winda.GetComponent<Animator>().SetBool("Z3Na1", false);
                    przyciskNa1Pietro.GetComponent<MeshRenderer>().materials[0].DisableKeyword("_EMISSION");
                    przyciskNaParter.GetComponent<MeshRenderer>().materials[0].EnableKeyword("_EMISSION");
                    winda.GetComponent<Animator>().SetBool("Z1NaParter", true);

                    Debug.Log("Z1NaParter");

                    StartCoroutine(StalaAwaryjna(czasAwariio1PietroNizej));
                    StartCoroutine(WindaRuszyla(o1PietroNizej));

                    z1NaParter = true;
                }
            }

            if (czyNacisnacPrzycisk && Input.GetKey(KeyCode.Alpha2))
            {
                if (zParteruNa1 && !z1NaParter && !z1Na3)
                {
                    zParteruNa1 = false;

                    winda.GetComponent<Animator>().SetBool("ZparteruNa1", false);
                    przyciskNa1Pietro.GetComponent<MeshRenderer>().materials[0].DisableKeyword("_EMISSION");
                    przyciskNa2Pietro.GetComponent<MeshRenderer>().materials[0].EnableKeyword("_EMISSION");
                    winda.GetComponent<Animator>().SetBool("Z1Na2", true);

                    Debug.Log("Z1Na2");

                    StartCoroutine(StalaAwaryjna(czasAwariio1PietroNizej));
                    StartCoroutine(WindaRuszyla(o1PietroNizej));

                    z1Na2 = true;
                }
                else if (z3Na1 && !z1NaParter && !z1Na3)
                {
                    z3Na1 = false;

                    winda.GetComponent<Animator>().SetBool("Z3Na1", false);
                    przyciskNa1Pietro.GetComponent<MeshRenderer>().materials[0].DisableKeyword("_EMISSION");
                    przyciskNa2Pietro.GetComponent<MeshRenderer>().materials[0].EnableKeyword("_EMISSION");
                    winda.GetComponent<Animator>().SetBool("Z1Na2", true);

                    Debug.Log("Z1Na2");

                    StartCoroutine(StalaAwaryjna(czasAwariio1PietroNizej));
                    StartCoroutine(WindaRuszyla(o1PietroNizej));

                    z1Na2 = true;
                }
                else if (z2Na1 && !z1NaParter && !z1Na3)
                {
                    z2Na1 = false;

                    winda.GetComponent<Animator>().SetBool("Z2Na1", false);
                    przyciskNa1Pietro.GetComponent<MeshRenderer>().materials[0].DisableKeyword("_EMISSION");
                    przyciskNa2Pietro.GetComponent<MeshRenderer>().materials[0].EnableKeyword("_EMISSION");
                    winda.GetComponent<Animator>().SetBool("Z1Na2", true);

                    Debug.Log("Z1Na2");

                    StartCoroutine(StalaAwaryjna(czasAwariio1PietroNizej));
                    StartCoroutine(WindaRuszyla(o1PietroNizej));

                    z1Na2 = true;
                }
            }

            if (czyNacisnacPrzycisk && Input.GetKey(KeyCode.Alpha3))
            {
                if (zParteruNa1 && !z1NaParter && !z1Na2)
                {
                    zParteruNa1 = false;

                    winda.GetComponent<Animator>().SetBool("ZparteruNa1", false);
                    przyciskNa1Pietro.GetComponent<MeshRenderer>().materials[0].DisableKeyword("_EMISSION");
                    przyciskNa3Pietro.GetComponent<MeshRenderer>().materials[0].EnableKeyword("_EMISSION");
                    winda.GetComponent<Animator>().SetBool("Z1Na3", true);

                    Debug.Log("Z1Na3");

                    StartCoroutine(StalaAwaryjna(czasAwariio2PietraNizej));
                    StartCoroutine(WindaRuszyla(o2PietraNizej));

                    z1Na3 = true;
                }
                else if (z2Na1 && !z1NaParter && !z1Na2)
                {
                    z2Na1 = false;

                    winda.GetComponent<Animator>().SetBool("Z2Na1", false);
                    przyciskNa1Pietro.GetComponent<MeshRenderer>().materials[0].DisableKeyword("_EMISSION");
                    przyciskNa3Pietro.GetComponent<MeshRenderer>().materials[0].EnableKeyword("_EMISSION");
                    winda.GetComponent<Animator>().SetBool("Z1Na3", true);

                    Debug.Log("Z1Na3");

                    StartCoroutine(StalaAwaryjna(czasAwariio2PietraNizej));
                    StartCoroutine(WindaRuszyla(o2PietraNizej));

                    z1Na3 = true;
                }
                else if (z3Na1 && !z1NaParter && !z1Na2)
                {
                    z3Na1 = false;

                    winda.GetComponent<Animator>().SetBool("Z3Na1", false);
                    przyciskNa1Pietro.GetComponent<MeshRenderer>().materials[0].DisableKeyword("_EMISSION");
                    przyciskNa3Pietro.GetComponent<MeshRenderer>().materials[0].EnableKeyword("_EMISSION");
                    winda.GetComponent<Animator>().SetBool("Z1Na3", true);

                    Debug.Log("Z1Na3");

                    StartCoroutine(StalaAwaryjna(czasAwariio2PietraNizej));
                    StartCoroutine(WindaRuszyla(o2PietraNizej));

                    z1Na3 = true;
                }
            }

            if (czyNacisnacPrzycisk && Input.GetKey(KeyCode.Alpha0))
            {
                if (zParteruNa2 && !z2Na1 && !z2Na3)
                {
                    zParteruNa2 = false;

                    winda.GetComponent<Animator>().SetBool("ZparteruNa2", false);
                    przyciskNa2Pietro.GetComponent<MeshRenderer>().materials[0].DisableKeyword("_EMISSION");
                    przyciskNaParter.GetComponent<MeshRenderer>().materials[0].EnableKeyword("_EMISSION");
                    winda.GetComponent<Animator>().SetBool("Z2NaParter", true);

                    Debug.Log("Z2NaParter");

                    StartCoroutine(StalaAwaryjna(czasAwariio2PietraNizej));
                    StartCoroutine(WindaRuszyla(o2PietraNizej));

                    z2NaParter = true;
                }
                else if (z1Na2 && !z2Na1 && !z2Na3)
                {
                    z1Na2 = false;

                    winda.GetComponent<Animator>().SetBool("Z1Na2", false);
                    przyciskNa2Pietro.GetComponent<MeshRenderer>().materials[0].DisableKeyword("_EMISSION");
                    przyciskNaParter.GetComponent<MeshRenderer>().materials[0].EnableKeyword("_EMISSION");
                    winda.GetComponent<Animator>().SetBool("Z2NaParter", true);

                    Debug.Log("Z2NaParter");

                    StartCoroutine(StalaAwaryjna(czasAwariio2PietraNizej));
                    StartCoroutine(WindaRuszyla(o2PietraNizej));

                    z2NaParter = true;
                }
                else if (z3Na2 && !z2Na1 && !z2Na3)
                {
                    z3Na2 = false;

                    winda.GetComponent<Animator>().SetBool("Z3Na2", false);
                    przyciskNa2Pietro.GetComponent<MeshRenderer>().materials[0].DisableKeyword("_EMISSION");
                    przyciskNaParter.GetComponent<MeshRenderer>().materials[0].EnableKeyword("_EMISSION");
                    winda.GetComponent<Animator>().SetBool("Z2NaParter", true);

                    Debug.Log("Z2NaParter");

                    StartCoroutine(StalaAwaryjna(czasAwariio2PietraNizej));
                    StartCoroutine(WindaRuszyla(o2PietraNizej));

                    z2NaParter = true;
                }
            }

            if (czyNacisnacPrzycisk && Input.GetKey(KeyCode.Alpha1))
            {
                if (zParteruNa2 && !z2NaParter && !z2Na3)
                {
                    zParteruNa2 = false;

                    winda.GetComponent<Animator>().SetBool("ZparteruNa2", false);
                    przyciskNa2Pietro.GetComponent<MeshRenderer>().materials[0].DisableKeyword("_EMISSION");
                    przyciskNa1Pietro.GetComponent<MeshRenderer>().materials[0].EnableKeyword("_EMISSION");
                    winda.GetComponent<Animator>().SetBool("Z2Na1", true);
                    
                    Debug.Log("Z2Na1");

                    StartCoroutine(StalaAwaryjna(czasAwariio1PietroNizej));
                    StartCoroutine(WindaRuszyla(o1PietroNizej));

                    z2Na1 = true;
                }
                else if (z1Na2 && !z2NaParter && !z2Na3)
                {
                    z1Na2 = false;

                    winda.GetComponent<Animator>().SetBool("Z1Na2", false);
                    przyciskNa2Pietro.GetComponent<MeshRenderer>().materials[0].DisableKeyword("_EMISSION");
                    przyciskNa1Pietro.GetComponent<MeshRenderer>().materials[0].EnableKeyword("_EMISSION");
                    winda.GetComponent<Animator>().SetBool("Z2Na1", true);
                    
                    Debug.Log("Z2Na1");

                    StartCoroutine(StalaAwaryjna(czasAwariio1PietroNizej));
                    StartCoroutine(WindaRuszyla(o1PietroNizej));

                    z2Na1 = true;
                }
                else if (z3Na2 && !z2NaParter && !z2Na3)
                {
                    z3Na2 = false;

                    winda.GetComponent<Animator>().SetBool("Z3Na2", false);
                    przyciskNa2Pietro.GetComponent<MeshRenderer>().materials[0].DisableKeyword("_EMISSION");
                    przyciskNa1Pietro.GetComponent<MeshRenderer>().materials[0].EnableKeyword("_EMISSION");
                    winda.GetComponent<Animator>().SetBool("Z2Na1", true);
                    
                    Debug.Log("Z2Na1");

                    StartCoroutine(StalaAwaryjna(czasAwariio1PietroNizej));
                    StartCoroutine(WindaRuszyla(o1PietroNizej));

                    z2Na1 = true;
                }
            }

            if (czyNacisnacPrzycisk && Input.GetKey(KeyCode.Alpha3))
            {
                if (zParteruNa2 && !z2NaParter && !z2Na1)
                {
                    zParteruNa2 = false;

                    winda.GetComponent<Animator>().SetBool("ZparteruNa2", false);
                    przyciskNa2Pietro.GetComponent<MeshRenderer>().materials[0].DisableKeyword("_EMISSION");
                    przyciskNa3Pietro.GetComponent<MeshRenderer>().materials[0].EnableKeyword("_EMISSION");
                    winda.GetComponent<Animator>().SetBool("Z2Na3", true);

                    Debug.Log("Z2Na3");

                    StartCoroutine(StalaAwaryjna(czasAwariio1PietroWyzej));
                    StartCoroutine(WindaRuszyla(o1PietroWyzej));

                    z2Na3 = true;
                }
                else if (z1Na2 && !z2NaParter && !z2Na1)
                {
                    z1Na2 = false;

                    winda.GetComponent<Animator>().SetBool("Z1Na2", false);
                    przyciskNa2Pietro.GetComponent<MeshRenderer>().materials[0].DisableKeyword("_EMISSION");
                    przyciskNa3Pietro.GetComponent<MeshRenderer>().materials[0].EnableKeyword("_EMISSION");
                    winda.GetComponent<Animator>().SetBool("Z2Na3", true);

                    Debug.Log("Z2Na3");

                    StartCoroutine(StalaAwaryjna(czasAwariio1PietroWyzej));
                    StartCoroutine(WindaRuszyla(o1PietroWyzej));

                    z2Na3 = true;
                }
                else if (z3Na2 && !z2NaParter && !z2Na1)
                {
                    z3Na2 = false;

                    winda.GetComponent<Animator>().SetBool("Z3Na2", false);
                    przyciskNa2Pietro.GetComponent<MeshRenderer>().materials[0].DisableKeyword("_EMISSION");
                    przyciskNa3Pietro.GetComponent<MeshRenderer>().materials[0].EnableKeyword("_EMISSION");
                    winda.GetComponent<Animator>().SetBool("Z2Na3", true);

                    Debug.Log("Z2Na3");

                    StartCoroutine(StalaAwaryjna(czasAwariio1PietroWyzej));
                    StartCoroutine(WindaRuszyla(o1PietroWyzej));

                    z2Na3 = true;
                }
            }

            if (czyNacisnacPrzycisk && Input.GetKey(KeyCode.Alpha0))
            {
                if (zParteruNa3 && !z3Na2 && !z3Na1)
                {
                    zParteruNa3 = false;

                    winda.GetComponent<Animator>().SetBool("ZparteruNa3", false);
                    przyciskNa3Pietro.GetComponent<MeshRenderer>().materials[0].DisableKeyword("_EMISSION");
                    przyciskNaParter.GetComponent<MeshRenderer>().materials[0].EnableKeyword("_EMISSION");
                    winda.GetComponent<Animator>().SetBool("Z3NaParter", true);

                    Debug.Log("Z3NaParter");

                    StartCoroutine(StalaAwaryjna(czasAwariio3PietraNizej));
                    StartCoroutine(WindaRuszyla(o3PietraNizej));

                    z3NaParter = true;
                }
                else if (z1Na3 && !z3Na2 && !z3Na1)
                {
                    z1Na3 = false;

                    winda.GetComponent<Animator>().SetBool("Z1Na3", false);
                    przyciskNa3Pietro.GetComponent<MeshRenderer>().materials[0].DisableKeyword("_EMISSION");
                    przyciskNaParter.GetComponent<MeshRenderer>().materials[0].EnableKeyword("_EMISSION");
                    winda.GetComponent<Animator>().SetBool("Z3NaParter", true);

                    Debug.Log("Z3NaParter");

                    StartCoroutine(StalaAwaryjna(czasAwariio3PietraNizej));
                    StartCoroutine(WindaRuszyla(o3PietraNizej));

                    z3NaParter = true;
                }
                else if (z2Na3 && !z3Na2 && !z3Na1)
                {
                    z2Na3 = false;

                    winda.GetComponent<Animator>().SetBool("Z2Na3", false);
                    przyciskNa3Pietro.GetComponent<MeshRenderer>().materials[0].DisableKeyword("_EMISSION");
                    przyciskNaParter.GetComponent<MeshRenderer>().materials[0].EnableKeyword("_EMISSION");
                    winda.GetComponent<Animator>().SetBool("Z3NaParter", true);

                    Debug.Log("Z3NaParter");

                    StartCoroutine(StalaAwaryjna(czasAwariio3PietraNizej));
                    StartCoroutine(WindaRuszyla(o3PietraNizej));

                    z3NaParter = true;
                }
            }

            if (czyNacisnacPrzycisk && Input.GetKey(KeyCode.Alpha1))
            {
                if (zParteruNa3 && !z3Na2 && !z3NaParter)
                {
                    zParteruNa3 = false;

                    winda.GetComponent<Animator>().SetBool("ZparteruNa3", false);
                    przyciskNa3Pietro.GetComponent<MeshRenderer>().materials[0].DisableKeyword("_EMISSION");
                    przyciskNa1Pietro.GetComponent<MeshRenderer>().materials[0].EnableKeyword("_EMISSION");
                    winda.GetComponent<Animator>().SetBool("Z3Na1", true);
                    
                    Debug.Log("Z3Na1");

                    StartCoroutine(StalaAwaryjna(czasAwariio2PietraNizej));
                    StartCoroutine(WindaRuszyla(o2PietraNizej));

                    z3Na1 = true;
                }
                else if (z1Na3 && !z3Na2 && !z3NaParter)
                {
                    z1Na3 = false;

                    winda.GetComponent<Animator>().SetBool("Z1Na3", false);
                    przyciskNa3Pietro.GetComponent<MeshRenderer>().materials[0].DisableKeyword("_EMISSION");
                    przyciskNa1Pietro.GetComponent<MeshRenderer>().materials[0].EnableKeyword("_EMISSION");
                    winda.GetComponent<Animator>().SetBool("Z3Na1", true);
                    
                    Debug.Log("Z3Na1");

                    StartCoroutine(StalaAwaryjna(czasAwariio2PietraNizej));
                    StartCoroutine(WindaRuszyla(o2PietraNizej));

                    z3Na1 = true;
                }
                else if (z2Na3 && !z3Na2 && !z3NaParter)
                {
                    z2Na3 = false;

                    winda.GetComponent<Animator>().SetBool("Z2Na3", false);
                    przyciskNa3Pietro.GetComponent<MeshRenderer>().materials[0].DisableKeyword("_EMISSION");
                    przyciskNa1Pietro.GetComponent<MeshRenderer>().materials[0].EnableKeyword("_EMISSION");
                    winda.GetComponent<Animator>().SetBool("Z3Na1", true);
                    
                    Debug.Log("Z3Na1");

                    StartCoroutine(StalaAwaryjna(czasAwariio2PietraNizej));
                    StartCoroutine(WindaRuszyla(o2PietraNizej));

                    z3Na1 = true;
                }
            }

            if (czyNacisnacPrzycisk && Input.GetKey(KeyCode.Alpha2))
            {
                if (zParteruNa3 && !z3Na1 && !z3NaParter)
                {
                    zParteruNa3 = false;

                    winda.GetComponent<Animator>().SetBool("ZparteruNa3", false);
                    przyciskNa3Pietro.GetComponent<MeshRenderer>().materials[0].DisableKeyword("_EMISSION");
                    przyciskNa2Pietro.GetComponent<MeshRenderer>().materials[0].EnableKeyword("_EMISSION");
                    winda.GetComponent<Animator>().SetBool("Z3Na2", true);

                    Debug.Log("Z3Na2");

                    StartCoroutine(StalaAwaryjna(czasAwariio1PietroNizej));
                    StartCoroutine(WindaRuszyla(o1PietroNizej));

                    z3Na2 = true;
                }
                else if (z1Na3 && !z3Na1 && !z3NaParter)
                {
                    z1Na3 = false;

                    winda.GetComponent<Animator>().SetBool("Z1Na3", false);
                    przyciskNa3Pietro.GetComponent<MeshRenderer>().materials[0].DisableKeyword("_EMISSION");
                    przyciskNa2Pietro.GetComponent<MeshRenderer>().materials[0].EnableKeyword("_EMISSION");
                    winda.GetComponent<Animator>().SetBool("Z3Na2", true);

                    Debug.Log("Z3Na2");

                    StartCoroutine(StalaAwaryjna(czasAwariio1PietroNizej));
                    StartCoroutine(WindaRuszyla(o1PietroNizej));

                    z3Na2 = true;
                }
                else if (z2Na3 && !z3Na1 && !z3NaParter)
                {
                    z2Na3 = false;

                    winda.GetComponent<Animator>().SetBool("Z2Na3", false);
                    przyciskNa3Pietro.GetComponent<MeshRenderer>().materials[0].DisableKeyword("_EMISSION");
                    przyciskNa2Pietro.GetComponent<MeshRenderer>().materials[0].EnableKeyword("_EMISSION");
                    winda.GetComponent<Animator>().SetBool("Z3Na2", true);

                    Debug.Log("Z3Na2");

                    StartCoroutine(StalaAwaryjna(czasAwariio1PietroNizej));
                    StartCoroutine(WindaRuszyla(o1PietroNizej));

                    z3Na2 = true;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider kolizja)
    {
        if (kolizja.gameObject.tag == "gracz")
        {
            czyNacisnacPrzycisk = true;
        }
    }

    private void OnTriggerExit(Collider kolizja)
    {
        if (kolizja.gameObject.tag == "gracz")
        {
            czyNacisnacPrzycisk = false;
        }
    }
}