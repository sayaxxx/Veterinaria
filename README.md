# 🩹 VETERINARIA CAMPUSLAND
## ▶️ USO DEL PROGRAMA

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
## 🔐 GENERACION DEL TOKEN Y REGISTRO USUARIO
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

![image](https://github.com/sayaxxx/veterinaria/assets/133735883/9cf56d96-9b37-4f8c-b782-d08539d442a6)

- Una vez logeados como administradores procedemos a agregar usuarios y esto lo hacemos de la siguiente forma:

```bash
POST

http://localhost:5165/api/veterinaria/usuario/register

{
      "Nombre": "nombreUsuario",
      "password": "password",
      "Email": "email"
}
```

![image](https://github.com/sayaxxx/veterinaria/assets/133735883/841affaf-e9ef-4c9f-9924-7627c9070cc0)

- De esta manera registramos un nuevo usuario de manera exitosa

- Luego de tener el usuario, podemos ir a generar el refresh token, y esto lo hacemos de la siguiente manera:

```bash
POST

http://localhost:5165/api/veterinaria/usuario/refresh-token

{
      "Nombre": "nombreUsuario",
      "password": "password"
}
```
![image](https://github.com/sayaxxx/veterinaria/assets/133735883/0e33fb65-4c99-4597-bd89-29fd61931218)

- Y de esta forma hemos obtenido exitosamente el RefreshToken y ahora si podemos proceder con los endpoints.

## 🥇 ENDPOINTS 1.0 y 1.1 
- Por peticion se pidio que los controlodares pudieran implementar 2 versiones diferentes (Query y Header)

```bash
Para acceder al Query debemos ir al Thunder Client e ingresar lo siguiente en Querys
```

![image](https://github.com/sayaxxx/veterinaria/assets/133735883/02b1da5e-c6aa-433d-bf3f-6bba2514c9de)

```bash
Para acceder al Header tenemos que hacer lo mismo pero esta vez en "Headers"
```

![image](https://github.com/sayaxxx/veterinaria/assets/133735883/c149c144-92d9-4bdc-b639-ddd4af6379f6)


## ⚕️ ENDPOINT 1A

- Crear un consulta que permita visualizar los veterinarios cuya especialidad sea Cirujano vascular.

- IMPORTANTE: Para poder hacer con exito las consultas debemos tener el token del administrador ya que este es el que tiene los privilegios para poder hacerlo.

```bash
GET

http://localhost:5165/api/veterinaria/veterinario/veterinarioCirujano
```
![image](https://github.com/sayaxxx/veterinaria/assets/133735883/ced4d76d-8ed7-4ed9-8df4-1d8ebbef59b4)

## 🥼 ENDPOINT 2A 

- Listar los medicamentos que pertenezcan a el laboratorio Genfar

- IMPORTANTE: Para poder hacer con exito las consultas debemos tener el token del administrador ya que este es el que tiene los privilegios para poder hacerlo.

```bash
GET

http://localhost:5165/api/veterinaria/laboratorio/listarMedicamentosGenfar
```
![image](https://github.com/sayaxxx/veterinaria/assets/133735883/0ea20967-f983-4fcf-bcf6-e19f168ae6ad)

## 🐱 ENPOINT 3A

- Mostrar las mascotas que se encuentren registradas cuya especie sea felina.

- IMPORTANTE: Para poder hacer con exito las consultas debemos tener el token del administrador ya que este es el que tiene los privilegios para poder hacerlo.

```bash
GET

http://localhost:5165/api/veterinaria/mascota/mascotasFelinas
```
![image](https://github.com/sayaxxx/veterinaria/assets/133735883/224c38ad-a753-436b-9cbe-784b7a6a1be8)

## 🦮 ENDPOINT 4A 

- Listar los propietarios y sus mascotas.
- IMPORTANTE: Para poder hacer con exito las consultas debemos tener el token del administrador ya que este es el que tiene los privilegios para poder hacerlo.

```bash
GET

http://localhost:5165/api/veterinaria/propietario/propietariosMascotas
```
![image](https://github.com/sayaxxx/veterinaria/assets/133735883/02bece52-9434-40bb-a35e-9d590dadf362)

## 🛒 ENDPOINT 5A

- Listar los medicamentos que tenga un precio de venta mayor a 50000
- IMPORTANTE: Para poder hacer con exito las consultas debemos tener el token del administrador ya que este es el que tiene los privilegios para poder hacerlo.

```bash
GET

http://localhost:5165/api/veterinaria/medicamento/medicamentosMayor50000
```
![image](https://github.com/sayaxxx/veterinaria/assets/133735883/67c933e8-9a6e-4da4-a365-e3f03501f3c8)

## ⚕️ ENDPOINT 6A
- Listar las mascotas que fueron atendidas por motivo de vacunacion en el primer trimestre del 2023
- IMPORTANTE: Para poder hacer con exito las consultas debemos tener el token del administrador ya que este es el que tiene los privilegios para poder hacerlo.

```bash
GET

http://localhost:5165/api/veterinaria/mascota/vacunacion2023
```
![image](https://github.com/sayaxxx/veterinaria/assets/133735883/8d5abbd8-9e9a-41e2-8a16-1721137f79fd)

## 🐈 ENDPOINT 1B
- Listar todas las mascotas agrupadas por especie.
- IMPORTANTE: Para poder hacer con exito las consultas debemos tener el token del administrador ya que este es el que tiene los privilegios para poder hacerlo.

```bash
GET

http://localhost:5165/api/veterinaria/mascota/mascotasPorEspecie
```
![image](https://github.com/sayaxxx/veterinaria/assets/133735883/3cdb714a-18d0-4d56-bcb6-b2d5ed8a04be)

## 🍌 ENDPOINT 2B 
- Listar todos los movimientos de medicamentos y el valor total de cada movimiento.
- IMPORTANTE: Para poder hacer con exito las consultas debemos tener el token del administrador ya que este es el que tiene los privilegios para poder hacerlo.

```bash
GET

http://localhost:5165/api/veterinaria/movimientoMedicamento/movimientosMedicamentoValor
```

![image](https://github.com/sayaxxx/veterinaria/assets/133735883/b268e53d-1e85-4897-ae90-49fe6b603f18)

## 🚑 ENDPOINT 3B
- Listar las mascotas que fueron atendidas por un determinado veterinario.
- IMPORTANTE: Para poder hacer con exito las consultas debemos tener el token del administrador ya que este es el que tiene los privilegios para poder hacerlo.

```bash
GET

http://localhost:5165/api/veterinaria/mascota/mascotasAtendidasVeterinario
```
![image](https://github.com/sayaxxx/veterinaria/assets/133735883/ac9b6a5c-86eb-4449-bd6c-28de241b94cb)

## ⚗️ ENDPOINT 4B
- Listar los proveedores que me venden un determinado medicamento.
- IMPORTANTE: Para poder hacer con exito las consultas debemos tener el token del administrador ya que este es el que tiene los privilegios para poder hacerlo.

```bash
GET

http://localhost:5165/api/veterinaria/proveedor/medicamentoProveedoresEspe
```
![image](https://github.com/sayaxxx/veterinaria/assets/133735883/660f6e79-0432-4390-abfe-324b1915944a)

## 🐕 ENDPOINT 5B
- Listar las mascotas y sus propietarios cuya raza sea Golden Retriver
- IMPORTANTE: Para poder hacer con exito las consultas debemos tener el token del administrador ya que este es el que tiene los privilegios para poder hacerlo.

```bash
GET

http://localhost:5165/api/veterinaria/propietario/goldenRetriver
```
![image](https://github.com/sayaxxx/veterinaria/assets/133735883/1f21963a-6195-4d90-bf65-7e418528f25c)

## 💔 ENDPOINT 6B
- Listar la cantidad de mascotas que pertenecen a una raza a una raza. Nota: Se debe mostrar una lista de las razas y la cantidad de mascotas que pertenecen a la raza.
- NOTA: Desafurtanadamente no alcance a realizarlo  :(





