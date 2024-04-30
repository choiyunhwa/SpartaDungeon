public class ChoiseJob
{
    public Warrior Warrior { get; private set; }
    public Wizard Wizard { get; private set; }

    public ChoiseJob(string name, int num)
    {
        switch (num)
        {
            case 1:
                Warrior = new Warrior(name, "Warrior", 1, 10, 10, 100, 50, 15000);
                break;
            case 2:
                Wizard = new Wizard(name, "Wizard", 1, 5, 5, 80, 100, 15000);
                break;
        }
    }
}


