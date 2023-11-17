**Errata** (1 item)

If you find any mistakes, then please [raise an issue in this repository](https://github.com/markjprice/cs12dotnet8/issues) or email me at markjprice (at) gmail.com.

- [Page 53 - Understanding .NET runtime and .NET SDK versions](#page-53---understanding-net-runtime-and-net-sdk-versions)


# Page 53 - Understanding .NET runtime and .NET SDK versions

> Thanks to a reader who contacted my publisher Packt on November 16, 2023 about this issue.

I wrote, ".NET SDK versioning does not follow semantic versioning. The major and minor version numbers are
tied to the runtime version it is matched with. The patch number follows a convention that indicates
the major and minor versions of the SDK."

But the patch number is not created from the major and minor versions of the SDK. It is created from the minor and patch versions of the SDK.

I should have written, ".NET SDK versioning does not follow semantic versioning. The major and minor version numbers are
tied to the runtime version it is matched with. The third number follows a convention that indicates
the minor and patch versions of the SDK. The minor number is multiplied by 100 and added to the patch number."
