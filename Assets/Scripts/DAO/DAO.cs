using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.Common;
using MySql.Data.MySqlClient;
using System;

public class DAO : MonoBehaviour
{
    private static DAO dao;
    private MySqlConnection connection = new MySqlConnection("Server=localhost;Database=50percent;Uid=root;Pwd=1234;");


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
        string query = "insert into user values('0', '"+user.userId+"', '"+user.nickname+"', '"+user.pw+"')";
        MySqlCommand command = new MySqlCommand(query, connection);
        try
        {
            if (command.ExecuteNonQuery() == 1)
            {
                val = true;
            }
            else
            {
                val = false;
            }
        }
        catch(Exception e)
        {
            Debug.Log(e.Message);
            val = false;
        }
        return val;
    }


    public void close()
    {
        connection.Close();
    }
}
