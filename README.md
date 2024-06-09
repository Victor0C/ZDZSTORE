# ZDZSTORE
This project uses secrets for sensitive information such as database access data and keys for the JWT. Run the commands below in the terminal within the project directory.

1 -> dotnet user-secrets init

2 -> dotnet user-secrets set "ConnectionStrings:DBConnection" "Server=server;Port=port;Database=database;User Id=root;Password=password" 
        Ex: dotnet user-secrets set "ConnectionStrings:DBConnection" "Server=localhost;Port=5432;Database=zdzstore;User Id=root;Password=root12345"