using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public float sinkSpeed = 1f;
    public int scoreValue = 10;
    public AudioClip deathClip;


    Animator anim;
    AudioSource enemyAudio;
    ParticleSystem hitParticles;
    CapsuleCollider capsuleCollider;
	BoxCollider headBox; 


    bool isDead;
    bool isSinking;


    void Awake ()
    {
        anim = GetComponent <Animator> ();
        enemyAudio = GetComponent <AudioSource> ();
        hitParticles = GetComponentInChildren <ParticleSystem> ();
        capsuleCollider = GetComponent <CapsuleCollider> ();
		headBox = GetComponent <BoxCollider> (); 


        currentHealth = startingHealth;
    }


    void Update ()
    {
        if(isSinking)
        {
            transform.Translate (Vector3.down * sinkSpeed * Time.deltaTime);
        }
    }


    public void TakeDamage (int amount, Vector3 hitPoint)
    {
       

		if(isDead)
            return;

        enemyAudio.Play ();

        currentHealth -= amount;
            
        hitParticles.transform.position = hitPoint;
        hitParticles.Play();

        if(currentHealth <= 0)
        {
            Death ();
        }
    }

	void OnCollisionEnter (Collision col)
	{
		ContactPoint HammerHit = col.contacts[0];
		Vector3 hitPoint =HammerHit.point;
		if (col.gameObject.name == "Hammer" && col.collider.GetType()==typeof(BoxCollider) ) {
			transform.localScale += new Vector3 (0, -.4f, 0); 
			TakeDamage ( 51, hitPoint); 
		}


	}




    void Death ()
    {
        isDead = true;

        //capsuleCollider.isTrigger = true; //changes the capsule collider to a trigger you can pass through 

        anim.SetTrigger ("Die");

        enemyAudio.clip = deathClip;
        enemyAudio.Play ();
    }


    public void StartSinking ()
    {
        GetComponent <UnityEngine.AI.NavMeshAgent> ().enabled = false;
       // GetComponent <Rigidbody> ().isKinematic = true;  //rigidbody kinematic 
        //isSinking = true;
        ScoreManager.score += scoreValue;
        Destroy (gameObject, 1f);
    }
  } //end
