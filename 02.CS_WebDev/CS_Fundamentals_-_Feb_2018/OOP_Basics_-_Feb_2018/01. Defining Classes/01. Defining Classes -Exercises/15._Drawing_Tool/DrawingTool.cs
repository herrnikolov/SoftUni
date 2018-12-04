public class DrawingTool
{
    private Quadrangle quadrangle;

    public DrawingTool(Quadrangle quadrangle)
    {
        this.quadrangle = quadrangle;
    }

    public void Draw()
    {
        this.quadrangle.DrawQuadrangle();
    }
}