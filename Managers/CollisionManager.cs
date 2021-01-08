using OpenGL_Game.Objects;
using OpenGL_Game.Scenes;
using OpenTK;
using OpenGL_Game.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenGL_Game.Components;
using OpenGL_Game.Systems;

namespace OpenGL_Game.Managers
{
    abstract class CollisionManager
    {
        // Add all types of collisions
        enum Collisiontypes
        {
            SphereCollision,
            LineColliison
        }

        struct Elements
        {
            Entity entity;
            Collisiontypes type;
        }

        //public void CollisionCamera(Entity entity, )
        //{





        //}

        public abstract void ProcessCollision(Entity entity);

        // line/line

        //circle/circle

        // line/circle



        ///
        //bool lineCircle(float x1, float y1, float x2, float y2, float cx, float cy, float r)
        //{

        //    // is either end INSIDE the circle?
        //    // if so, return true immediately
        //    bool inside1 = pointCircle(x1, y1, cx, cy, r);
        //    bool inside2 = pointCircle(x2, y2, cx, cy, r);
        //    if (inside1 || inside2) return true;

        //    // get length of the line
        //    float distX = x1 - x2;
        //    float distY = y1 - y2;
        //    float len = ((distX * distX) + (distY * distY));

        //    // get dot product of the line and circle
        //    float dot = (((cx - x1) * (x2 - x1)) + ((cy - y1) * (y2 - y1))) / pow(len, 2);

        //    // find the closest point on the line
        //    float closestX = x1 + (dot * (x2 - x1));
        //    float closestY = y1 + (dot * (y2 - y1));

        //    // is this point actually on the line segment?
        //    // if so keep going, but if not, return false
        //    bool onSegment = linePoint(x1, y1, x2, y2, closestX, closestY);
        //    if (!onSegment) return false;



        //    // get distance to closest point
        //    distX = closestX - cx;
        //    distY = closestY - cy;
        //    float distance = sqrt((distX * distX) + (distY * distY));

        //    if (distance <= r)
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        ///
        //bool linePoint(float x1, float y1, float x2, float y2, float px, float py)
        //{

        //    // get distance from the point to the two ends of the line
        //    float d1 = dist(px, py, x1, y1);
        //    float d2 = dist(px, py, x2, y2);

        //    // get the length of the line
        //    float lineLen = dist(x1, y1, x2, y2);

        //    // since floats are so minutely accurate, add
        //    // a little buffer zone that will give collision
        //    float buffer = 0.1f;    // higher # = less accurate

        //    // if the two distances are equal to the line's
        //    // length, the point is on the line!
        //    // note we use the buffer here to give a range,
        //    // rather than one #
        //    if (d1 + d2 >= lineLen - buffer && d1 + d2 <= lineLen + buffer)
        //    {
        //        return true;
        //    }

        //    // circle/square
        //}
    }

    class SphereCollisionManager : CollisionManager
    {
        GameScene gameInstance = GameScene.gameInstance;
       


        private bool removed = false;
        private bool invincible = false;
        public override void ProcessCollision(Entity entity)
        {
            ComponentAudio Audio = (ComponentAudio)entity.GetComponent<ComponentAudio>();
            ComponentPosition position = (ComponentPosition)entity.GetPosition<ComponentPosition>();
            ComponentGeometry Geometry = (ComponentGeometry)entity.GetGeometry<ComponentGeometry>();

            switch (entity.Name)
            {
                //Add more Points
                case "Moon":
                    if (removed == false)
                    {
                        gameInstance.camera.cameraPosition = gameInstance.oldposition; /*new Vector3(0.0f, 1.0f, 0.0f);*/

                        Superstate();//No Superstate for Yellow Points

                        //PlaySound will also update position

                        Remove(Audio, position, Geometry);
                    }
                    break;

                case "Wraith_Raider_Starship":
                  
                    if (invincible == false)
                    {
                        gameInstance.camera.cameraPosition = new Vector3(0.0f, 1.0f, -15.0f);
                        --gameInstance.life;
                    }
                    else
                    {
                        position.Position = new Vector3(5.0f, 0.0f, 0.0f); // change to first Node
                        invincible = false;
                    }
                    break;

                default: break;
            }
        }

        private void Superstate()
        {
           // gameInstance.camera.Radius = 0.0f;
            invincible = true;
        }

        private void Remove(ComponentAudio entityAudio, ComponentPosition entityPosition, ComponentGeometry componentGeometry)
        {
            entityAudio.PlaySound(entityPosition.Position);
            ++gameInstance.score;
            componentGeometry.Geometry().RemoveGeometry();
            removed = true;
        }
    }

    class LineCollisionManager : CollisionManager
    {
        GameScene gameInstance = GameScene.gameInstance;

        public override void ProcessCollision(Entity entity)
        {
            switch (entity.Name)
            {
                case "Maze":
                    gameInstance.camera.cameraPosition = gameInstance.oldposition;
                    break;

                default: break;

            }
        }


    }

}
