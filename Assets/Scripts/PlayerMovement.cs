using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    public GameObject trainee;
    public float frequencePopTrainee;
    private AudioSource source;
    public AudioClip sonChute;
    public AudioClip sonBonus;
    public AudioClip sonDouleur;

    Animator anim;
    int runHash = Animator.StringToHash("run");
    int jumpHash = Animator.StringToHash("jump");
    int bonusHash = Animator.StringToHash("bonus");
    int flyHash = Animator.StringToHash("fly");
    int bonusStateHash = Animator.StringToHash("Base Layer.bonus");
    AnimatorStateInfo stateInfo;

    Rigidbody rb;
    public float vitesse;
    public float saut;
    private float altitude;
    bool tombe;
    bool grounded;

    float timer;
    float timer2;

    public float horizontalRotationSpeed;
    public float verticalRotationSpeed;
    float m_MousseXInputValue;
    float m_MousseYInputValue;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        timer = Time.time;
        timer2 = timer;
        rb = transform.GetComponent<Rigidbody>();
        anim.SetFloat("speedWalk",vitesse);
        altitude = transform.position.y;
        tombe = false;
        grounded = true;
    }


    // Update is called once per frame
    void Update () {
        if (!Input.GetKey(KeyCode.LeftAlt))
        {
            rotateArround();
        }
        moveAndAnim();
        
        chute();

        if ((Time.time - timer2) > frequencePopTrainee)
        {
            timer2 = Time.time;
            Instantiate(trainee, transform.position, Quaternion.identity);
            
        } 
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!grounded)
        {
            source.clip = sonDouleur;
            source.Play();
            grounded = true;
        }
    }

    void rotateArround()
    {
        m_MousseXInputValue = Input.GetAxis("Mouse X");
        m_MousseYInputValue = Input.GetAxis("Mouse Y");

        //transform.RotateAround(transform.position, transform.right, verticalRotationSpeed * -m_MousseYInputValue * Time.deltaTime);
        transform.RotateAround(transform.position, transform.up, horizontalRotationSpeed * m_MousseXInputValue * Time.deltaTime);

        //transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(verticalRotationSpeed * -m_MousseYInputValue * Time.deltaTime, horizontalRotationSpeed * m_MousseXInputValue * Time.deltaTime, 0.0f));
    }

    void moveAndAnim()
    {
        // AVANT, ARRIERE
        if (Input.GetKey(KeyCode.Z))
        {
            anim.SetTrigger(runHash);
            rb.MovePosition(rb.position + (transform.forward * vitesse));
        }
        else if (Input.GetKey(KeyCode.S))
        {
            anim.SetTrigger(runHash);
            rb.MovePosition(rb.position + (-transform.forward * vitesse));
        }
        else
        {
            anim.SetBool(runHash, false);
        }

        //GAUCHE, DROITE
        if (Input.GetKey(KeyCode.Q))
        {
            anim.SetTrigger(runHash);
            rb.MovePosition(rb.position + (-transform.right * vitesse));
        }
        else if (Input.GetKey(KeyCode.D))
        {
            anim.SetTrigger(runHash);
            rb.MovePosition(rb.position + (transform.right * vitesse));
        }
        else { }

        // SAUT
        if (Input.GetKey(KeyCode.Space) && (Time.time - timer) > .5)
        {
            timer = Time.time;
            anim.SetTrigger(jumpHash);
            rb.AddForce(Vector3.up * saut, ForceMode.VelocityChange);
        }
        else
        {
            anim.SetBool(jumpHash, false);
        }

        // BONUS
        if (Input.GetKey(KeyCode.B))
        {
            anim.SetTrigger(bonusHash);
            source.clip = sonBonus;
            source.Play();    
        }
        else
        {
             anim.SetBool(bonusHash, false);
             stateInfo = anim.GetCurrentAnimatorStateInfo(0);

        }

        //control anim et son 
        if (stateInfo.IsName("ilde") && source.clip.name != "aouhh")
        {
            source.Stop();
        }

    }

    void chute()
    {
        tombe = (altitude > transform.position.y);
        altitude = transform.position.y;

        if(altitude > 3 && tombe)
        {
            anim.SetBool(flyHash, true);
            if (!stateInfo.IsName("fly"))
            {
                source.clip = sonChute;
                source.Play();
            }
            grounded = false;
        }
        else
        {
            anim.SetBool(flyHash, false);
        }
    }
}
