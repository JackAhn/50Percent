using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.Common;
using MySql.Data.MySqlClient;
using System;

public class DAO : MonoBehaviour
{
    private static DAO dao;
    private MySqlConnection connection = new MySqlConnection("Server=127.0.0.1;Database=50percent;UserId=root;Password=1234;");


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

    public bool checkUser(string id, string pw)
    {
        bool val = false;
        string query = "select * from user where id='" + id + "' and pw='" + pw + "'";
        MySqlCommand command = new MySqlCommand(query, connection);
        try
        {
            if (command.ExecuteReader().NextResult())
            {
                val = true;
            }
            else
            {
                val = false;
            }
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
            val = false;
        }
        return val;
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
