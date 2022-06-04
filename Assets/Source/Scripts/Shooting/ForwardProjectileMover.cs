public class ForwardProjectileMover : ProjectileMover
{
    protected override void FixedUpdateMovement()
        => rb.velocity = transform.forward * speed;

    protected override void ResetMover()
    {
    }
}
