#include <unistd.h>
#include <string.h> 
#include <stdlib.h>
#include <stdio.h> 
#include <sys/types.h>
#include <netinet/in.h>
#include <sys/socket.h>
#include <mysql.h> 
#include <pthread.h>

#define MAX_JUGADORES 10
#define MAX_PARTIDAS  5

//Variables Globales:
int contador;
pthread_mutex_t mutex = PTHREAD_MUTEX_INITIALIZER;
int i;
int sockets[100];
int numSockets;

typedef struct{ //Definición de la estructura Conectado: Contiene el nombre y socket de cada conectado de la ListaConectados
	char nombre[20];
	int socket;
}Conectado;

typedef struct{ //Definición ListaConectados: Lista de usuarios conectados al juego
	Conectado conectados[10];
	int num;
}ListaConectados;

typedef struct { //Definicion de la estructura Jugador: Contiene el nombre y variables de juegos de cada jugador de la tabla de Partidas
    char nombre[20];
	double tiempo;
	int puntos;
	int priority; //1 es el creador de la partida
} Jugador;

typedef struct { //Definición Partidas: Tabla de partidas con los jugadores conectados a cada partida
    int idPartida;
    Jugador jugadores[MAX_JUGADORES];
    int numJugadores;
	int respuestas;
} Partidas;

//Declaración Estructuras:
Partidas partidas[MAX_PARTIDAS];
int numPartidas = 0;

ListaConectados miLista;

int PonConectado(char nombre[20], int socket){ //Función PonConectado: Introduce un usuario a la ListaConectados
	int double_user = 0;
	if(miLista.num==10)
	{
		return -1;
	}
	else
	{
		for(int i = 0; i < miLista.num; i++)
		{
			if(!strcmp(miLista.conectados[i].nombre, nombre))
			{
				double_user = 1;
				return -2;
			}
		}
		if(!double_user)
		{
			strcpy(miLista.conectados[miLista.num].nombre, nombre);
			miLista.conectados[miLista.num].socket = socket;
			miLista.num++;
			return 0;
		}
	}
}

int DamePosicion(char nombre[20]) //Función DamePosicion: Encuentra la posición de un usuario dentro de la ListaConectados
{
	int i = 0;
	int encontrado = 0;
	while((i<miLista.num) && !encontrado)
	{
		if(strcmp(miLista.conectados[i].nombre, nombre) ==0){
			encontrado = 1;
		}
		else{
			i++;
		}
	}
	if(encontrado){
		return i;
	}
	else{
		return -1;
	}
}

int DameJugador(int id, char nombre[20]) //Función DameJugador: Encuentra la posición de un jugador dentro del vector jugadores de una determinada partida de la tabla de partidas
{
	int i = 0;
	int encontrado = 0;
	while((i<partidas[id].numJugadores) && !encontrado)
	{
		if(strcmp(partidas[id].jugadores[i].nombre, nombre) ==0){
			encontrado = 1;
		}
		else{
			i++;
		}
	}
	if(encontrado){
		return i;
	}
	else{
		return -1;
	}
}

int DameSocket(char nombre[20]) //Función DameSocket: Encuentra el Socket de un usuario determinado de la ListaConectados
{
	int socket;
	int i = 0;
	int encontrado = 0;
	while((i<miLista.num) && !encontrado)
	{
		if(strcmp(miLista.conectados[i].nombre, nombre) == 0)
		{
			encontrado = 1;
			socket = miLista.conectados[i].socket;
		}
		else
		{
			i++;
		}
	}
	if(encontrado)
	{
		return socket;
	}
	else{
		return -1;
	}
}


int EliminaConectado(char nombre[20]){ //Función EliminaConectado: Elimina un usuario de la ListaConectados
	
	int pos = DamePosicion(nombre);
	if(pos == -1){
		printf("Usuario %s NO eliminado\n", nombre);
		return -1;
	}
	else{
		for(int i = pos; i < miLista.num-1; i++)
		{
			miLista.conectados[i] = miLista.conectados[i+1];
		}
		miLista.num--;
		printf("Usuario %s eliminado\n", nombre);
		return 1;
	}
}

