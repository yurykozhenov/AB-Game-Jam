using UnityEngine;

namespace Game.Player.Controller
{
    public class Moving 
    {
        private Rigidbody2D body;
        private float speed;
        
        public void Setup(Rigidbody2D RigitBody, float Speed)
        {
            body = RigitBody;
            speed = Speed;
        }
        
        public void Run(float moveHorizontal)
        {
            body.velocity = new Vector2(moveHorizontal * speed, body.velocity.y);
            
        }
        
        public void Jump(Vector2 Pover)
        {
            body.AddForce(Pover);
        }
    }
}
