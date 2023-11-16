**App Secrets**

- [What is an app secret?](#what-is-an-app-secret)
- [Database connection strings](#database-connection-strings)

# What is an app secret?

Never store a password or other sensitive values in your source code and secrets like those should never be deployed with the app. Instead, get those values from an environment variable or a secret management system like: 

- [Secret Manager](https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets) for local development secrets.
- [Azure Key Vault](https://learn.microsoft.com/en-us/azure/key-vault/general/overview) for cloud and production secrets.

> **Good Practice**: Equally, never use production secrets for development or test. If you do, you might end up accidently deleting the production database like this Junior Software Developer on the first day of his job: https://www.reddit.com/r/cscareerquestions/comments/6ez8ag/accidentally_destroyed_production_database_on/. 

Instead, production secrets should be accessed through a controlled means like environment variables or Azure Key Vault. 

# Database connection strings

Connection strings: https://learn.microsoft.com/en-us/ef/core/miscellaneous/connection-strings
