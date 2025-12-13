# GameApp-API

### ⚙️ Run migrations

Run the following commands in the GameApp root directory for Entity Framework migrations:

Add a new migration:

```bash
dotnet ef migrations add <Migration-Name> -s GameApp.API -p GameApp.Infrastructure
```

Apply Database schema:

```bash
dotnet ef database update -s GameApp.API -p GameApp.Infrastructure
```

Remove the last migration:

```bash
dotnet ef remove -s GameApp.API -p GameApp.Infrastructure
```


### ⚙️ Set environment variables to use Cloudinary services:

Initialize User Secrets

```bash
dotnet user-secrets init
```

### Run the following commands int the GameApp.API directory to set the environment variables:

Set Cloudinary Credentials In Development Mode:

```bash
dotnet user-secrets set "CloudinarySettings:CloudName" <Your-cloud-name>
dotnet user-secrets set "CloudinarySettings:ApiKey" <Your-api-key>
dotnet user-secrets set "CloudinarySettings:ApiSecret" <Your-api-secret>
```

Run this command to verify if the user secrets are correctly set:

```bash
dotnet user-secrets list
```

### 🚀 Running the project:

Use this command in the GameApp.API directory:

```bash
dotnet watch run
```