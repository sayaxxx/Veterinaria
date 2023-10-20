# VETERINARIA CAMPUSLAND
## USO DEL PROGRAMA

- Clonar el repositorio
- Encender nuestra conexion y/o base de datos
- Correr las migraciones

```bash
  dotnet ef migrations add InitialMigration --project .\Persistencia\ --startup-project .\API\ --output-dir .\data\Migrations
```
- Luego subir la migracion 
```bash
dotnet ef database update --project .\Persistencia\ --startup-project .\API\
```
- Situarnos en cd ./API/ y ejecutar el comando:
```bash
dotnet run
```
## GENERACION DEL TOKEN
- Antes de hacer consultas debemos generar un token para el administrador. Para esto usamos Thunder, Postman o API REST e introducimos lo siguiente:

```bash
POST

http://localhost:5165/api/veterinaria/usuario/token

{
       "Nombre": "admin",
       "password": "123"
}
```
- Si todo esta bien nos deberia aparecer el Token 
