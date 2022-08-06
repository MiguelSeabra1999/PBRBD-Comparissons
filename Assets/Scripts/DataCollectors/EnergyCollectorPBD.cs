using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyCollectorPBD : DataCollector
{
    private List<DataPacket> totalEnergy = new List<DataPacket>();
    private List<DataPacket> kineticEnergy = new List<DataPacket>();
    private List<DataPacket> potentialEnergy = new List<DataPacket>();

    void OnDestroy()
    {
        FileWritter.WriteToFile("PBD/Energy", "totalEnergy", totalEnergy);
        FileWritter.WriteToFile("PBD/Energy", "kineticEnergy", kineticEnergy);
        FileWritter.WriteToFile("PBD/Energy", "potentialEnergy", potentialEnergy);
    }

    protected override void StepEnd()
    {
        DataPacket data = GetTotalEnergy();
        totalEnergy.Add(data);
        data = GetKineticEnergy();
        kineticEnergy.Add(data);
        data = GetPotentialEnergy();
        potentialEnergy.Add(data);
    }

    private DataPacket GetTotalEnergy()
    {
        double sum = 0;
        foreach (Particle p in engine.allBodies)
        {
            sum += p.CalcTotalEnergy(PhysicsEngine.gravForce);
        }
        return new DataPacket(sum);
    }

    private DataPacket GetPotentialEnergy()
    {
        double sum = 0;
        foreach (Particle p in engine.allBodies)
        {
            sum += p.CalcPotentialEnergy(PhysicsEngine.gravForce);
        }
        return new DataPacket(sum);
    }

    private DataPacket GetKineticEnergy()
    {
        double sum = 0;
        foreach (Particle p in engine.allBodies)
        {
            sum += p.CalcKineticEnergy();
        }
        return new DataPacket(sum);
    }

    private DataPacket GetLinearKineticEnergy()
    {
        double sum = 0;
        foreach (Particle p in engine.allBodies)
        {
            sum += p.CalcLinearKineticEnergy();
        }
        return new DataPacket(sum);
    }

    private DataPacket GetAngularKineticEnergy()
    {
        double sum = 0;
        foreach (Particle p in engine.allBodies)
        {
            sum += p.CalcKineticEnergy();
        }
        return new DataPacket(sum);
    }
}
