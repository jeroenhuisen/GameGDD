using UnityEngine;
using UnityEngine.UI;
using System.Collections;
namespace UnityStandardAssets.Vehicles.Car
{
    public class SpeedGUI : MonoBehaviour
    {
        //public CarController car;
        public controller car;
        public Text speedText;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnGUI()
        {
            speedText.text = ""+ (int) car.CurrentSpeed;
        }
    }

}