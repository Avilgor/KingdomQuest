package firulai.s.project;

import java.io.IOException;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.Statement;

public class InsertarRanking 
{
    
    String[] datos;//jugador/puntos
    
    public InsertarRanking(String data)
    {          
        datos = data.split("/");
    }
    
    public int InsertBDD()
    {
        int result=0;
        try
        {
            Connection conn = Gestor.getConnection();
                     
            String consulta = "SELECT nombreJugador,puntuacion FROM Ranking;";
            PreparedStatement select = null;
                   
            double puntuacion;
            double puntos[] = new double[5];
            String[] jugadores = new String[5];
            puntuacion = Double.parseDouble(datos[1]);
        
            select = conn.prepareStatement(consulta);
            ResultSet resultado = select.executeQuery();   
            for(int i=0;i<5;i++)
            {
               resultado.next();
               jugadores[i] = resultado.getString("nombreJugador");
               puntos[i] = resultado.getDouble("puntuacion");             
               //System.out.println(jugadores[i]);
               //System.out.println(puntos[i]);              
            }
            Gestor.closeConnection(); 
            
            System.out.println(puntos[0]);
            System.out.println(puntos[1]);
            System.out.println(puntos[2]);
            System.out.println(puntos[3]);
            System.out.println(puntos[4]);
            
            if(puntuacion>puntos[0]) //primera posicion
            {
                //sentencia.executeUpdate("UPDATE Ranking SET nombreJugador='"+jugadores[3]+"',puntuacion="+puntos[3]+" WHERE posicion=5;");
                doUpdate(jugadores[1],puntos[1],5);
                
                //sentencia.executeUpdate("UPDATE Ranking SET nombreJugador='"+jugadores[2]+"',puntuacion="+puntos[2]+" WHERE posicion=4;");
                doUpdate(jugadores[2],puntos[2],4);
                
                //sentencia.executeUpdate("UPDATE Ranking SET nombreJugador='"+jugadores[1]+"',puntuacion="+puntos[1]+" WHERE posicion=3;");
                doUpdate(jugadores[3],puntos[3],3);
                
                //sentencia.executeUpdate("UPDATE Ranking SET nombreJugador='"+jugadores[0]+"',puntuacion="+puntos[0]+" WHERE posicion=2;");
                doUpdate(jugadores[4],puntos[4],2);
                
                //sentencia.executeUpdate("UPDATE Ranking SET nombreJugador='"+datos[0]+"',puntuacion="+puntuacion+" WHERE posicion=1;"); 
                doUpdate(datos[0],puntuacion,1);
                result = 1;
                
            }else
            {
                if(puntuacion>puntos[1])//segunda posicion
                {
                    /*sentencia.executeUpdate("UPDATE Ranking SET nombreJugador='"+jugadores[3]+"',puntuacion="+puntos[3]+" WHERE posicion=5;");
                    sentencia = conn.createStatement();
                    sentencia.executeUpdate("UPDATE Ranking SET nombreJugador='"+jugadores[2]+"',puntuacion="+puntos[2]+" WHERE posicion=4;");
                    sentencia = conn.createStatement();
                    sentencia.executeUpdate("UPDATE Ranking SET nombreJugador='"+jugadores[1]+"',puntuacion="+puntos[1]+" WHERE posicion=3;");
                    sentencia = conn.createStatement();
                    sentencia.executeUpdate("UPDATE Ranking SET nombreJugador='"+datos[0]+"',puntuacion="+puntuacion+" WHERE posicion=2;");*/
                    doUpdate(jugadores[2],puntos[2],5);
                    doUpdate(jugadores[3],puntos[3],4);
                    doUpdate(jugadores[4],puntos[4],3);
                    doUpdate(datos[0],puntuacion,2);
                    result = 1;
                }
                else
                {
                  if(puntuacion>puntos[2])//tercera posicion
                    {
                        /*sentencia.executeUpdate("UPDATE Ranking SET nombreJugador='"+jugadores[3]+"',puntuacion="+puntos[3]+" WHERE posicion=5;");
                        sentencia = conn.createStatement();
                        sentencia.executeUpdate("UPDATE Ranking SET nombreJugador='"+jugadores[2]+"',puntuacion="+puntos[2]+" WHERE posicion=4;");
                        sentencia = conn.createStatement();
                        sentencia.executeUpdate("UPDATE Ranking SET nombreJugador='"+datos[0]+"',puntuacion="+puntuacion+" WHERE posicion=3;");*/
                        doUpdate(jugadores[3],puntos[3],5);
                        doUpdate(jugadores[4],puntos[4],4);
                        doUpdate(datos[0],puntuacion,3);
                        result = 1;
                    }
                    else
                    {
                        if(puntuacion>puntos[3])//cuarta posicion
                        {
                            /*sentencia.executeUpdate("UPDATE Ranking SET nombreJugador='"+jugadores[3]+"',puntuacion="+puntos[3]+" WHERE posicion=5;");
                            sentencia = conn.createStatement();
                            sentencia.executeUpdate("UPDATE Ranking SET nombreJugador='"+datos[0]+"',puntuacion="+puntuacion+" WHERE posicion=4;");*/   
                            doUpdate(jugadores[4],puntos[4],5);
                            doUpdate(datos[0],puntuacion,4);
                            result = 1;
                        }
                        else
                        {
                           if(puntuacion>puntos[4])//quinta posicion
                            {
                               //sentencia.executeUpdate("UPDATE Ranking SET nombreJugador='"+datos[0]+"',puntuacion="+puntuacion+" WHERE posicion=5;");                               
                               doUpdate(datos[0],puntuacion,5);
                               result = 1;
                            }
                           else //no entra
                            {
                                result=2;
                            }
                        }
                    }  
                }
            }          
        }catch(Exception e)
        {
            result=3; 
            e.printStackTrace();
        }
        return result;
    }

    private void doUpdate(String player,double puntos,int posicion)
    {
        String consulta = "UPDATE Ranking SET nombreJugador=?,puntuacion=? WHERE puntuacion=?;";
        try
        {
           Connection conn = Gestor.getConnection();
           System.out.println(player+"/"+puntos+"/"+posicion);
           PreparedStatement sentencia = conn.prepareStatement(consulta);
           sentencia.setString(1,player);
           sentencia.setDouble(2,puntos);
           sentencia.setInt(3,posicion);          
           sentencia.executeUpdate();
           Gestor.closeConnection();
        }catch(Exception e)       
        {
            e.printStackTrace();
        }
    }  
}