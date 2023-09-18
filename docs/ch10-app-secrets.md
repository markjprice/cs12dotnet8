**App Secrets**

- [What is an app secret?](#what-is-an-app-secret)
- [Database connection strings](#database-connection-strings)

# What is an app secret?

Never store a password or other sensitive values in your source code. Get those values from an environment variable or a secret management system like: 
- [Secret Manager](https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets) for local development secrets.
- [Azure Key Vault](https://learn.microsoft.com/en-us/azure/key-vault/general/overview) for cloud and production secrets.

# Database connection strings

Connection strings: https://learn.microsoft.com/en-us/ef/core/miscellaneous/connection-strings