void DameConectados(char conectados[300]){ //Procedimiento DameConectados: Escribe en el terminal el nombre de todos los usuarios conectados
	
	sprintf(conectados,"%d",miLista.num);
	for(int i = 0; i < miLista.num; i++)
	{
		sprintf(conectados, "%s/%s", conectados, miLista.conectados[i].nombre);
	}
}

int DameSocketsConectados(char sockets[100]){ //Función DameSocketsConectados: Devuelve el número así como cada uno de los sockets de los usuarios conectados
	
	int cont = 0;
	for(int i = 0; i < miLista.num; i++)
	{
		sockets[i] = miLista.conectados[i].socket;
		cont++;
	}
	return cont;
}

void consultar_usuario(MYSQL *conn, char *username, char *password, char *respuesta, int socket) { //Procedimiento consultar_usuario: Consulta en la base de datos si existe o no un usuario
	
	
	char consulta[256];
	sprintf(consulta, "SELECT USERNAME FROM PLAYER WHERE USERNAME='%s' AND PASSWORD='%s';", username, password);
	
	if (mysql_query(conn, consulta)) {   
		printf("Error al consultar datos de la base %u %s\n", mysql_errno(conn), mysql_error(conn)); 
		strcpy(respuesta, "Error");
		return;
	}
	
	MYSQL_RES *resultado = mysql_store_result(conn);    
	MYSQL_ROW row = mysql_fetch_row(resultado);   
	
	if (row == NULL) {
		printf("No se han obtenido datos en la consulta\n");   
		sprintf(respuesta, "0");
	} 
	else {  
		int res = PonConectado(row[0], socket);
		
		if(res == -1){
			printf("La lista esta llena\n");
		}
		else
		{
			if(res == -2)
			{
				printf("Error, usuario %s ya està conectado\n", row[0]);
				sprintf(respuesta, "1/%s", "-1");
			}
			else
			{
				printf("Usuario %s agregado a la lista de conectados\n", row[0]);
				sprintf(respuesta, "1/%s", row[0]);
			}
		}
	}
	
	mysql_free_result(resultado);
}


void insertar_usuario(MYSQL *conn, char *username, char *password, char *respuesta) { //Procedimiento insertar_usuario: Inserta en la base de datos un usuario
	
	char consulta[256];
	sprintf(consulta, "INSERT INTO PLAYER VALUES ('%s', '%s');", username, password);
	
	printf("%s\n", consulta);
	
	if (mysql_query(conn, consulta)) {   
		printf("Error al insertar datos en la base %u %s\n", mysql_errno(conn), mysql_error(conn)); 
		strcpy(respuesta, "2/No");
	} else {

		strcpy(respuesta, "2/Si");
	}
}

void insertar_partida(MYSQL *conn, int id, char *hora, float tiempo, char *ganador) { //Procedimiento insertar_partida: Inserta en la base de datos una partida
	
	char consulta[256];
	sprintf(consulta, "INSERT INTO MATCHES VALUES (%d, '%s', %f, '%s');", id, hora, tiempo, ganador);
	
	printf("%s\n", consulta);
	
	if (mysql_query(conn, consulta)) {   
		printf("Error al insertar datos en la base %u %s\n", mysql_errno(conn), mysql_error(conn)); 
	} else {
		printf("Partida %d introducida en la base de datos\n", id); 
	}
}



