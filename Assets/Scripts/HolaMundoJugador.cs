using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

namespace HolaMundo
{
    public class HolaMundoJugador : NetworkBehaviour
    {
        NetworkVariable<Vector3> Posicion = new NetworkVariable<Vector3>();
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            transform.position = Posicion.Value;
        }

        public override void OnNetworkSpawn()
        {
            if (IsOwner){
                Mover();
            }
        }

        //Si esta conectado como servidor envia la posicion aleatoria
        //en caso contrario la envia mediante ServerRpc
        public void Mover()
        {
            if (NetworkManager.Singleton.IsServer){
                Vector3 posicionAleatoria = PosicionAleatoriaSuelo(); 
                transform.position = posicionAleatoria;
                Posicion.Value = posicionAleatoria;
            } else {
                EnviarPosicionServerRpc();
            }
            Debug.Log("El jugador se movio");
        }

        private Vector3 PosicionAleatoriaSuelo(){
            return new Vector3(Random.Range(-3f, 3f), 1f, Random.Range(-3f, 3f));
        }

        [ServerRpc]
        private void EnviarPosicionServerRpc(){
            Posicion.Value = PosicionAleatoriaSuelo();
        }
    }
}
