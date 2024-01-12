using TMPro;
using UnityEngine;




public class Shoot : MonoBehaviour
{
    private AudioSource Pan;
    [SerializeField] private AudioClip Pew = null;

    public ParticleSystem FireParticules;
    public Transform FirePoint;
    public GameObject Fire;
    public bool canShoot = true;
    public GameObject DeathScreen;

    public int PlayerHealth = 3;
    public TextMeshProUGUI HPText;
    // public GameObject HitPoint;

    private void Awake()
    {
        Pan = GetComponent<AudioSource>();

    }

    private void Start()
    {

        FireParticules.Stop();
        DeathScreen.SetActive(false);
        canShoot = true;
        HPText.text = PlayerHealth.ToString() + " HP";
    }

    void Update()
    {
        PlayerDeath();

       if (Input.GetMouseButtonDown(0) && canShoot)
       {
            Shooting();
            Pan.PlayOneShot(Pew);
         
        }
    }

    public void Shooting()
    {
        FireParticules.Stop();
        FireParticules.Play();

        RaycastHit hit;

        if(Physics.Raycast(FirePoint.position, Camera.main.transform.forward, out hit, 200))
        {
            Debug.DrawRay(FirePoint.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
            Debug.Log(hit.collider.name);

            if (hit.collider.CompareTag("Enemy"))
            {

                TeleportEnemy(hit.collider.gameObject);
                ScoreManager.Instance.AddPoint();
            }
            else
            {
                TakeDamage();
            }
            
           // Instantiate(HitPoint, hit.point, Quaternion.identity);
        }
    }
    public void ClearOldParticles()
    {
        ParticleSystem[] particles = FindObjectsOfType<ParticleSystem>();

        foreach (ParticleSystem particle in particles)
        {
            if (particle.isPlaying)
            {
                float duration = particle.main.duration + particle.main.startLifetime.constant;
                Destroy(particle.gameObject, duration);
            }
        }
    }
    void TeleportEnemy(GameObject enemy)
    {
        // Générer une nouvelle position aléatoire sur la carte
        Vector3 randomPosition = new Vector3(Random.Range(0, 100), Random.Range(2.52f, 20f), Random.Range(0, 100));

        // Déplacer l'ennemi vers la nouvelle position
        enemy.transform.position = randomPosition;
    }

    void TakeDamage()
    {
        PlayerHealth--;
        HPText.text = PlayerHealth.ToString() + " HP";
        Debug.Log("Player Health: " + PlayerHealth);

        if (PlayerHealth <= 0)
        {
            // Le joueur n'a plus de vie, vous pouvez ajouter ici le code pour gérer la mort du joueur
            Debug.Log("Player has been defeated!");
        }
    }

    void PlayerDeath()
    {
        if (PlayerHealth <= 0)
        {
            DeathScreen.SetActive(true);
            Time.timeScale = 0f;
            canShoot = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
