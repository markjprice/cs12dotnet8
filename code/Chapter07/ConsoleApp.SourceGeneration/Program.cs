//ConfigureConsole();
ConfigureConsole(culture: "fr-FR");
//ConfigureConsole(useComputerCulture: true);

decimal price = 19.99M;
DateTimeOffset today = DateTimeOffset.Now;

WriteLine($"Today, {today:D}, the price is {price:C}.");

