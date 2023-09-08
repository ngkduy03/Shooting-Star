using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParitcleEngine : MonoBehaviour
{
    private float posX;
    private float posY;
    
    [SerializeField]
    private ParticleSystem[] particleEngines;
    private int enginePower = 5;
    private void Start() {
        posX = transform.position.x;
        posY = transform.position.y;
    }
    void Update()
    {
        HandleParticleEngineEmit();
    }
    void HandleParticleEngineEmit(){
        if(posX > transform.position.x){
            particleEngines[0].Emit(enginePower);
            posX = transform.position.x;
        }
        else if(posX < transform.position.x){
            particleEngines[1].Emit(enginePower);
            posX = transform.position.x;
        }
        if(posY < transform.position.y){
            particleEngines[2].Emit(enginePower);
            particleEngines[3].Emit(enginePower);
            posY = transform.position.y;
        }
        else if(posY > transform.position.y){
            particleEngines[4].Emit(enginePower);
            particleEngines[5].Emit(enginePower);
            posY = transform.position.y;
        }
    }
    void EmitParticle(int index, int power){
        particleEngines[index].Emit(power);
    }
}
