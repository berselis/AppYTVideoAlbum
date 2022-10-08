# AppYTVideoAlbum
Aplicación que te permite registrar link de videos de YouTube donde podrás visualizar todos los que hayas guardado, viendo las miniaturas e información sobre éstos, también podrás reproducirlos y/o eliminarlos del listado creado. 

1.	Esta aplicación ha sido creada en .NET Framework 4.7.2 Web Form.
2.	Base de datos se ha utilizado MSSQL Server.
3.	Si quires utilzar otra base de datos en el archivo Web.config puedes modificar el connextionString. Sino, no es necesario modificar esta parte. 

![conString](https://user-images.githubusercontent.com/68135098/194691450-e2532a51-5ed6-40f2-b9fc-52bafb99f2a4.png)

4. Para el buen funcionamiento de la aplicación necesitar tener tu propia ApiHey de Google Cloud para utilizar YouTube, y ponerla en el siguiente archivo. 
Carpeta Setup > Example.APIKEY.xml | renombar por APIKEY.xml

![root](https://user-images.githubusercontent.com/68135098/194691890-bb74782d-fc2c-4f42-a4d0-1ea06089bb17.png)

5. Dentro de este colocaras tu ApiKey.

![apiKeyfile](https://user-images.githubusercontent.com/68135098/194691936-1bf95035-8cb3-4750-a951-3460a4b3de27.png)

6. Correr en servicod, Listo

Aqui les muesto captura de pantalla de la aplicación:

Pegando url
![list](https://user-images.githubusercontent.com/68135098/194692047-7bf5ef9d-d53b-4b47-8ad0-a22ff60f4036.png)

Viendo detalles
![details](https://user-images.githubusercontent.com/68135098/194692070-2c1ae664-7954-4bd5-9a9e-7f5984e24499.png)

Eliminando
![removeDialog](https://user-images.githubusercontent.com/68135098/194692081-f4fb1394-37df-43d0-84d4-511096dd96f2.png)

en el la interfaz de reproducción
![videoFrame](https://user-images.githubusercontent.com/68135098/194692118-2ff8b8b6-449b-4adb-beeb-f83c762bc127.png)
