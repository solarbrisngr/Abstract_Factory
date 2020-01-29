using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IVehicleFactory
{
    IVehicle Create(VehicleRequirements requirements);
}

//public abstract class AbstractVehicleFactory
//{
//    //public abstract IVehicleFactory CycleFactory();
//    //public abstract IVehicleFactory MotorVehicleFactory();

//    public abstract IVehicle Create();
//}

public class VehicleFactory // : AbstractVehicleFactory
{
    //public override IVehicleFactory CycleFactory()
    //{
    //    return new Cyclefactory();
    //}

    //public override IVehicleFactory MotorVehicleFactory()
    //{
    //    return new MotorVehicleFactory();
    //}

    private readonly IVehicleFactory _factory;
    private readonly VehicleRequirements _requirements;
    
    public VehicleFactory(VehicleRequirements requirements)
    {
        _factory = requirements.Engine ? (IVehicleFactory)new MotorVehicleFactory() : new Cyclefactory();
        _requirements = requirements;
    }

    public IVehicle Create()
    {
        return _factory.Create(_requirements);
    }
}

public class Cyclefactory : IVehicleFactory
{
    public IVehicle Create(VehicleRequirements requirements)
    {
        switch (requirements.Passengers)
        {
            case 1:
                if (requirements.NumberOfWheels == 1) return new Unicycle();
                return new Bicycle();
            case 2:
                return new Tandem();
            case 3:
                return new Tricycle();
            case 4:
                if (requirements.HasCargo) return new GoKart();
                return new FamilyBike();
            default:
                return new Bicycle();
        }
    }
}

public class MotorVehicleFactory : IVehicleFactory
{
    public IVehicle Create(VehicleRequirements requirements)
    {
        switch (requirements.Passengers)
        {
           case 2:
                return new Motorbike();
            default:
                return new Truck();
        }
    }
}