void consultar_tiempo(MYSQL *conn, int id_m, char *respuesta) { //Procedimiento conultar_tiempo: Consulta la fecha y hora en la que se ha realizado una partida
	
	char consulta[256];
	sprintf(consulta, "SELECT TIME FROM MATCHES WHERE ID=%d;", id_m);
	
	if (mysql_query(conn, consulta)) {   
		printf("Error al consultar datos de la base %u %s\n", mysql_errno(conn), mysql_error(conn)); 
		strcpy(respuesta, "Error");
		return;
	}
	
	MYSQL_RES *resultado = mysql_store_result(conn);    
	MYSQL_ROW row = mysql_fetch_row(resultado);   
	
	if (row == NULL) {
		printf("No se han obtenido datos en la consulta\n");   
		sprintf(respuesta, "3/0");
	} else {
		sprintf(respuesta, "3/%s", row[0]);  
	}
	
	mysql_free_result(resultado);
}


void consultar_duracion(MYSQL *conn, int id_m, char *respuesta) { //Procedimiento conultar_duracion: Consulta los minutos que ha durado una partida
	char consulta[256];
	sprintf(consulta, "SELECT DURATION FROM MATCHES WHERE ID=%d;", id_m);
	
	if (mysql_query(conn, consulta)) {   
		printf("Error al consultar datos de la base %u %s\n", mysql_errno(conn), mysql_error(conn)); 
		strcpy(respuesta, "Error");
		return;
	}
	
	MYSQL_RES *resultado = mysql_store_result(conn);    
	MYSQL_ROW row = mysql_fetch_row(resultado);   
	
	if (row == NULL) {
		printf("No se han obtenido datos en la consulta\n");   
		sprintf(respuesta, "4/0");
	} else {
		sprintf(respuesta, "4/%s", row[0]);  
	}
	
	mysql_free_result(resultado);
}



void consultar_ganador(MYSQL *conn, int id_m, char *respuesta) { //Procedimiento conultar_ganador: Consulta el ganador de una partida
	char consulta[256];
	sprintf(consulta, "SELECT WINNER FROM MATCHES WHERE ID=%d;", id_m);
	
	if (mysql_query(conn, consulta)) {   
		printf("Error al consultar datos de la base %u %s\n", mysql_errno(conn), mysql_error(conn)); 
		strcpy(respuesta, "Error");
		return;
	}
	
	MYSQL_RES *resultado = mysql_store_result(conn);    
	MYSQL_ROW row = mysql_fetch_row(resultado);   
	
	if (row == NULL) {
		printf("No se han obtenido datos en la consulta\n");   
		sprintf(respuesta, "5/0");
	} else {
		sprintf(respuesta, "5/%s", row[0]);  
	}
	
	mysql_free_result(resultado);
}

