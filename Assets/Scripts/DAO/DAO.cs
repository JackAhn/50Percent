using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.Common;
using MySql.Data.MySqlClient;

public class DAO : MonoBehaviour
{
    private static DAO dao;
    private MySqlConnection connection = new MySqlConnection("Server=localhost;Database=50Percent;Uid=root;Pwd=1234;");


    public static DAO getInstance()
    {
        if(dao == null)
        {
            dao = new DAO();
        }
        return dao;
    }

    public void open()
    {
        connection.Open();
    }

    public bool insertUser(User user)
    {
        bool val = false;

        return val;
    }


    public void close()
    {
        connection.Close();
    }
}
