package firulai.s.project;

import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.IOException;
import java.net.ServerSocket;
import java.net.Socket;
import java.nio.ByteBuffer;
import java.sql.PreparedStatement;
import java.util.Scanner;
import java.util.logging.Level;
import java.util.logging.Logger;

public class Server {

    final static int opcionA = 0; //Para cerrar Server
    final static int opcionB = 1; //Insertar en historial
    final static int opcionC = 2; //Insertar en Ranking
    final static int opcionD = 3; //Recuperar Ranking

    static int puertoOrigen = 20001;
    static boolean fin = false; //hay que hacer que cambie

    public static void main(String[] args) 
    {
        /*Thread a = new Thread(new Runnable() 
        {
            @Override
            public void run() 
            {
                try 
                {
                    ServerSocket ssk = new ServerSocket(puertoOrigen);
                    while (fin == false) 
                    {
                        Socket sk = ssk.accept();
                        Servidor servidor = new Servidor(sk);
                        servidor.start();
                    }
                } catch (IOException ex) 
                {
                    Logger.getLogger(Servidor.class.getName()).log(Level.SEVERE, null, ex);
                }
                System.out.println("Server closed.");
            }

        });
        a.start();
        Scanner sc= new Scanner(System.in);
        System.out.println("Escribe S para salir...");
        String exit = sc.nextLine();
        if(exit.equals("s"))
        {
            fin=true;
        }*/
        try 
        {
            ServerSocket ssk = new ServerSocket(puertoOrigen);
            while (fin == false) 
            {
                Socket sk = ssk.accept();
                Servidor servidor = new Servidor(sk);
                servidor.start();
            }
        } catch (IOException ex) 
        {
            Logger.getLogger(Servidor.class.getName()).log(Level.SEVERE, null, ex);
        }
        System.out.println("Server closed.");
    }

    static class Servidor extends Thread 
    {
        Socket sk;
        DataOutputStream os;
        DataInputStream is;

        Servidor(Socket sk) 
        {
            this.sk = sk;
        }

        public void run() 
        {
            System.out.println("Connection succes!");
            try 
            {
                os = new DataOutputStream(sk.getOutputStream());
                is = new DataInputStream(sk.getInputStream());

                int a = is.readByte();
                //System.out.println(a);

                byte[] bites = new byte[8];

                switch (a) 
                {
                    case opcionA: //Cierra el juego
                        System.out.println("Game Closed"); break;
                    case opcionB: //Insert Historial
                        os.write(bites);
                        System.out.println("Opcion 1.");
                        Historial();
                        break;
                    case opcionC: //Insert Ranking
                        os.write(bites);
                        System.out.println("Opcion 2.");
                        //Ranking();
                        break;
                    case opcionD: //Get Ranking
                        System.out.println("Opcion 3.");
                        getRanking();
                        break;
                }

            } catch (Exception e) 
            {
                e.printStackTrace();
            }
            System.out.println("Connection closed.");
        }
        
        private void Historial()
        {
            try
            {
                byte[] info = new byte[500];
                is.read(info);
                String datos = new String(info);

                InsertarDatos insert = new InsertarDatos(datos);

                if (insert.InsertBDD()) 
                {
                    System.out.println("Datos insertados.");
                } else 
                {
                    System.out.println("Error al insertar.");
                }
            }catch(Exception e)
            {
                e.printStackTrace();
            }
        }
        
        private void Ranking()
        {
            try
            {             
                byte[] info = new byte[500];
                is.read(info);
                String datos = new String(info);
                int result;
                
                InsertarRanking insert = new InsertarRanking(datos);
                result = insert.InsertBDD();
                if(result==1) 
                {
                    System.out.println("Jugador introducido.");
                } else 
                {
                    if(result==2)
                    {
                        System.out.println("No entra al ranking.");
                    }else
                    {
                        System.out.println("Error.");
                    }                  
                }
                
            }catch(Exception e)
            {
                e.printStackTrace();
            }
        }
        
        private void getRanking()
        {
            String[] datos;
            byte[] next = new byte[5];
            RecuperarRanking Rng = new RecuperarRanking();
            datos = Rng.getRank();
            try
            {
                os.writeBytes(datos[0]);
                is.read(next);
                
                os.writeBytes(datos[1]);
                is.read(next);
                
                os.writeBytes(datos[2]);
                is.read(next);              

                os.writeBytes(datos[3]);
                is.read(next);
                
                os.writeBytes(datos[4]);
                System.out.println("Ranking enviado.");
            }
            catch(Exception e)
            {
                System.out.println("Error al enviar.");
                e.printStackTrace();
            }            
        }
    }
}