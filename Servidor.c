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

int contador;
pthread_mutex_t mutex = PTHREAD_MUTEX_INITIALIZER;
int i;
int sockets[100];
int numSockets;

typedef struct{
	char nombre[20];
	int socket;
}Conectado;

typedef struct{
	Conectado conectados[10];
	int num;
}ListaConectados;

typedef struct {
    char nombre[20];
} Jugador;

typedef struct {
    int idPartida;
    Jugador jugadores[MAX_JUGADORES];
    int numJugadores;
} Partidas;

Partidas partidas[MAX_PARTIDAS];
int numPartidas = 0;

ListaConectados miLista;

int PonConectado(char nombre[20], int socket){
	
	if(miLista.num==10)
	{
		return -1;
	}
	else
	{
		strcpy(miLista.conectados[miLista.num].nombre, nombre);
		miLista.conectados[miLista.num].socket = socket;
		miLista.num++;
		return 0;
	}
}

int DamePosicion(char nombre[20])
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

int DameSocket(char nombre[20])
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


int EliminaConectado(char nombre[20]){
	
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

void DameConectados(char conectados[300]){
	
	sprintf(conectados,"%d",miLista.num);
	for(int i = 0; i < miLista.num; i++)
	{
		sprintf(conectados, "%s/%s", conectados, miLista.conectados[i].nombre);
	}
}

void consultar_usuario(MYSQL *conn, char *username, char *password, char *respuesta, int socket) {
	
	
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
		sprintf(respuesta, "1/%s", row[0]);  
		
		pthread_mutex_lock(&mutex);
		int res = PonConectado(row[0], socket);
		pthread_mutex_unlock(&mutex);
		
		if(res == -1){
			printf("La lista esta llena\n");
		}
		else{
			printf("Usuario %s agregado a la lista de conectados\n", row[0]);
		}
	}
	
	mysql_free_result(resultado);
}


void insertar_usuario(MYSQL *conn, char *username, char *password, char *respuesta) {
	
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



void consultar_tiempo(MYSQL *conn, int id_m, char *respuesta) {
	
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


void consultar_duracion(MYSQL *conn, int id_m, char *respuesta) {
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



void consultar_ganador(MYSQL *conn, int id_m, char *respuesta) {
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

void *AtenderCliente (void *socket)
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
		while (!terminar)
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
			
			if (codigo == 0) 
			{
				for(int i = DamePosicion(username); i < miLista.num; i++)
				{
					printf("Socket: %d\n", sockets[i]);
					sockets[i] = sockets[i+1];
				}
				numSockets--;
				printf("Num Sockets: %d\n", numSockets);
				terminar = 1;
			} 
			else if (codigo == 1)
			{
				consultar_usuario(conn, username, password, respuesta, sock_conn);
			} 
			else if (codigo == 2) 
			{
				insertar_usuario(conn, username, password, respuesta);
			}
			else if (codigo == 3)
			{
				consultar_tiempo(conn, id_m, respuesta);
			}
			else if (codigo == 4)
			{
				consultar_duracion(conn, id_m, respuesta);
			}
			else if (codigo == 5)
			{
				consultar_ganador(conn, id_m, respuesta);
			}
			else if (codigo == 6)
			{
				sprintf(respuesta, "6/%d", contador);
			}
			else if(codigo == 7)
			{
				DameConectados(conectados);

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
				
				// Enviar a todos los conectados
				for (int j = 0; j < numSockets; j++)
				{
					//printf("Socket: %d\n", sockets[j]);
					write(sockets[j], respuesta, strlen(respuesta));
				}

			}
			else if (codigo == 8)
			{
				int res = EliminaConectado(username);
				DameConectados(conectados);

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
			else if (codigo == 9)
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
			else if(codigo == 10)
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
					sprintf(respuesta, "10/%s/1/%d", invitado, id_m);
					if (partidas[id_m].numJugadores < MAX_JUGADORES) 
					{
						strcpy(partidas[id_m].jugadores[partidas[id_m].numJugadores].nombre, invitado);
						partidas[id_m].numJugadores++;
						printf("Jugador %s añadido a la partida %d\n", invitado, id_m);
					}
				}
				else{
					sprintf(respuesta, "10/%s/0/%d", invitado, id_m);
				}
			
				int res = DameSocket(invitador);
				printf("socket: %d\n", res);
				printf("Respuesta a invitacion: %s\n", respuesta);
				for(int i = 0; i < partidas[id_m].numJugadores; i++){
					printf("Jugador %d partida %d: %s\n", i, id_m, partidas[id_m].jugadores[i].nombre);
				}
				write(res, respuesta, strlen(respuesta) + 1);
			}
			else if(codigo == 11)
			{
				char jugador[20];
				sprintf(respuesta, "11/%d", id_m); 
				printf("Numero de jugadores partida %d = %d\n", id_m, partidas[id_m].numJugadores);
				for(int i=0; i < partidas[id_m].numJugadores; i++){
					strcpy(jugador, partidas[id_m].jugadores[i].nombre);
					int res = DameSocket(jugador);
					printf("Respuesta a socket %d: %s\n", res, respuesta);
					write(res, respuesta, strlen(respuesta) + 1);
				}
			}
			else if(codigo == 12){
				char jugador[20];
				char mensajero[20];
				char chat[100];
				p = strtok(NULL, "/");
				strcpy(mensajero, p);
				p = strtok(NULL, "/");
				strcpy(chat, p);
				sprintf(respuesta, "12/%s/%s", mensajero, chat);
				
				for(int i=0; i < partidas[id_m].numJugadores; i++){
					strcpy(jugador, partidas[id_m].jugadores[i].nombre);
					int res = DameSocket(jugador);
					printf("Respuesta a socket %d: %s\n", res, respuesta);
					write(res, respuesta, strlen(respuesta) + 1);
				}
				
			}
			if (codigo != 0 && codigo != 7 && codigo != 8 && codigo != 9 && codigo != 10 && codigo != 11 && codigo != 12)
			{
				printf("Respuesta: %s\n", respuesta);
				write(sock_conn, respuesta, strlen(respuesta));
			}
			
			if((codigo==3)||(codigo==4)||(codigo==5))
			{
				pthread_mutex_lock( &mutex );
				contador++;
				pthread_mutex_unlock( &mutex );
			}
		}
	printf("Desconectado\n");
	pthread_exit(NULL);
	mysql_close(conn);
	close(sock_conn);
}


int main(int argc, char *argv[]) 
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