Pasos para instalación
1.- Descargar codigo https://github.com/angelnmara/openia_net.git
2.- Verificar que este instalado docker docker --version
3.- Acceder a la raiz del proyecto cd openia_net
4.- Construir imagen docker build -t netcoreimage .
5.- Verificar que se creo la imagen docker images
6.- Ejecutar imagen docker run -d -p 5000:8080 -e ASPNETCORE_ENVIRONMENT=Development --name apinetcore  netcoreimage
7.- Acceder al sitio http://localhost:5000/swagger/index.html
