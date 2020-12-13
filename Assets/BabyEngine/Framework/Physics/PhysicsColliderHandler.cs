using UnityEngine;
using XLua;

[LuaCallCSharp]
public class PhysicsColliderHandler : MonoBehaviour {
    #region 触发器
    public LuaFunction onTriggerEnter;
    public LuaFunction onTriggerExit;
    public LuaFunction onTriggerStay;
    private void OnTriggerEnter( Collider other )
    {
        onTriggerEnter?.Call(other,gameObject);
    }

    private void OnTriggerExit( Collider other ) {
        onTriggerExit?.Call(other,gameObject);
    }

    private void OnTriggerStay( Collider other ) {
        onTriggerStay?.Call(other,gameObject);
    }
    #endregion

    #region 2D触发器
    public LuaFunction onTriggerEnter2D;
    public LuaFunction onTriggerExit2D;
    public LuaFunction onTriggerStay2D;
    private void OnTriggerEnter2D( Collider2D collision )
    {
        onTriggerEnter2D?.Call(collision,gameObject);
    }
    private void OnTriggerExit2D( Collider2D collision )
    {
        onTriggerExit2D?.Call(collision,gameObject);
    }
    private void OnTriggerStay2D( Collider2D collision )
    {
        onTriggerStay2D?.Call(collision,gameObject);
    }
    #endregion
    #region Collision
    public LuaFunction onCollisionEnter;
    public LuaFunction onCollisionExit;
    public LuaFunction onCollisionStay;
    private void OnCollisionEnter( Collision collision )
    {
        onCollisionEnter?.Call(collision,gameObject);
    }

    private void OnCollisionExit( Collision collision )
    {
        onCollisionExit?.Call(collision,gameObject);
    }

    private void OnCollisionStay( Collision collision )
    {
        onCollisionStay?.Call(collision,gameObject);
    }
    #endregion
    #region 2D Collistion
    public LuaFunction onCollisionEnter2D;
    public LuaFunction onCollisionExit2D;
    public LuaFunction onCollisionStay2D;
    private void OnCollisionEnter2D( Collision2D collision )
    {
        onCollisionEnter2D?.Call(collision,gameObject);
    }

    private void OnCollisionExit2D( Collision2D collision )
    {
        onCollisionExit2D?.Call(collision,gameObject);
    }

    private void OnCollisionStay2D( Collision2D collision )
    {
        onCollisionStay2D?.Call(collision,gameObject);
    }
    #endregion
}
