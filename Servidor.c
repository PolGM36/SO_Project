#include <unistd.h>
#include <string.h> 
#include <stdlib.h>
#include <stdio.h> 
#include <sys/types.h>
#include <netinet/in.h>
#include <sys/socket.h>
#include <mysql.h> 

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
	} else {
		sprintf(respuesta, "%s", row[0]);  
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

int main(int argc, char *argv[]) {
	int sock_conn, sock_listen, ret;
	struct sockaddr_in serv_adr;
	char peticion[512], respuesta[512];
	
	MYSQL *conn = mysql_init(NULL);
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
	
	for (int i = 0; i < 5; i++) {
		printf("Escuchando...\n");
		sock_conn = accept(sock_listen, NULL, NULL);
		printf("Conexion recibida\n");
		int terminar = 0;
		
		while (!terminar) {
			ret = read(sock_conn, peticion, sizeof(peticion));
			peticion[ret] = '\0';
			
			printf("Peticion: %s\n", peticion);
			
			char username[20] = "";
			char password[20] = "";
			int id_m;
			char *p = strtok(peticion, "/");
			int codigo = atoi(p);
			
			if (codigo != 0 && codigo < 3) {
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
			else if (codigo!=0)
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
			
			if (codigo != 0)
			{
				printf("Respuesta: %s\n", respuesta);
				write(sock_conn, respuesta, strlen(respuesta));
			}
		}
		
		
	}
	mysql_close(conn);
	close(sock_conn);
	return 0;
}
