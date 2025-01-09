# Instalación
Clonar repositorio
```bash
git clone https://github.com/techeca/PruebaK.git
```
Desde Visual Studio:  
Instalar dependencias
```bash
Update-Package
```
Debe configurar `Web.config` de `API` para conectarse a su instancia de SQL server.
```bash
connectionString="Server=localhost;Database=DBPrueba;Integrated Security=True;"
```

En `Web.config` de `WEB` se encuentra la url del `API` a la que se conecta, puede modificarla en caso de cambiar el puerto.
```bash
<add key="APIURL" value="https://localhost:44352/api/"/>
```

F5 para iniciar el proyecto

SQL Server 2016
.Net Framework 4.7.2

## Estructura
La solución consta de dos proyectos uno para la API y otro para la WEB que lo consume, tiene configurado seed para insertar productos de prueba.

### API
Los archivos principales de la `API` se encuentran en:  
- `Controllers` para la lógica de endpoints.  
- `Models` con la clase de Producto.  
- `Services` con la lógica para la comunicación con la bd.  

### WEB
 - `Controllers` para el control de solicitudes.  
 - `Models` con la clase de Producto. 
 - `Views` con las vistas para CRUD.

## Características logradas
- CRUD  
- Orden de Productos  
- Búsqueda de productos
- Paginación  
- Documentación de endpoints  
