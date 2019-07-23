package firulai.s.project;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;


public class RecuperarRanking 
{
    Connection conn = null;
    String[] datos;//posicion/jugador/puntos
    int puntos;
    
    public RecuperarRanking()
    {
        try
        {
            conn = Gestor.getConnection();           
        }catch(Exception e)
        {
            e.printStackTrace();
        }
    }
    
    public String[] getRank()
    {
        String consulta = "SELECT * FROM Ranking;";
        PreparedStatement sentencia = null;
        try
        {
            sentencia = conn.prepareStatement(consulta);
            ResultSet resultado = sentencia.executeQuery();
            for(int i=0;i<5;i++)
            {
               resultado.next();
                datos[i] = resultado.getString("posicion")+"/"+resultado.getString("nombreJugador")+"/"+
                    resultado.getDouble("puntuacion"); 
            }
            Gestor.closeConnection(); 
            
        }catch(SQLException e)
        {
            
        }
        return datos;
    }
}