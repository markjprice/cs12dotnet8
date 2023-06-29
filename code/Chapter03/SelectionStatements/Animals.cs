class Animal // This is the base type for all animals.
{
  public string? Name;
  public DateTime Born;
  public byte Legs;
}

class Cat : Animal // This is a subtype of animal.
{
  public bool IsDomestic;
}

class Spider : Animal // This is another subtype of animal.
{
  public bool IsPoisonous;
}
