using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{
    public int NumberOfWheels;
    public bool Engine;
    public int Passengers;
    public bool Cargo;

    // Start is called before the first frame update
    void Start()
    {
        VehicleRequirements requirements = new VehicleRequirements();

        requirements.NumberOfWheels = Mathf.Max(NumberOfWheels, 1);
        requirements.Engine = Engine;
        requirements.Passengers = Mathf.Max(Passengers);
        requirements.Engine = Cargo;
        requirements.HasCargo = Cargo;

        //IVehicle v = GetVehicle(requirements);
        VehicleFactory factory = new VehicleFactory(requirements);
        IVehicle v = factory.Create();
        Debug.Log(v);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private static IVehicle GetVehicle(VehicleRequirements requirements)
    //{
    //    VehicleFactory factory = new VehicleFactory();
    //    //IVehicle vehicle;

    //    if (requirements.Engine)
    //    {
    //        return factory.MotorVehicleFactory().Create(requirements);
    //    }

    //    return factory.CycleFactory().Create(requirements);
    //}
}
