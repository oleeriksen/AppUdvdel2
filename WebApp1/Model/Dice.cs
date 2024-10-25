namespace WebApp1.Model;

public class Dice
{
    private int _eyes;

    private int _size;
    private Random _random; 

    public Dice()
    {
        _random = new Random();
        _size = 6;
    }

    public Dice(int size)
    {
        _random = new Random();
        _size = size;
    }

    public virtual void Roll()
    {
        _eyes = _random.Next(_size)+1;
    }

    public int GetEyes()
    {
        return _eyes;
    }
}