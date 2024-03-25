using System;
using System.Collections.Generic;

namespace ContainersProgram
{
    public class ContainerShip
    {
        private List<Container> containers;
        public double MaxSpeed { get; }
        public int MaxContainers { get; }
        public double MaxWeight { get; }

        public ContainerShip(double maxSpeed, int maxContainers, double maxWeight)
        {
            MaxSpeed = maxSpeed;
            MaxContainers = maxContainers;
            MaxWeight = maxWeight;
            containers = new List<Container>();
        }

        public void AddContainer(Container container)
        {
            if (containers.Count < MaxContainers && GetTotalWeight() + container.Weight <= MaxWeight)
            {
                containers.Add(container);
            }
            else
            {
                throw new InvalidOperationException("Cannot add more containers. Ship is at full capacity.");
            }
        }

        public void LoadContainers(List<Container> containersToAdd)
        {
            foreach (var container in containersToAdd)
            {
                AddContainer(container);
            }
        }

        public bool RemoveContainer(string serialNumber)
        {
            Container containerToRemove = containers.Find(container => container.SerialNumber == serialNumber);
            if (containerToRemove != null)
            {
                containers.Remove(containerToRemove);
                return true;
            }
            return false;
        }

        public void MoveContainer(Container container, ContainerShip destinationShip)
        {
            if (RemoveContainer(container.SerialNumber))
            {
                destinationShip.AddContainer(container);
            }
            else
            {
                throw new InvalidOperationException($"Container with serial number {container.SerialNumber} not found on this ship.");
            }
        }

        public void ReplaceContainer(string serialNumber, Container newContainer)
        {
            for (int i = 0; i < containers.Count; i++)
            {
                if (containers[i].SerialNumber == serialNumber)
                {
                    containers[i] = newContainer;
                    return;
                }
            }
            throw new InvalidOperationException($"Container with serial number {serialNumber} not found on the ship.");
        }

        public double GetTotalWeight()
        {
            double totalWeight = 0;
            foreach (var container in containers)
            {
                totalWeight += container.Weight;
            }
            return totalWeight;
        }

        public override string ToString()
        {
            string shipInfo = $"Container Ship - Max Speed: {MaxSpeed} knots, Max Containers: {MaxContainers}, Max Weight: {MaxWeight} tons\n";
            shipInfo += "Containers on Ship:\n";
            foreach (var container in containers)
            {
                shipInfo += container.ToString() + "\n";
            }
            return shipInfo;
        }
    }
}