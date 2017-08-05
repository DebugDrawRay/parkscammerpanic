using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils 
{
    public static bool IsVisibleFrom(Renderer renderer, Camera camera)
    {
        if (renderer && camera)
        {
            Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
            return GeometryUtility.TestPlanesAABB(planes, renderer.bounds);
        }
        else
        {
            return false;
        }
    }
}
