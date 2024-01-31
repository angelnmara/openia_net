Pasos para construccion y deploy  
1.- Descargar codigo https://github.com/angelnmara/openia_net.git  
2.- Cambiar el token en el archivo appsettings.json
3.- Verificar que este instalado docker docker --version  
4.- Acceder a la raiz del proyecto cd openia_net  
5.- Construir imagen docker build -t netcoreimage .  
6.- Verificar que se creo la imagen docker images  
7.- Ejecutar imagen docker run -d -p 5000:8080 -e ASPNETCORE_ENVIRONMENT=Development --name apinetcore  netcoreimage  
8.- Acceder al sitio http://localhost:5000/swagger/index.html  
