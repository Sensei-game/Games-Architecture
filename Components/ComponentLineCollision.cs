using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenGL_Game.Components
{
    class ComponentLineCollision : IComponent
    {

        public List<Coordinates> Limits;

        //Link this to Maze after setting the list of coordinates for each limit
        public ComponentLineCollision(List<Coordinates> limit_ /*stuff*/)
        {
            //stuff for addition in Entity
            Limits = limit_;

        }

        //public float stuff
        //{
        //    return false;
        //    //get { return radius; }
        //    //set { radius = value; }
        //}

        //get the list of coodinates for each limit limits 
        public List<Coordinates> limits_coordinates
        {
            get { return Limits; }
            set { Limits = value; }
        }

        public ComponentTypes ComponentType
        {
            get { return ComponentTypes.COMPONENT_LINECOLLISION; }
        }

        public void Close()
        {

        }

    }

    class Coordinates
    {
       public Vector3 PointA;

        public Vector3 PointB;

        public Coordinates(Vector3 A, Vector3 B)
        {
            PointA = A;

            PointB = B;                 
        }

        public float X_A()
        {
            return PointA.X;
        }

        public float X_B()
        {
            return PointB.X;
        }

        public float Y_A()
        {
            return PointA.Y;
        }

        public float Y_B()
        {
            return PointB.Y;
        }

        public float Z_A()
        {
            return PointA.Z;
        }

        public float Z_B()
        {
            return PointB.Z;
        }

    }
    
    
        //Vector 3 X, Y, Z
    
}
