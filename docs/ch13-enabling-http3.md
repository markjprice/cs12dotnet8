**Enabling HTTP/3 and request decompression support**

- [Introducing HTTP/3](#introducing-http3)
- [Enabling HTTP/3 support](#enabling-http3-support)
- [Introducing request decompression](#introducing-request-decompression)
- [Enabling request decompression support](#enabling-request-decompression-support)

# Introducing HTTP/3

**HTTP/3** uses the same request methods, like `GET` and `POST`, the same status codes, like `200` and `404`, and the same headers, but encodes them and maintains session state differently because it runs over QUIC rather than the older and less efficient Transmission Control Protocol (TCP).

At the time of writing, HTTP/3 is supported by about 75% of actively used web browsers, including Chromium-based browsers like Chrome, Edge, and Opera. It is also supported by Firefox and Safari on macOS and iOS (although it is disabled by default).

HTTP/3 brings benefits to all internet-connected apps, but especially mobile, because it supports connection migration using UDP with TLS built in, so the device does not need to reconnect when moving between WiFi and cellular networks. Each frame of data is encrypted separately so it no longer has the head-of-line blocking problem in HTTP/2 that happens if a TCP packet is lost and therefore all the streams are blocked until the data can be recovered.

# Enabling HTTP/3 support

.NET 6 supported HTTP/3 as a preview feature for both clients and servers. .NET 7 delivered final full support for the following operating systems:
- Windows 11 and Windows Server 2022.
- Linux; you can install QUIC support using sudo apt install libmsquic.

If you have one of the supported operating systems listed above, let's enable HTTP/3 support in the `Northwind.Web` project; otherwise, skip ahead to the next section:

1.	In `Program.cs`, import the namespace for working with HTTP protocols, as shown in the following code:
```cs
using Microsoft.AspNetCore.Server.Kestrel.Core; // To use HttpProtocols.
```
2.	In `Program.cs`, add statements before the call to `Build` to enable all three versions of HTTP, as shown in the following code:
```cs
builder.WebHost.ConfigureKestrel((context, options) =>
{
  options.ListenAnyIP(5131, listenOptions =>
  {
    listenOptions.Protocols = HttpProtocols.Http1AndHttp2AndHttp3;
    listenOptions.UseHttps(); // HTTP/3 requires secure connections.
  });
});
```

> **Good Practice**: You should not just enable HTTP/3 since about 25% of browsers still do not support it or even HTTP/2.

3.	In `appSettings.json`, add an entry to show hosting diagnostics, as shown highlighted in the following configuration:
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning",
      "Microsoft.AspNetCore.Hosting.Diagnostics": "Information"
    }
```
4.	Start the website.
5.	In Chrome, view Developer tools and select the **Network** tab.
6.	Navigate to https://localhost:5131/, and note the **Response Headers** include an entry for `alt-svc` with a value of `h3` indicating HTTP/3 support, as shown in *Figure 13B.1*:

![](assets/B19586_13B_01.png) 
*Figure 13B.1: Chrome showing support for HTTP/3*

7.	In the console or terminal output, note the hosting diagnostics logs, as shown in the following output:
```
info: Microsoft.AspNetCore.Hosting.Diagnostics[1]
      Request starting HTTP/3 GET https://localhost:5131/ - -
info: Microsoft.AspNetCore.Hosting.Diagnostics[2]
      Request finished HTTP/3 GET https://localhost:5131/ - - - 200 - text/html;+charset=utf-8 142.0365ms
warn: Microsoft.AspNetCore.Server.Kestrel[41]
      One or more of the following response headers have been removed because they are invalid for HTTP/2 and HTTP/3 responses: 'Connection', 'Transfer-Encoding', 'Keep-Alive', 'Upgrade' and 'Proxy-Connection'.
```
8.	Close Chrome and shut down the web server.

You can learn more about .NET support for HTTP/3 at the following links:
- HTTP/3 support in .NET: https://devblogs.microsoft.com/dotnet/http-3-support-in-dotnet-6/.
- .NET Networking Improvements – HTTP/3 and QUIC: https://devblogs.microsoft.com/dotnet/dotnet-6-networking-improvements/#http-3-and-quic.
- Use HTTP/3 with the ASP.NET Core Kestrel web server: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/servers/kestrel/http3.

# Introducing request decompression

To make HTTP requests and responses more efficient, the HTTP body content can be compressed using standard algorithms like gzip, Brotli, and Deflate, and an HTTP header is added to indicate which was used.
In the past, the developer had to implement decompression before processing the body if a browser sent a compressed request. With ASP.NET Core 7 or later, middleware to do this for you is built in and just needs to be added to the pipeline.

Unfortunately, this is tricky to try out because browsers cannot initiate a compressed request. This is because the browser cannot know if the server can handle it. Compression is normally enabled by the browser sending an uncompressed request with a header informing the server what algorithms the browser understands, as shown in the following request:
```
Accept-Encoding: gzip, deflate, br, compress
```
The server can then decide to compress its response and it sets a similar header in its response if it does, as shown in the following response:
```
Content-Encoding: gzip
```

# Enabling request decompression support

We will just see how to enable the server side to receive HTTP requests with compressed body content in those rare scenarios where the browser or another client makes one:

1.	In the `Northwind.Web` project, in `Program.cs`, add statements after the call to `AddNorthwindContext` to add the request compression middleware, as shown in the following code:
```cs
builder.Services.AddRequestDecompression();
```
2.	In `Program.cs`, add statements after the call to use HTTPS redirection to use request decompression, as shown in the following code:
```cs
app.UseRequestDecompression();
```
