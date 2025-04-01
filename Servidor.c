#include <unistd.h>
#include <string.h> 
#include <stdlib.h>
#include <stdio.h> 
#include <sys/types.h>
#include <netinet/in.h>
#include <sys/socket.h>
#include <mysql.h> 
#include <pthread.h>

int contador;
pthread_mutex_t mutex = PTHREAD_MUTEX_INITIALIZER;

typedef struct{
	char nombre[20];
	int socket;
}Conectado;

typedef struct{
	Conectado conectados[10];
	int num;
}ListaConectados;

ListaConectados miLista;

int PonConectado(ListaConectados *lista, char nombre[20]){
	
	if(lista->num==10)
	{
		return -1;
	}
	else
	{
		strcpy(lista->conectados[lista->num].nombre, nombre);
		lista->num++;
		return 0;
	}
}

int DamePosicion(ListaConectados *lista, char nombre[20])
{
	int i = 0;
	int encontrado = 0;
	while((i<lista->num) && !encontrado)
	{
		if(strcmp(lista->conectados[i].nombre, nombre) ==0){
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

int EliminaConectado(ListaConectados *lista, char nombre[20]){
	
	int pos = DamePosicion(lista, nombre);
	if(pos == -1){
		return -1;
	}
	else{
		for(int i = pos; i < lista->num-1; i++)
		{
			lista->conectados[i] = lista->conectados[i+1];
		}
		lista->num--;
		printf("Usuario %s eliminado\n", nombre);
	}
}

void DameConectados(ListaConectados *lista, char conectados[300]){
	
	sprintf(conectados,"%d",lista->num);
	for(int i = 0; i < lista->num; i++)
	{
		sprintf(conectados, "%s/%s", conectados, lista->conectados[i].nombre);
	}
}

void consultar_usuario(MYSQL *conn, char *username, char *password, char *respuesta) {
	
	
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
		sprintf(respuesta, "%s", row[0]);  
		
		pthread_mutex_lock(&mutex);
		int res = PonConectado(&miLista, row[0]);
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
		strcpy(respuesta, "No");
	} else {

		strcpy(respuesta, "Si");
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
		sprintf(respuesta, "0");
	} else {
		sprintf(respuesta, "%s", row[0]);  
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
		sprintf(respuesta, "0");
	} else {
		sprintf(respuesta, "%s", row[0]);  
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
		sprintf(respuesta, "0");
	} else {
		sprintf(respuesta, "%s", row[0]);  
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
		if (mysql_real_connect(conn, "localhost", "root", "mysql", "GAME", 0, NULL, 0) == NULL) {
			printf("Error de conexion a la base de datos: %s\n", mysql_error(conn));
			mysql_close(conn);
			return 1;
		}
		
		int terminar = 0;
		
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
			else if (codigo!=0 && codigo!=6)
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
				terminar = 1;
			} 
			else if (codigo == 1)
			{
				consultar_usuario(conn, username, password, respuesta);
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
				sprintf(respuesta, "%d", contador);
			}
			else if(codigo == 7)
			{
				DameConectados(&miLista, conectados);
				sprintf(respuesta, "%s", conectados);
				char *p = strtok(conectados, "/");
				int n = atoi(p);
				for(int i =0; i<n; i++)
				{
					char nom[20];
					p = strtok(NULL, "/");
					strcpy(nom, p);
					printf("Conectado: %s\n", nom);
				}
			}
			else
			{
				EliminaConectado(&miLista, username);
				DameConectados(&miLista, conectados);
				
				char *p = strtok(conectados, "/");
				int n = atoi(p);
				for(int i =0; i<n; i++)
				{
					char nom[20];
					p = strtok(NULL, "/");
					strcpy(nom, p);
					printf("Conectado: %s\n", nom);
				}
			}
			
			if (codigo != 0)
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
		
	mysql_close(conn);
	close(sock_conn);
}


int main(int argc, char *argv[]) 
{
	int sock_conn, sock_listen;
	struct sockaddr_in serv_adr;
	
	// Configurar el socket
	if ((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0) {
		printf("Error creando socket\n");
		return 1;
	}
	
	memset(&serv_adr, 0, sizeof(serv_adr));
	serv_adr.sin_family = AF_INET;
	serv_adr.sin_addr.s_addr = htonl(INADDR_ANY);
	serv_adr.sin_port = htons(9060);
	
	if (bind(sock_listen, (struct sockaddr *)&serv_adr, sizeof(serv_adr)) < 0) {
		printf("Error en el bind\n");
		return 1;
	}
	
	if (listen(sock_listen, 3) < 0) {
		printf("Error en el listen\n");
		return 1;
	}

	
	contador = 0;
	int i=0;
	int sockets[100];
	pthread_t thread;

	for(;;)
	{
		printf("Escuchando\n");
		sock_conn = accept(sock_listen, NULL, NULL);
		printf ("He recibido conexion\n");
		
		sockets[i] = sock_conn;
		
		pthread_create (&thread, NULL, AtenderCliente,&sockets[i]); 
		
		
		i++;
	}
}
