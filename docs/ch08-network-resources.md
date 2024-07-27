**Working with network resources**

- [Introducing network resources](#introducing-network-resources)
- [Working with URIs, DNS, and IP addresses](#working-with-uris-dns-and-ip-addresses)
- [Pinging a server](#pinging-a-server)
- [.NET 7 Networking Improvements](#net-7-networking-improvements)


# Introducing network resources

Sometimes you will need to work with network resources. The most common types in .NET for working with network resources are shown in the following table:

Namespace|Example type(s)|Description
---|---|---
`System.Net`|`Dns`, `Uri`, `Cookie`, `WebClient`, `IPAddress`|These are for working with DNS servers, URIs, IP addresses and so on.
`System.Net`|`FtpStatusCode`, `FtpWebRequest`, `FtpWebResponse`|These are for working with TCP servers.
`System.Net`|`HttpStatusCode`, `HttpWebRequest`, `HttpWebResponse`|These are for working with HTTP servers; that is, websites and services. Types from `System.Net.Http` are easier to use.
`System.Net.Http`|`HttpClient`, `HttpMethod`, `HttpRequestMessage`, `HttpResponseMessage`|These are for working with HTTP servers; that is, websites and services. You will learn how to use these in *Chapter 14, Building and Consuming Web Services*.
`System.Net.Mail`|`Attachment`, `MailAddress`, `MailMessage`, `SmtpClient`|These are for working with SMTP servers; that is, sending email messages.
`System.Net.NetworkInformation`|`IPStatus`, `NetworkChange`, `Ping`, `TcpStatistics`|These are for working with low-level network protocols.

# Working with URIs, DNS, and IP addresses

Let's explore some common types for working with network resources:
1.	Use your preferred code editor to add a new **Console App** / `console` project named `WorkingWithNetworkResources` to the `Chapter08` solution.
2.	In `Program.cs`, delete the existing statements and then import the namespace for working with a network, as shown in the folowing code:
```cs
using System.Net; // To use IPHostEntry, Dns, IPAddress.
```

3.	In `Program.cs`, add statements to prompt the user to enter a website address, and then use the `Uri` type to break it down into its parts, including the scheme (HTTP, FTP, and so on), port number, and host, as shown in the following code:
```cs
Write("Enter a valid web address (or press Enter): "); 
string? url = ReadLine();

if (string.IsNullOrWhiteSpace(url)) // If they enter nothing...
{
  // ... then set a default URL.
  url = "https://stackoverflow.com/search?q=securestring";
}

Uri uri = new(url);
WriteLine($"URL: {url}"); 
WriteLine($"Scheme: {uri.Scheme}"); 
WriteLine($"Port: {uri.Port}"); 
WriteLine($"Host: {uri.Host}"); 
WriteLine($"Path: {uri.AbsolutePath}"); 
WriteLine($"Query: {uri.Query}");
```

4.	Run the code, enter a valid website address or press *Enter*, and view the result, as shown in the following output:
```
Enter a valid web address (or press Enter):
URL: https://stackoverflow.com/search?q=securestring 
Scheme: https
Port: 443
Host: stackoverflow.com 
Path: /search
Query: ?q=securestring
```

5.	In `Program.cs`, add statements to get the IP address for the entered website, as shown in the folowing code:
```cs
IPHostEntry entry = Dns.GetHostEntry(uri.Host); 

WriteLine($"{entry.HostName} has the following IP addresses:"); 

foreach (IPAddress address in entry.AddressList)
{
  WriteLine($"  {address} ({address.AddressFamily})");
}
```

6.	Run the code, enter a valid website address or press *Enter*, and view the result, as shown in the following output:
```
stackoverflow.com has the following IP addresses: 
  151.101.1.69 (InterNetwork)
  151.101.65.69 (InterNetwork)
  151.101.129.69 (InterNetwork)
  151.101.193.69 (InterNetwork)
```

# Pinging a server

Now you will add code to ping a web server to check its health:
1.	In `Program.cs`, import the namespace to get more information about networks, as shown in the folowing code:
```cs
using System.Net.NetworkInformation; // To use Ping and so on.
```

2.	Add statements to ping the entered website, as shown in the following code:
```cs
try
{
  Ping ping = new();

  WriteLine("Pinging server. Please wait...");
  PingReply reply = ping.Send(uri.Host);
  WriteLine($"{uri.Host} was pinged and replied: {reply.Status}.");

  if (reply.Status == IPStatus.Success)
  {
    WriteLine("Reply from {0} took {1:N0}ms", 
      arg0: reply.Address,
      arg1: reply.RoundtripTime);
  }
}
catch (Exception ex)
{
  WriteLine($"{ex.GetType().ToString()} says {ex.Message}");
}
```

3.	Run the code, press *Enter*, and view the result, as shown in the following output:
```
Pinging server. Please wait...
stackoverflow.com was pinged and replied: Success.
Reply from 151.101.193.69 took 9ms
```

4.	Run the code again but this time enter `http://google.com`, as shown in the following output:
```
Enter a valid web address (or press Enter): http://google.com
URL: http://google.com
Scheme: http
Port: 80
Host: google.com
Path: /
Query:
google.com has the following IP addresses:
  2a00:1450:4009:822::200e (InterNetworkV6)
  142.250.180.14 (InterNetwork)
Pinging server. Please wait...
google.com was pinged and replied: Success.
Reply from 2a00:1450:4009:822::200e took 9ms
```

# .NET 7 Networking Improvements

.NET 7 changes in HTTP space, new QUIC APIs, networking security and WebSockets.

https://devblogs.microsoft.com/dotnet/dotnet-7-networking-improvements/
