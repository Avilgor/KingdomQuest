package firulai.s.project;

import java.util.Properties;
import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStream;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;

public class Gestor
{
    private static final String DRIVER_CLASS_NAME;
    private static final String DRIVER_URL;
    private static final String USER;
    private static final String PASSWORD;
    private static Connection connection;

    static 
    {
        Properties prop = new Properties();
        try 
        {
            InputStream entrada = new FileInputStream("config.properties");
            prop.load(entrada);
        } catch (IOException e) 
        {
            System.out.println("Error al cargar archivo.");
        }
        DRIVER_CLASS_NAME = prop.getProperty("driver_class_name");
        DRIVER_URL = prop.getProperty("driver_url");
        USER = prop.getProperty("user");
        PASSWORD = prop.getProperty("password");

        try 
        {
            Class.forName(DRIVER_CLASS_NAME);
        } catch (ClassNotFoundException e) 
        {
            System.out.println("Error al cargar driver: " + DRIVER_CLASS_NAME);
        }
    }

    public static Connection getConnection() throws SQLException 
    {
        if (connection == null)
           connection = DriverManager.getConnection(DRIVER_URL, USER, PASSWORD);
        return connection;
    }
    public static void closeConnection() throws SQLException
    {
        connection.close();
        connection = null;
    }
}
