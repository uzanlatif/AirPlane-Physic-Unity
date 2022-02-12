using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaneController : MonoBehaviour
{
       public Transform PesawatTempur;
    public GameObject bulletPrefab;
    public float speed,turnSpeed,rotateSpeed,forceUpDown;

    public Transform Fp1,Fp2,Fp3,Fp4;
    public GameObject pesawat;
    public float bulletSpeed;
    public float interval;
    public float counter;
    bool canShoot;

    public Text PlaneRotX,PlaneRotY,PlaneRotz;
    public Text PlanePosX,PlanePosY,PlanePosz;

    public Image UIHP;

    public float currentHP,MaxHP, fill;

    Rigidbody rbb;
    // Start is called before the first frame update
    void Start()
    {      
           Cursor.lockState = CursorLockMode.Locked;
           MaxHP=100;
           currentHP=MaxHP;
           canShoot=true;
    }

    // Update is called once per frame
    void Update()
    {
       checkRotation();
       checkPosition();
       checkHP();
       checkMovement();
       checkShoot();
       
     
    }

    void checkShoot(){
           if(Input.GetMouseButton(0) && canShoot){
                Invoke("Shoot",interval);
                canShoot=false;
         }
    }

    void checkMovement(){
           //naik turun
        if(Input.GetKey(KeyCode.W)){
                transform.Rotate (-forceUpDown,0,0);
        }

        if(Input.GetKey(KeyCode.S)){
                transform.Rotate (forceUpDown,0,0);
        }

        //belok
         if (Input.GetKey(KeyCode.A))
         {  
                transform.Rotate(new Vector3(0f, -turnSpeed, 0f));    
                    
         }
 
         if (Input.GetKey(KeyCode.D))
         {
                transform.Rotate(new Vector3(0f, turnSpeed, -0f));      

         }
        //rotate
         if (Input.GetKey(KeyCode.Q))
         {  
                transform.Rotate(new Vector3(0f, 0f, rotateSpeed));    
                    
         }
 
         if (Input.GetKey(KeyCode.E))
         {
                transform.Rotate(new Vector3(0f, 0f, -rotateSpeed));      

         }
    }

    void checkPosition(){
              var xPos = this.transform.position.x;
              var yPos = this.transform.position.y;
              var zPos = this.transform.position.z;

              PlanePosX.text = xPos.ToString();
              PlanePosY.text = yPos.ToString();
              PlanePosz.text = zPos.ToString();
    }


       void checkHP(){
              fill=currentHP/MaxHP;
              UIHP.fillAmount=fill;
}
    void checkRotation(){

             var xRot = PesawatTempur.eulerAngles.x;
             var yRot = PesawatTempur.eulerAngles.y;
             var zRot = PesawatTempur.eulerAngles.z;

              PlaneRotX.text = xRot.ToString();
              PlaneRotY.text = yRot.ToString();
              PlaneRotz.text = zRot.ToString();
             
    }

    void Shoot(){
           counter++;
           float division=counter%2;
           if(division==0){
              canShoot=true;
              GameObject newBullet = Instantiate(bulletPrefab, Fp1.position,Fp1.rotation);
              rbb=newBullet.GetComponent<Rigidbody>();
              rbb.AddForce(transform.forward * speed * 10);
              Destroy(newBullet,2);
           }
           if(division==1){
              canShoot=true;
              GameObject newBullet = Instantiate(bulletPrefab, Fp2.position,Fp2.rotation);
              rbb=newBullet.GetComponent<Rigidbody>();
              rbb.AddForce(transform.forward * speed * 10);
              Destroy(newBullet,2);
           }
    }

       private void OnTriggerEnter(Collider other) {
       if(other.gameObject.tag=="Ground"){
       Debug.Log("MatiNabrak");
       }

       if(other.gameObject.tag=="BltMusuh"){
              //take hit
              currentHP=currentHP-1;
              if(currentHP<=0){
              Debug.Log("MatiDitembak");
       }
       } 
       }
       

        private void FixedUpdate() {
        transform.Translate(0, 0, speed * Time.deltaTime, Space.Self);
        }
       
}

