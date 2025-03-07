﻿using UnityEngine;

namespace RP0.Utilities
{
    public class SphericalTankUtilities
    {
        private const int MinSpheres = 2;
        private const float BaseRadius = 0.05f;

        public static float GetSphericalTankVolume(float availableVolume)
        {
            float radius = GetSphericalTankRadius(availableVolume);
            float sphereVolume = GetSphereVolume(radius);
            return GetSphereCount(availableVolume, sphereVolume) * sphereVolume;
        }

        public static float GetRequiredVolumeFromSphericalTankVolume(float desiredVolume)
        {
            if (desiredVolume == 0)
                return 0;
            float radius = GetSphericalTankRadius(desiredVolume);
            float sphereVolume = GetSphereVolume(radius);
            float numSpheres = Mathf.Ceil(desiredVolume / sphereVolume);
            return numSpheres * sphereVolume;
        }

        private static float GetSphereCount(float availableVolume, float sphereVolume) => sphereVolume == 0 ? 0 : Mathf.Floor(availableVolume / sphereVolume);

        public static float GetSphereVolume(float radius)
        {
            return Mathf.Pow(radius, 3) * 4 / 3 * Mathf.PI;
        }

        public static float GetSphericalTankRadius(float availableVolume)
        {
            if (availableVolume == 0)
            {
                return 0;
            }

            var radiusExponent = Mathf.Max(0, Mathf.Log(Mathf.Pow(availableVolume / Mathf.PI * 3 / 4 / MinSpheres, 1f / 3) / BaseRadius, 2));
            return Mathf.Pow(2, Mathf.Floor(Mathf.Round(radiusExponent * 10000) / 10000)) * BaseRadius;
        }
    }
}
