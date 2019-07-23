package firulai.s.project;

import java.sql.Connection;
import java.sql.PreparedStatement;


public class InsertarDatos
{
    Connection conn = null;
    String[] datos;//jugador/puntos
    int puntos;
    public InsertarDatos(String data)
    {
        try
        {
            conn = Gestor.getConnection();
            datos = data.split("/");
        }catch(Exception e)
        {
            e.printStackTrace();
        }
    }
    
    public boolean InsertBDD()
    {
        boolean correct;
        String consulta = "INSERT INTO Historial VALUES (null,?,?);";
        PreparedStatement sentencia = null;
        //System.out.println(datos[0]+"/"+datos[1]+"/"+datos[2]);
        try
        {
            sentencia = conn.prepareStatement(consulta);
            sentencia.setString(1,datos[0]);
            sentencia.setDouble(2,Double.parseDouble(datos[1]));
            //sentencia.setString(3,datos[2]);
            sentencia.executeUpdate();            
            correct = true;
            Gestor.closeConnection(); 
        }catch(Exception e)
        {
            correct=false;
            e.printStackTrace();          
       }
        return correct;
    }
}