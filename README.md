# 📚 BibliotecaApi - Sistema de Préstamo de Libros

Este proyecto implementa una Web API RESTful en ASP.NET Core para la Biblioteca Municipal "Letras Libres". Permite gestionar libros, usuarios y préstamos de manera eficiente usando Entity Framework Core y SQL Server.

---

## ✅ Tecnologías utilizadas

- ASP.NET Core Web API
- Entity Framework Core
- SQL Server LocalDB
- Swagger (Swashbuckle)
- C#

---

## 🔗 Endpoints de la API

### 📗 LibrosApi

- `GET /api/LibrosApi` – Listar todos los libros

![image](https://github.com/user-attachments/assets/f529993c-5c89-4d82-9966-f5fafe9c1119)

- `POST /api/LibrosApi` – Crear un nuevo libro
#### Correcto
```json
{
  "titulo": "Libro nuevo",
  "autor": "Autor",
  "prestado": false
}
```
![image](https://github.com/user-attachments/assets/ea9f4811-9daf-4016-80e1-d38f1300fc97)
#### Incorrecto
```json
{
  "autor": "Autor",
  "prestado": false
}
```
![image](https://github.com/user-attachments/assets/4114ab1b-c19a-4386-bc46-18ac75232c95)


- `GET /api/LibrosApi/{id}` – Obtener libro por ID
#### Correcto

![image](https://github.com/user-attachments/assets/e2322c4e-0491-4948-8388-e1ee66bb8b08)

#### Incorrecto
Se busco el id 1 que es inexistente

![image](https://github.com/user-attachments/assets/d741b0a6-02ba-49db-81d7-150d3e0945b1)

- `PUT /api/LibrosApi/{id}` – Actualizar un libro
```json
{
  "libroId": 2,
  "titulo": "El Principito - Edición Especial",
  "autor": "Antoine de Saint-Exupéry",
  "prestado": true
}
```
#### Correcto

![image](https://github.com/user-attachments/assets/1c1e572b-1d30-4f5a-a2ef-4deeb1b79397)
```json
{
  "libroId": 2,
  "titulo": "El Principito - Edición Especial",
  "prestado": true
}
```
#### Incorrecto

![image](https://github.com/user-attachments/assets/0fe54bd8-b3c1-45a6-9f4d-fb0e2ae8886d)

- `DELETE /api/LibrosApi/{id}` – Eliminar un libro

![image](https://github.com/user-attachments/assets/07010e67-0adb-496e-86d8-da6ba8981951)
#### Se intenta eliminar el mismo libro

![image](https://github.com/user-attachments/assets/6f0d7980-ebe7-44e5-96be-538f51ace72a)



---

### 📘 UsuariosApi

- `GET /api/UsuariosApi` – Listar todos los usuarios

![image](https://github.com/user-attachments/assets/ba467b79-d05b-4b46-9ecf-e9dbd0e955cb)

- `POST /api/UsuariosApi` – Registrar nuevo usuario
```json
{
  "nombre": "Juan Rodriguez",
  "email": "Juan@example.com"
}
```
![image](https://github.com/user-attachments/assets/52e59bf9-d092-4af9-b291-d876057a9b45)
Se intenta registrar un usuario sin el nombre

![image](https://github.com/user-attachments/assets/14919f31-a5ea-4bff-99d8-4d475dcdc792)


- `GET /api/UsuariosApi/{id}/prestamos` – Ver historial de préstamos del usuario

![image](https://github.com/user-attachments/assets/a4760fbf-e7b5-48bd-933b-7a9d9aa39e45)

---

### 📕 PrestamosApi

- `POST /api/PrestamosApi` – Registrar nuevo préstamo  
  ✅ **Ejemplo correcto:**
  ```json
  {
    "libroId": 7,
    "usuarioId": 2
  }
Correcto

![image](https://github.com/user-attachments/assets/65f7d4e9-c558-47b0-8457-5461a950232e)
Incorrecto

![image](https://github.com/user-attachments/assets/07a918d1-dd40-4a56-b58a-352a0b90d836)

- `POST /api/PrestamosApi/devoluciones` – Realizar devolucion

![image](https://github.com/user-attachments/assets/b95e2397-5dd8-40d7-9a62-f5573522d940)
Se intenta realizar una devolucion de un libro que no esta prestado

![image](https://github.com/user-attachments/assets/6e00550a-9eaa-4817-9dcd-4d13e56bb603)



