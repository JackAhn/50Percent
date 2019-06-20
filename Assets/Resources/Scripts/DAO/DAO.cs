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

    public User checkUser(string id, string pw)
    {
        string query = "select * from user where id='" + id + "' and password='" + pw + "'";
        Debug.Log(query);
        MySqlCommand command = new MySqlCommand(query, connection);
        MySqlDataReader reader = command.ExecuteReader();
        try
        {
            if (reader.Read())
            {
                User val = new User
                {
                    id = reader.GetInt32("no"),
                    userId = reader.GetString("id"),
                    nickname = reader.GetString("nickname")
                };
                Debug.Log(val.userId);
                return val;
            }
            else
            {
                return null;
            }
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
        reader.Close();
        return null;

    }
    public bool insertUser(User user)
    {
        bool val = false;
        string query = "insert into user values('0', '" + user.userId + "', '" + user.nickname + "', '" + user.pw + "')";
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

    public bool insertRank(Rank rank)
    {
        bool val = false;
        string query = "insert into `rank` values('0', '" + rank.nickname + "', '" + rank.score + "')";
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
        catch (Exception e)
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
