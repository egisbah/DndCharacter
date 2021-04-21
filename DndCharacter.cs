using System;
using System.Linq;


public class DndCharacter
{
    public int Strength { get; }
    public int Dexterity { get; }
    public int Constitution { get; }
    public int Intelligence { get; }
    public int Wisdom { get; }
    public int Charisma { get; }
    public int Hitpoints { get; }

    public static int Modifier(int score)
    {
        int modifier = (int)Math.Floor((score - 10) * 0.5);
        return modifier;
    }

    public static int Ability()
    {
        int[] dieRolls = { dieRoll(), dieRoll(), dieRoll(), dieRoll() };
        int abilityLevel = dieRolls.OrderByDescending(X => X)
            .Take(3)
            .Sum();
        return abilityLevel;
    }

    static readonly Random random = new Random();

    private static int dieRoll()
    {
        return random.Next(1, 7);
    }

    public DndCharacter Generate()
    {
        Strength = Ability();
        Dexterity = Ability();
        Constitution = Ability();
        Intelligence = Ability();
        Wisdom = Ability();
        Charisma = Ability();
        Hitpoints = 10 + Modifier(Constitution);
    }
}
