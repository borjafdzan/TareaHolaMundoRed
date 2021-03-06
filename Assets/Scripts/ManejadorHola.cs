using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

namespace HolaMundo
{

    public class ManejadorHola : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
        }

        void OnGUI()
        {
            GUILayout.BeginArea(new Rect(10, 10, 300, 300));
            if (!NetworkManager.Singleton.IsClient && !NetworkManager.Singleton.IsServer)
            {
                PonerBotones();
            }
            else
            {
                EtiquetasEstado();
                EnviarNuevaPosicion();
            }
            GUILayout.EndArea();
        }
        private void PonerBotones()
        {
            if (GUILayout.Button("Host")) NetworkManager.Singleton.StartHost();
            if (GUILayout.Button("Client")) NetworkManager.Singleton.StartClient();
            if (GUILayout.Button("Servidor")) NetworkManager.Singleton.StartServer();
        }

        private void EtiquetasEstado()
        {
            string modo = NetworkManager.Singleton.IsHost ? "Host" : NetworkManager.Singleton.IsServer ? "Servidor" : "Cliente";

            GUILayout.Label("Transporte: " + NetworkManager.Singleton.NetworkConfig.NetworkTransport.GetType().Name);
            GUILayout.Label("Modo: " + modo);
        }

        private void EnviarNuevaPosicion()
        {
            if (GUILayout.Button(NetworkManager.Singleton.IsServer ? "Mover" : "Peticion cambio posicion"))
            {
                NetworkObject objetoJugador = NetworkManager.Singleton.SpawnManager.GetLocalPlayerObject();
                if (objetoJugador != null)
                {
                    HolaMundoJugador jugador = objetoJugador.GetComponent<HolaMundoJugador>();
                    jugador.Mover();
                }
            }
        }
    }
}