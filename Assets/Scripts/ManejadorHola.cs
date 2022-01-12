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

        }

        private void EnviarNuevaPosicion()
        {

        }
    }
}