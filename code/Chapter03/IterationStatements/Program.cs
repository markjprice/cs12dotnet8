#region Looping with the while statement

int x = 0;
while (x < 10)
{
  WriteLine(x);
  x++;
}

#endregion

#region Looping with the do statement

string? actualPassword = "Pa$$w0rd";
string? password;
int maximumAttempts = 3;
int attempts = 0;

do
{
  Write("Enter your password: ");
  password = ReadLine();
  attempts++;
}
while ((password != actualPassword) & (attempts < maximumAttempts));

if (password == actualPassword)
{
  WriteLine("Correct!");
}
else
{
  WriteLine("You have used {0} attempts! The password was {1}.",
    arg0: maximumAttempts, arg1: actualPassword);
}

#endregion

#region Looping with the for statement

for (int y = 1; y <= 10; y++)
{
  WriteLine(y);
}

for (int y = 0; y <= 10; y += 3)
{
  WriteLine(y);
}

#endregion

#region Looping with the foreach statement

string[] names = { "Adam", "Barry", "Charlie" };

foreach (string name in names)
{
  WriteLine($"{name} has {name.Length} characters.");
}

#endregion