void *AtenderCliente (void *socket) //Thread del Servidor que atiende a las peticiones del cliente
{
		MYSQL *conn = mysql_init(NULL);
		int sock_conn;
		int *s;
		s= (int *) socket;
		sock_conn = *s;
		
		char peticion[512];
		char respuesta[512];
		char conectados[300];
		int ret;
		
		if (conn == NULL) {
			printf("Error al inicializar MySQL\n");
			return 1;
		}
		
		// Conectar a la base de datos
		if (mysql_real_connect(conn, "shiva2.upc.es", "root", "mysql", "M4_GAME", 0, NULL, 0) == NULL) {
			printf("Error de conexion a la base de datos: %s\n", mysql_error(conn));
			mysql_close(conn);
			return 1;
		}
		
		int terminar = 0;
		printf("Num Sockets: %d\n", numSockets);
		while (!terminar) //Bucle para atender a las peticiones del cliente
		{
			memset(respuesta, 0, sizeof(respuesta));
			memset(peticion, 0, sizeof(peticion));
			
			ret = read(sock_conn, peticion, sizeof(peticion));
			peticion[ret] = '\0';
			
			printf("Peticion: %s\n", peticion);
			
			char username[20] = "";
			char password[20] = "";
			int id_m;
			char *p = strtok(peticion, "/");
			int codigo = atoi(p);
			printf("codigo: %d\n", codigo);
			
			if (codigo != 0 && codigo < 3 || codigo == 8) {
				p = strtok(NULL, "/");
				if (p != NULL)
				{
					strcpy(username, p);
				}
				
				p = strtok(NULL, "/");
				if (p != NULL)
				{
					strcpy(password, p);
				}
				
				printf("Codigo: %d, Nombre: %s, Contrase?a: %s\n", codigo, username, password);
			}
			else if (codigo!=0 && codigo!=6 && codigo!=9)
			{
				p = strtok(NULL, "/");
				if (p != NULL)
				{
					id_m = atoi(p);
				}
				
				printf("Id partida: %d\n", id_m);
			}
			
			if (codigo == 0) //Desconexión del Cliente
			{
				pthread_mutex_lock(&mutex);
				int i = DamePosicion(username);
				pthread_mutex_unlock(&mutex);
				
				for(i; i < miLista.num; i++)
				{
					printf("Socket: %d\n", sockets[i]);
					sockets[i] = sockets[i+1];
				}
				numSockets--;
				printf("Num Sockets: %d\n", numSockets);
				terminar = 1;
			} 
			else if (codigo == 1) //Login del Cliente
			{
				pthread_mutex_lock(&mutex);
				consultar_usuario(conn, username, password, respuesta, sock_conn);
				pthread_mutex_unlock(&mutex);
			} 
			else if (codigo == 2) //Registro del Cliente
			{
				pthread_mutex_lock(&mutex);
				insertar_usuario(conn, username, password, respuesta);
				pthread_mutex_unlock(&mutex);
			}
			else if (codigo == 3) //Query sobre la fecha y hora de una partida
			{
				pthread_mutex_lock(&mutex);
				consultar_tiempo(conn, id_m, respuesta);
				pthread_mutex_unlock(&mutex);
			}
			else if (codigo == 4) //Query sobre la duracion de una partida
			{
				pthread_mutex_lock(&mutex);
				consultar_duracion(conn, id_m, respuesta);
				pthread_mutex_unlock(&mutex);
			}
			else if (codigo == 5) //Query sobre el ganador de una partida
			{
				pthread_mutex_lock(&mutex);
				consultar_ganador(conn, id_m, respuesta);
				pthread_mutex_unlock(&mutex);
			}
			else if (codigo == 6) //Query sobre el número de servicios proporcionados por el servidor
			{
				sprintf(respuesta, "6/%d", contador);
			}
			else if(codigo == 7) //Actualizar ListaConectados
			{
				pthread_mutex_lock(&mutex);
				DameConectados(conectados);
				pthread_mutex_unlock(&mutex);

				char copia_conectados[500];
				strcpy(copia_conectados, conectados); // Copia ANTES de usar strtok
				printf("Copia Conectados:%s\n", copia_conectados);
				char *p = strtok(copia_conectados, "/");
				int n = atoi(p);

				for (int i = 0; i < n; i++)
				{
					char nom[20];
					p = strtok(NULL, "/");
					strcpy(nom, p);
					printf("Conectado: %s\n", nom);
				}

				sprintf(respuesta, "7/%s", conectados);
				printf("Notificacion: %s\n", respuesta);
				for(int i = 0; i < miLista.num; i++){
				write(miLista.conectados[i].socket, respuesta, strlen(respuesta));
				}

			}
			else if (codigo == 8) //Quitar un usuario de la ListaConectados y actualizar
			{
				pthread_mutex_lock(&mutex);
				int res = EliminaConectado(username);
				DameConectados(conectados);
				pthread_mutex_unlock(&mutex);

				// COPIA antes de usar strtok
				char copia_conectados[500];
				strcpy(copia_conectados, conectados);
				printf("Copia Conectados:%s\n", copia_conectados);

				char *p = strtok(copia_conectados, "/");
				int n = atoi(p);
					
				for(int i = 0; i < n; i++)
				{
					char nom[20];
					p = strtok(NULL, "/");
					strcpy(nom, p);
					printf("Conectado: %s\n", nom);
				}

				// Ahora usa la copia que NO se ha modificado
				sprintf(respuesta, "7/%s", conectados);
				printf("Notificacion: %s\n", respuesta);
				// Enviar a todos
				for(int j = 0; j < numSockets; j++)
				{
					printf("Socket: %d\n", sockets[j]);
					write(sockets[j], respuesta, strlen(respuesta));
				}						
			}
			else if (codigo == 9) //Invitación y Creación de una partida
			{
				p = strtok(NULL, "/");
				int num_inv = atoi(p);
				printf("num_inv: %d\n", num_inv);
				p = strtok(NULL, "/");
				char user[20];
				strcpy(user, p);
				printf("invitador: %s\n", user);
				
				if (numPartidas < MAX_PARTIDAS) 
				{
					partidas[numPartidas].idPartida = numPartidas;
					partidas[numPartidas].numJugadores = 0;
					strcpy(partidas[numPartidas].jugadores[0].nombre, user);
					partidas[numPartidas].numJugadores++;
					partidas[numPartidas].jugadores[0].priority = 1;
					partidas[numPartidas].jugadores[0].puntos = 0;
					printf("Partida %d creada\n", numPartidas);
					printf("Jugador %s añadido a la partida %d", user, numPartidas);
					sprintf(respuesta, "9/%d/%s te ha invitado a una partida/%s", numPartidas, user, user); 
		
					char nombre[20];
					
					printf("invitacion: %s\n", respuesta);
					///
					for(int i = 0; i < num_inv ; i++)
					{
						p = strtok(NULL, "/");
						strcpy(nombre, p);
						int res = DameSocket(nombre);
						printf("Nombre: %s || Socket: %d\n", nombre, res);
						write(res, respuesta, strlen(respuesta));
					}
					///
					numPartidas++;
				}
				else
					printf("Se ha llegado al límite de partidas\n");
				
			}
			else if(codigo == 10) //Respuesta del invitado a la invitación
			{
				p = strtok(NULL, "/");
				char invitado[20];
				strcpy(invitado,p);
				int veredicto;
				p = strtok(NULL, "/");
				veredicto = atoi(p);
				char invitador[20];
				p = strtok(NULL, "/");
				strcpy(invitador,p);
				if(veredicto){
					sprintf(respuesta, "10/%s/1/%d", invitado, partidas[numPartidas -1].idPartida);
					if (partidas[numPartidas -1].numJugadores < MAX_JUGADORES) 
					{
						strcpy(partidas[numPartidas -1].jugadores[partidas[numPartidas -1].numJugadores].nombre, invitado);
						partidas[numPartidas -1].jugadores[partidas[numPartidas -1].numJugadores].priority = 0;
						partidas[numPartidas -1].jugadores[partidas[numPartidas -1].numJugadores].puntos = 0;
						partidas[numPartidas -1].numJugadores++;
						printf("Jugador %s añadido a la partida %d\n", invitado, partidas[numPartidas -1].idPartida);
					}
				}
				else{
					sprintf(respuesta, "10/%s/0/%d", invitado, partidas[numPartidas -1].idPartida);
				}
			
				int res = DameSocket(invitador);
				printf("socket: %d\n", res);
				printf("Respuesta a invitacion: %s\n", respuesta);
				for(int i = 0; i < partidas[numPartidas -1].numJugadores; i++){
					printf("Jugador %d partida %d: %s\n", i, partidas[numPartidas -1].idPartida, partidas[numPartidas -1].jugadores[i].nombre);
				}
				write(res, respuesta, strlen(respuesta) + 1);
			}
			else if(codigo == 11) //Inicio de la partida con losjugadores aceptados
			{
				char jugador[20];
				sprintf(respuesta, "11/%d/", partidas[numPartidas -1].idPartida); 
				printf("Numero de jugadores partida %d = %d\n", partidas[numPartidas -1].idPartida, partidas[numPartidas -1].numJugadores);
				for(int i=0; i < partidas[numPartidas -1].numJugadores; i++){
					if(partidas[numPartidas-1].jugadores[i].priority == 1)
					{
						strcat(respuesta, partidas[numPartidas-1].jugadores[i].nombre);
					}
					strcpy(jugador, partidas[numPartidas -1].jugadores[i].nombre);
					int res = DameSocket(jugador);
					printf("Respuesta a socket %d: %s\n", res, respuesta);
					write(res, respuesta, strlen(respuesta) + 1);
				}
			}
			else if(codigo == 12){ //Mensaje por chat de la partida
				char jugador[20];
				char mensajero[20];
				char chat[100];
				p = strtok(NULL, "/");
				strcpy(mensajero, p);
				p = strtok(NULL, "/");
				strcpy(chat, p);
				sprintf(respuesta, "12/%d/%s/%s", id_m, mensajero, chat);
				
				for(int i=0; i < partidas[id_m].numJugadores; i++){
					strcpy(jugador, partidas[id_m].jugadores[i].nombre);
					int res = DameSocket(jugador);
					printf("Respuesta a socket %d: %s\n", res, respuesta);
					write(res, respuesta, strlen(respuesta) + 1);
				}
				
			}
			else if(codigo == 13){ //Juego 1: El Forastero, quien dispara más rápido gana
				double t;
				double max;
				int j;
				char jugador[20];
				p = strtok(NULL, "/");
				t = strtod(p, NULL);
				printf("t: %f", t);
				p = strtok(NULL, "/");
				strcpy(jugador, p);
				int i = DameJugador(id_m, jugador);
				pthread_mutex_lock(&mutex);
				partidas[id_m].jugadores[i].tiempo = t;
				pthread_mutex_unlock(&mutex);
				printf("tiempo jugador %s: %f", jugador, partidas[id_m].jugadores[i].tiempo);
				partidas[id_m].respuestas++;
				if(partidas[id_m].respuestas == partidas[id_m].numJugadores){
					max = partidas[id_m].jugadores[0].tiempo;
					j = 0;
					for(int i = 0; i< partidas[id_m].numJugadores; i++){
						printf("Comparacion :%f < %f\n", partidas[id_m].jugadores[i].tiempo, max );
						if(partidas[id_m].jugadores[i].tiempo < max){
							max = partidas[id_m].jugadores[i].tiempo;
							j = i;
						}
					}
					char puntos[200];
					sprintf(respuesta, "13/%d/%s", id_m, partidas[id_m].jugadores[j].nombre);
					pthread_mutex_lock(&mutex);
					partidas[id_m].jugadores[j].puntos = partidas[id_m].jugadores[j].puntos + 10;
					pthread_mutex_unlock(&mutex);
					for(int i=0; i < partidas[id_m].numJugadores; i++)
					{
						sprintf(puntos, "/%s:%d", partidas[id_m].jugadores[i].nombre, partidas[id_m].jugadores[i].puntos);
						strcat(respuesta, puntos);
					}
					for(int i=0; i < partidas[id_m].numJugadores; i++){
						strcpy(jugador, partidas[id_m].jugadores[i].nombre);
						int res = DameSocket(jugador);
						printf("Respuesta a socket %d: %s\n", res, respuesta);
						printf("Puntos %s: %d\n", partidas[id_m].jugadores[i].nombre, partidas[id_m].jugadores[i].puntos); 
						write(res, respuesta, strlen(respuesta) + 1);
					}
				
				}
				
			}
			else if(codigo == 14) //Siguiente juego
			{
				p = strtok(NULL, "/");
				int juego = atoi(p);
				sprintf(respuesta, "14/%d/%d", id_m, juego);
				char jugador[20];
				pthread_mutex_lock(&mutex);
				partidas[id_m].respuestas = 0;
				pthread_mutex_unlock(&mutex);
				if(juego == 3){ //Pantalla final de la partida
					printf("fin de la partida %d\n", id_m);
					int max = partidas[id_m].jugadores[0].puntos;
					int j = 0;
					for(int i=1; i < partidas[id_m].numJugadores; i++){
						if(partidas[id_m].jugadores[i].puntos > max){
							max = partidas[id_m].jugadores[i].puntos;
							j = i;
						}
					}
					printf("Ganador de la partida %d: %s con %d\n", id_m, partidas[id_m].jugadores[j].nombre, max);
					sprintf(respuesta, "%s/%s", respuesta, partidas[id_m].jugadores[j].nombre);
				}
				else if(juego == 4){ //Registro de la partida en la base de datos
					char hora[50];
					char ganador[20];
					p = strtok(NULL, "/");
					strcpy(hora, p);
					p = strtok(NULL, "/");
					strcpy(ganador, p);
					p = strtok(NULL, "/");
					double tiempo = strtod(p, NULL);
					printf("hora: %s\n", hora);
					printf("ganador: %s\n", ganador);
					printf("tiempo: %f", tiempo);
					insertar_partida(conn, id_m, hora, tiempo, ganador);
				}
				for(int i=0; i < partidas[id_m].numJugadores; i++){
						strcpy(jugador, partidas[id_m].jugadores[i].nombre);
						int res = DameSocket(jugador);
						printf("Respuesta a socket %d: %s\n", res, respuesta);
						write(res, respuesta, strlen(respuesta) + 1);
				}
				
			}
			else if(codigo == 15)//Juego 2: Carrera de las Galaxias, gana el más rápido en llegar a la meta
			{
				char jugador [20];
				p = strtok(NULL, "/");
				strcpy(jugador, p);
				pthread_mutex_lock(&mutex);
				partidas[id_m].respuestas++;
				pthread_mutex_unlock(&mutex);
				if(partidas[id_m].respuestas < 2){
					int i = DameJugador(id_m, jugador);
					char puntos[200];
					sprintf(respuesta, "15/%d/%s", id_m, jugador);
					pthread_mutex_lock(&mutex);
					partidas[id_m].jugadores[i].puntos = partidas[id_m].jugadores[i].puntos + 10;
					pthread_mutex_unlock(&mutex);
					for(int i=0; i < partidas[id_m].numJugadores; i++)
					{
						sprintf(puntos, "/%s:%d", partidas[id_m].jugadores[i].nombre, partidas[id_m].jugadores[i].puntos);
						strcat(respuesta, puntos);
					}
					for(int i=0; i < partidas[id_m].numJugadores; i++){
						strcpy(jugador, partidas[id_m].jugadores[i].nombre);
						int res = DameSocket(jugador);
						printf("Respuesta a socket %d: %s\n", res, respuesta);
						printf("Puntos %s: %d\n", partidas[id_m].jugadores[i].nombre, partidas[id_m].jugadores[i].puntos); 
						write(res, respuesta, strlen(respuesta) + 1);
					}
				}
			}
			else if(codigo == 16)//Juego 3: Ataque Submarino, gana el que atina con más precisión el objetivo
			{
				int punteria;
				int max;
				int j;
				p = strtok(NULL, "/");
				punteria = atoi(p);
				pthread_mutex_lock(&mutex);
				partidas[id_m].respuestas++;
				pthread_mutex_unlock(&mutex);
				char jugador[20];
				p = strtok(NULL, "/");
				strcpy(jugador, p);
				int i = DameJugador(id_m, jugador);
				pthread_mutex_lock(&mutex);
				partidas[id_m].jugadores[i].tiempo = punteria;
				pthread_mutex_unlock(&mutex);
				
				if(partidas[id_m].respuestas == partidas[id_m].numJugadores)
				{
					max = partidas[id_m].jugadores[0].tiempo;
					j = 0;
					for(int i = 0; i< partidas[id_m].numJugadores; i++){
						printf("Comparacion :%f < %d\n", partidas[id_m].jugadores[i].tiempo, max );
						if(partidas[id_m].jugadores[i].tiempo < max){
							max = partidas[id_m].jugadores[i].tiempo;
							j = i;
						}
					}
					char puntos[200];
					sprintf(respuesta, "16/%d/%s", id_m, partidas[id_m].jugadores[j].nombre);
					pthread_mutex_lock(&mutex);
					partidas[id_m].jugadores[j].puntos = partidas[id_m].jugadores[j].puntos + 10;
					pthread_mutex_unlock(&mutex);
					for(int i=0; i < partidas[id_m].numJugadores; i++)
					{
						sprintf(puntos, "/%s:%d", partidas[id_m].jugadores[i].nombre, partidas[id_m].jugadores[i].puntos);
						strcat(respuesta, puntos);
					}
					for(int i=0; i < partidas[id_m].numJugadores; i++){
						strcpy(jugador, partidas[id_m].jugadores[i].nombre);
						int res = DameSocket(jugador);
						printf("Respuesta a socket %d: %s\n", res, respuesta);
						printf("Puntos %s: %d\n", partidas[id_m].jugadores[i].nombre, partidas[id_m].jugadores[i].puntos); 
						write(res, respuesta, strlen(respuesta) + 1);
					}
				}
			}
			else if(codigo == 17){ //Cierre forzado de la partida
				sprintf(respuesta, "17/%d", id_m);
				char jugador[20];
				for(int i=0; i < partidas[id_m].numJugadores; i++){
						strcpy(jugador, partidas[id_m].jugadores[i].nombre);
						int res = DameSocket(jugador);
						printf("Respuesta a socket %d: %s\n", res, respuesta);
						write(res, respuesta, strlen(respuesta) + 1);
				}
			}
			if (codigo != 0 && codigo != 7 && codigo != 8 && codigo != 9 && codigo != 10 && codigo != 11 && codigo != 12 && codigo != 13 && codigo != 14 && codigo != 15 && codigo != 16 && codigo != 17) 
			{
				printf("Respuesta: %s\n", respuesta);
				write(sock_conn, respuesta, strlen(respuesta));
			}
			
			if((codigo==3)||(codigo==4)||(codigo==5)) //Contador de Servicios
			{
				pthread_mutex_lock( &mutex );
				contador++;
				pthread_mutex_unlock( &mutex );
			}
		}
	printf("Desconectado\n");
	pthread_exit(NULL);
	mysql_close(conn); //Cierre de la conexión con la base de datos
	close(sock_conn); //Cierre de la conexión con el socket
} //Fin del thread


int main(int argc, char *argv[])  //Conexión con el Socket
{
	int sock_conn, sock_listen;
	int puerto = 50004;
	struct sockaddr_in serv_adr;
	
	// Configurar el socket
	if ((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0) {
		printf("Error creando socket\n");
		return 1;
	}
	
	memset(&serv_adr, 0, sizeof(serv_adr));
	serv_adr.sin_family = AF_INET;
	serv_adr.sin_addr.s_addr = htonl(INADDR_ANY);
	serv_adr.sin_port = htons(puerto);
	
	if (bind(sock_listen, (struct sockaddr *)&serv_adr, sizeof(serv_adr)) < 0) {
		printf("Error en el bind\n");
		return 1;
	}
	
	if (listen(sock_listen, 3) < 0) {
		printf("Error en el listen\n");
		return 1;
	}

	
	contador = 0;
	numSockets = 0;
	pthread_t thread;

	for(;;)
	{
		printf("Escuchando\n");
		sock_conn = accept(sock_listen, NULL, NULL);
		printf ("He recibido conexion\n");
		
		sockets[numSockets] = sock_conn;
		
		pthread_create (&thread, NULL, AtenderCliente,&sockets[numSockets]); 
		
		
		numSockets++;
	}
}