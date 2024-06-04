# ZDZSTORE
This project uses secrets for sensitive information such as database access data and keys for the JWT. Run the commands below in the terminal within the project directory.

1 -> dotnet user-secrets init

2 -> dotnet user-secrets set "ConnectionStrings:DBConnection" "server=server;database=database;user=user;password=password" 
        Ex: dotnet user-secrets set "ConnectionStrings:DBConnection" "server=localhost;database=zdzstore;user=root;password=root" 