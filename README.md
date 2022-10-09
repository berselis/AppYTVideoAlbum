# AppYTVideoAlbum ✨
Aplicación que te permite registrar link de videos de YouTube donde podrás visualizar todos los que hayas guardado, viendo las miniaturas e información sobre éstos, también podrás reproducirlos y/o eliminarlos del listado creado. 

⚙️Esta aplicación ha sido creada en .NET Framework 4.7.2 Web Form & Base de datos se ha utilizado MSSQL Server.

Pasos para implementar aplicación:

1️⃣Renombar el archivo [Web_Example.config] por => [Web.config]

![Screenshot 2022-10-08 2321492222](https://user-images.githubusercontent.com/68135098/194736834-8c84a3a9-091c-4860-981c-8cd813626b43.png)

2️⃣Crear una base de datos con el nombre de [AppYTVideoDB] y dentro de ella una tabla con el siguiente nombre [Videos].
Puede ejecutar el comando SQL debajo ⬇️

CREATE TABLE [dbo].[Videos] (
    [IdVideo]  INT PRIMARY KEY IDENTITY (1, 1) NOT NULL,
    [UrlVideo] NVARCHAR (MAX) NOT NULL,
    [Tittle]   NVARCHAR (100) NOT NULL,
    [UrlImg]   NVARCHAR (MAX) NOT NULL,
    [Descript] NVARCHAR (MAX) NOT NULL
); 

3️⃣Agregar en la carpeta Models un item ADO.NET Entity Data Model de la base de datos creada y ponerle el siguiente nombre a la conexión [AppYTVideoDBEntities], esto para reemplazar la conexión existente el cual tiene el mismo nombre.

![Screenshot 2022-10-08 232226](https://user-images.githubusercontent.com/68135098/194737163-f4ff92e8-04da-47d5-aaa6-e44b417fa103.png)

4️⃣Renombar el archido [Example.APIKEY.xml] por => [APIKEY.xml]

![Screenshot 2022-10-09 000001](https://user-images.githubusercontent.com/68135098/194737697-e4b3b2ff-8e8c-4c2a-8e42-74f909a4ba03.png)

5️⃣Dentro de este archivo colocar tu APIKEY para utilizar los recursos de YouTube, de lo contrario la aplicación no podra procesar los link insertados.

![Screenshot 2022-10-09 000037](https://user-images.githubusercontent.com/68135098/194737742-b363a2b8-8a53-4367-b30a-35aa4abcbb06.png)

6️⃣Los directorio del proyecto deberían ser como se muestra en la siguiente imagen

![Screenshot 2022-10-09 000214](https://user-images.githubusercontent.com/68135098/194737796-ba6a9f41-180b-4ce3-adc3-00d5d873a401.png)

LISTO! 🚀

Es todo, a correr la aplicación.

aqui de dejo el link donde se encuentra desplegada: https://bdevelopment.net/appytvideoalbum/


