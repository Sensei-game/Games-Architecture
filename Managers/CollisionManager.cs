using OpenGL_Game.Objects;
using OpenGL_Game.Scenes;
using OpenTK;
using OpenGL_Game.Components;



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
        
               
        private bool invincible = false;
        public override void ProcessCollision(Entity entity)
        {
            ComponentGeometry geometry = (ComponentGeometry)entity.GetGeometry<ComponentGeometry>();
            ComponentPosition position = (ComponentPosition)entity.GetPosition<ComponentPosition>();
            ComponentAudio Audio = entity.GetComponent<ComponentAudio>();

            switch (entity.Name)
            {
                //Add more Points
                case "Blue 1":

                    //gameInstance.camera.cameraPosition = gameInstance.oldposition; /*new Vector3(0.0f, 1.0f, 0.0f);*/
                                        
                    Superstate();//No Superstate for Yellow Points

                    //PlaySound will also update position

                    Remove(entity.Name, Audio, geometry);
                    
                    break;

                case "Blue 2":

                    //gameInstance.camera.cameraPosition = gameInstance.oldposition; /*new Vector3(0.0f, 1.0f, 0.0f);*/

                    Superstate();//No Superstate for Yellow Points

                    //PlaySound will also update position

                    Remove(entity.Name, Audio, geometry);

                    break;

                case "Blue 3":

                    //gameInstance.camera.cameraPosition = gameInstance.oldposition; /*new Vector3(0.0f, 1.0f, 0.0f);*/

                    Superstate();//No Superstate for Yellow Points

                    //PlaySound will also update position

                    Remove(entity.Name, Audio, geometry);

                    break;

                case "Blue 4":

                    //gameInstance.camera.cameraPosition = gameInstance.oldposition; /*new Vector3(0.0f, 1.0f, 0.0f);*/

                    Superstate();//No Superstate for Yellow Points

                    //PlaySound will also update position

                    Remove(entity.Name, Audio, geometry);

                    break;

                case "Blue 5":

                    //gameInstance.camera.cameraPosition = gameInstance.oldposition; /*new Vector3(0.0f, 1.0f, 0.0f);*/

                    Superstate();//No Superstate for Yellow Points

                    //PlaySound will also update position

                    Remove(entity.Name, Audio, geometry);

                    break;

                case "Yellow 1":

                    //gameInstance.camera.cameraPosition = gameInstance.oldposition; /*new Vector3(0.0f, 1.0f, 0.0f);*/

                    //PlaySound will also update position
                    Remove(entity.Name, Audio, geometry);

                    break;

                case "Yellow 2":

                    //gameInstance.camera.cameraPosition = gameInstance.oldposition; /*new Vector3(0.0f, 1.0f, 0.0f);*/

                    //PlaySound will also update position
                    Remove(entity.Name, Audio, geometry);

                    break;

                case "Yellow 3":

                    //gameInstance.camera.cameraPosition = gameInstance.oldposition; /*new Vector3(0.0f, 1.0f, 0.0f);*/

                    //PlaySound will also update position
                    Remove(entity.Name, Audio, geometry);

                    break;

                case "Yellow 4":

                    //gameInstance.camera.cameraPosition = gameInstance.oldposition; /*new Vector3(0.0f, 1.0f, 0.0f);*/

                    //PlaySound will also update position
                    Remove(entity.Name, Audio, geometry);

                    break;

                case "Yellow 5":

                    //gameInstance.camera.cameraPosition = gameInstance.oldposition; /*new Vector3(0.0f, 1.0f, 0.0f);*/

                    //PlaySound will also update position
                    Remove(entity.Name, Audio, geometry);

                    break;

                case "Yellow 6":

                    //gameInstance.camera.cameraPosition = gameInstance.oldposition; /*new Vector3(0.0f, 1.0f, 0.0f);*/

                    //PlaySound will also update position
                    Remove(entity.Name, Audio, geometry);

                    break;

                case "Yellow 7":

                    //gameInstance.camera.cameraPosition = gameInstance.oldposition; /*new Vector3(0.0f, 1.0f, 0.0f);*/

                    //PlaySound will also update position
                    Remove(entity.Name, Audio, geometry);

                    break;

                case "Yellow 8":

                    //gameInstance.camera.cameraPosition = gameInstance.oldposition; /*new Vector3(0.0f, 1.0f, 0.0f);*/

                    //PlaySound will also update position
                    Remove(entity.Name, Audio, geometry);

                    break;

                case "Yellow 9":

                    //gameInstance.camera.cameraPosition = gameInstance.oldposition; /*new Vector3(0.0f, 1.0f, 0.0f);*/

                    //PlaySound will also update position
                    Remove(entity.Name, Audio, geometry);

                    break;

                case "Yellow 10":

                    //gameInstance.camera.cameraPosition = gameInstance.oldposition; /*new Vector3(0.0f, 1.0f, 0.0f);*/

                    //PlaySound will also update position
                    Remove(entity.Name, Audio, geometry);

                    break;

                case "Yellow 11":

                    //gameInstance.camera.cameraPosition = gameInstance.oldposition; /*new Vector3(0.0f, 1.0f, 0.0f);*/

                    //PlaySound will also update position
                    Remove(entity.Name, Audio, geometry);

                    break;

                case "Yellow 12":

                    //gameInstance.camera.cameraPosition = gameInstance.oldposition; /*new Vector3(0.0f, 1.0f, 0.0f);*/

                    //PlaySound will also update position
                    Remove(entity.Name, Audio, geometry);

                    break;

                case "Yellow 13":

                    //gameInstance.camera.cameraPosition = gameInstance.oldposition; /*new Vector3(0.0f, 1.0f, 0.0f);*/

                    //PlaySound will also update position
                    Remove(entity.Name, Audio, geometry);

                    break;

                case "Yellow 14":

                    //gameInstance.camera.cameraPosition = gameInstance.oldposition; /*new Vector3(0.0f, 1.0f, 0.0f);*/

                    //PlaySound will also update position
                    Remove(entity.Name, Audio, geometry);

                    break;

                case "Yellow 15":

                    //gameInstance.camera.cameraPosition = gameInstance.oldposition; /*new Vector3(0.0f, 1.0f, 0.0f);*/

                    //PlaySound will also update position
                    Remove(entity.Name, Audio, geometry);

                    break;

                case "Yellow 16":

                    //gameInstance.camera.cameraPosition = gameInstance.oldposition; /*new Vector3(0.0f, 1.0f, 0.0f);*/

                    //PlaySound will also update position
                    Remove(entity.Name, Audio, geometry);

                    break;

                case "Yellow 17":

                    //gameInstance.camera.cameraPosition = gameInstance.oldposition; /*new Vector3(0.0f, 1.0f, 0.0f);*/

                    //PlaySound will also update position
                    Remove(entity.Name, Audio, geometry);

                    break;

                case "Yellow 18":

                    //gameInstance.camera.cameraPosition = gameInstance.oldposition; /*new Vector3(0.0f, 1.0f, 0.0f);*/

                    //PlaySound will also update position
                    Remove(entity.Name, Audio, geometry);

                    break;

                case "Yellow 19":

                    //gameInstance.camera.cameraPosition = gameInstance.oldposition; /*new Vector3(0.0f, 1.0f, 0.0f);*/

                    //PlaySound will also update position
                    Remove(entity.Name, Audio, geometry);

                    break;

                case "Yellow 20":

                    //gameInstance.camera.cameraPosition = gameInstance.oldposition; /*new Vector3(0.0f, 1.0f, 0.0f);*/

                    //PlaySound will also update position
                    Remove(entity.Name, Audio, geometry);

                    break;

                case "Yellow 21":

                    //gameInstance.camera.cameraPosition = gameInstance.oldposition; /*new Vector3(0.0f, 1.0f, 0.0f);*/

                    //PlaySound will also update position
                    Remove(entity.Name, Audio, geometry);

                    break;

                case "Yellow 22":

                    //gameInstance.camera.cameraPosition = gameInstance.oldposition; /*new Vector3(0.0f, 1.0f, 0.0f);*/

                    //PlaySound will also update position
                    Remove(entity.Name, Audio, geometry);

                    break;

                case "Yellow 23":

                    //gameInstance.camera.cameraPosition = gameInstance.oldposition; /*new Vector3(0.0f, 1.0f, 0.0f);*/

                    //PlaySound will also update position
                    Remove(entity.Name, Audio, geometry);

                    break;

                case "Yellow 24":

                    //gameInstance.camera.cameraPosition = gameInstance.oldposition; /*new Vector3(0.0f, 1.0f, 0.0f);*/

                    //PlaySound will also update position
                    Remove(entity.Name, Audio, geometry);

                    break;

                case "Yellow 25":

                    //gameInstance.camera.cameraPosition = gameInstance.oldposition; /*new Vector3(0.0f, 1.0f, 0.0f);*/

                    //PlaySound will also update position
                    Remove(entity.Name, Audio, geometry);

                    break;

                case "Yellow 26":

                    //gameInstance.camera.cameraPosition = gameInstance.oldposition; /*new Vector3(0.0f, 1.0f, 0.0f);*/

                    //PlaySound will also update position
                    Remove(entity.Name, Audio, geometry);

                    break;

                case "Yellow 27":

                    //gameInstance.camera.cameraPosition = gameInstance.oldposition; /*new Vector3(0.0f, 1.0f, 0.0f);*/

                    //PlaySound will also update position
                    Remove(entity.Name, Audio, geometry);

                    break;

                case "Yellow 28":

                    //gameInstance.camera.cameraPosition = gameInstance.oldposition; /*new Vector3(0.0f, 1.0f, 0.0f);*/

                    //PlaySound will also update position
                    Remove(entity.Name, Audio, geometry);

                    break;

                case "Yellow 29":

                    //gameInstance.camera.cameraPosition = gameInstance.oldposition; /*new Vector3(0.0f, 1.0f, 0.0f);*/

                    //PlaySound will also update position
                    Remove(entity.Name, Audio, geometry);

                    break;

                case "Yellow 30":

                    //gameInstance.camera.cameraPosition = gameInstance.oldposition; /*new Vector3(0.0f, 1.0f, 0.0f);*/

                    //PlaySound will also update position
                    Remove(entity.Name, Audio, geometry);

                    break;

                case "Yellow 31":

                    //gameInstance.camera.cameraPosition = gameInstance.oldposition; /*new Vector3(0.0f, 1.0f, 0.0f);*/

                    //PlaySound will also update position
                    Remove(entity.Name, Audio, geometry);

                    break;

                case "Yellow 32":

                    //gameInstance.camera.cameraPosition = gameInstance.oldposition; /*new Vector3(0.0f, 1.0f, 0.0f);*/

                    //PlaySound will also update position
                    Remove(entity.Name, Audio, geometry);

                    break;

                case "Yellow 33":

                    //gameInstance.camera.cameraPosition = gameInstance.oldposition; /*new Vector3(0.0f, 1.0f, 0.0f);*/

                    //PlaySound will also update position
                    Remove(entity.Name, Audio, geometry);

                    break;

                case "Yellow 34":

                    //gameInstance.camera.cameraPosition = gameInstance.oldposition; /*new Vector3(0.0f, 1.0f, 0.0f);*/

                    //PlaySound will also update position
                    Remove(entity.Name, Audio, geometry);

                    break;

                case "Yellow 35":

                    //gameInstance.camera.cameraPosition = gameInstance.oldposition; /*new Vector3(0.0f, 1.0f, 0.0f);*/

                    //PlaySound will also update position
                    Remove(entity.Name, Audio, geometry);

                    break;

                case "Yellow 36":

                    //gameInstance.camera.cameraPosition = gameInstance.oldposition; /*new Vector3(0.0f, 1.0f, 0.0f);*/

                    //PlaySound will also update position
                    Remove(entity.Name, Audio, geometry);

                    break;

                case "Yellow 37":

                    //gameInstance.camera.cameraPosition = gameInstance.oldposition; /*new Vector3(0.0f, 1.0f, 0.0f);*/

                    //PlaySound will also update position
                    Remove(entity.Name, Audio, geometry);

                    break;

                case "Yellow 38":

                    //gameInstance.camera.cameraPosition = gameInstance.oldposition; /*new Vector3(0.0f, 1.0f, 0.0f);*/

                    //PlaySound will also update position
                    Remove(entity.Name, Audio, geometry);

                    break;

                case "Ghost 1":

                    if (invincible == false)
                    {
                        position.Position = new Vector3(5.0f, 0.0f, 0.0f);
                        gameInstance.camera.cameraPosition = new Vector3(0.0f, 1.0f, -15.0f);

                        //Reset Ghost Position too
                        //Play Sound
                        Audio.PlayDeath();
                        --gameInstance.life;
                    }
                    else
                    {
                        position.Position = new Vector3(5.0f, 0.0f, 0.0f); // change to first Node
                        invincible = false;
                        //PlaySound
                        Audio.Playonce();

                        gameInstance.score += 10;

                    }
                    break;

                case "Ghost 2":

                    if (invincible == false)
                    {
                        position.Position = new Vector3(-5.50f, 0.1f, 9.50f);
                        gameInstance.camera.cameraPosition = new Vector3(0.0f, 1.0f, -15.0f);

                        //Reset Ghost Position too
                        //Play Sound
                        Audio.PlayDeath();
                        --gameInstance.life;
                    }
                    else
                    {
                        position.Position = new Vector3(-5.50f, 0.1f, 9.50f); // change to first Node
                        invincible = false;
                        //PlaySound
                        Audio.Playonce();

                        gameInstance.score += 10;

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

        private void Remove(string name, ComponentAudio entityAudio,  ComponentGeometry geometry)
        {
            entityAudio.Playonce();
            ++gameInstance.score;
            ++gameInstance.count;
            gameInstance.entityManager.DeleteEntity(name);
            geometry.NullGeometry();
        }

 
    }

    class LineCollisionManager : CollisionManager
    {
        GameScene gameInstance = GameScene.gameInstance;
        public static bool debug_line = false;
        public override void ProcessCollision(Entity entity)
        {
            switch (entity.Name)
            {
                case "Maze":

                    if (debug_line == false)
                    {
                        //Bool something is false Debug blah blah
                        gameInstance.camera.cameraPosition = gameInstance.oldposition;
                    }
                    break;

                default: break;

            }
        }


    }

}
