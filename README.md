# ZDZSTORE
This project uses secrets for sensitive information such as database access data and keys for the JWT. Run the commands below in the terminal within the project directory.

1 -> dotnet user-secrets init

2 -> dotnet user-secrets set "ConnectionStrings:DBConnection" "Server=server;Port=port;Database=database;User Id=root;Password=password" 
        Ex: dotnet user-secrets set "ConnectionStrings:DBConnection" "Server=localhost;Port=5432;Database=zdzstore;User Id=root;Password=root12345"

3 -> dotnet user-secrets set "ConnectionStrings:JWTKey" "jwtkey" 
        Ex: dotnet user-secrets set "ConnectionStrings:JWTKey" "Jn2ieqUaB2H1LZ0eNVNqRaGPe/wLVwiv4eMDJIXu0qc="

        PLEASE NOTE: This application uses HS256 encryption, which requires a key size of 128 bits. You must generate a key that follows this standard in order to generate the JSON Web Token (JWT).