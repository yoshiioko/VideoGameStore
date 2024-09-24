# Video Game Store API

## Configuration

### User Secrets
Navigate to the directory of the project file. Run this command to initialize User Secrets.

``` shell
dotnet user-secrets init
```

Now save the Connecting String to the Secrets Store

``` shell
db_password="db-password-here"

dotnet user-secrets set "ConnectionStrings:DbContext" "Host=localhost;Username=admin;Password=$db_password;Database=postgres"
```

Verify the Connection String has been saved by using this command

```shell
dotnet user-secrets list
```

### .env
Before deploying the docker image, you need to configure the following values in the [.env](.env) file.
- POSTGRES_USER
- POSTGRES_PW
- POSTGRES_DB (can be default value)
- PGADMIN_MAIL
- PGADMIN_PW

## Deploy with docker compose
When deploying this setup, the pgAdmin web interface will be available at port 5050 (e.g. http://localhost:5050).  

``` shell
$ docker compose up
Starting postgres ... done
Starting pgadmin ... done
```

## Add postgres database to pgAdmin
After logging in with your credentials of the .env file, you can add your database to pgAdmin. 
1. Right-click "Servers" in the top-left corner and select "Create" -> "Server..."
2. Name your connection
3. Change to the "Connection" tab and add the connection details:
- Hostname: "postgres" (this would normally be your IP address of the postgres database - however, docker can resolve this container ip by its name)
- Port: "5432"
- Maintenance Database: $POSTGRES_DB (see .env)
- Username: $POSTGRES_USER (see .env)
- Password: $POSTGRES_PW (see .env)

## Stopping Containers

Stop the containers with
``` shell
$ docker compose down
# To delete all data run:
$ docker compose down -v
```

## More Recipes

Special thanks to the contributors to the Awesome-Compose project. Check out their 
repository for more helpful samples [here](https://github.com/docker/awesome-compose/tree/master).
