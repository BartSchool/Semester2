namespace VPT.Core.Classes;

public class person
{
    public bool adult { get; private set; }
    public int age { get; private set; }
    public string name { get; private set; }
    public DateOnly birthDate { get; private set; }

    public person(string name, int age,  DateOnly birthDate)
    {
        this.age = age;
        this.name = name;
        this.birthDate = birthDate;
        if (age > 12)
            this.adult = true;
    }
}
