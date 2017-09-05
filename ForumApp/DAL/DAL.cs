namespace DataAccessLayer
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    public class DAL : IDAL
    {
        private string connectionString;

        public DAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Создание сообщения.
        /// </summary>
        public int CreateMessage(Message mes)
        {
            try
            {
                if (mes.TextMessage.Trim(' ').Equals(string.Empty))
                {
                    return 0;
                }

                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    mes.user.UserID = SelectUserID(mes.MessageAuthor);
                    var command = connection.CreateCommand();
                    command.CommandText = "[ForumDB].[dbo].[CreateMessage]";
                    command.CommandType = CommandType.StoredProcedure;

                    Parameter(command, "@TextMessage", mes.TextMessage, DbType.String);
                    Parameter(command, "@UserID", mes.user.UserID, DbType.Int32);
                    Parameter(command, "@TopicID", mes.TopicID, DbType.Int32);

                    return command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Создание темы, вместе с первым сообщением.
        /// </summary>
        public int CreateTopic(Topic topic)
        {
            try
            {
                if (ExistTopic(topic.TopicName) || topic.TopicName.Trim(' ').Equals(string.Empty) || topic.TopicMessage.Trim(' ').Equals(string.Empty))
                {
                    return 0;
                }

                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    var command = connection.CreateCommand();
                    command.CommandText = "[ForumDB].[dbo].[CreateTopic]";
                    command.CommandType = CommandType.StoredProcedure;
                    Parameter(command, "@TopicName", topic.TopicName, DbType.String);
                    Parameter(command, "@UserID", SelectUserID(topic.mes.MessageAuthor), DbType.Int32);

                    if (command.ExecuteNonQuery() == 0)
                    {
                        return 0;
                    }

                    topic.mes.TopicID = SelectMaxTopicID();
                    topic.mes.TextMessage = topic.TopicMessage;

                    return CreateMessage(topic.mes);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Создание пользователя.
        /// </summary>
        public int CreateUser(User user)
        {
            try
            {
                if (ExistUser(user.UserName) || user.UserName.Trim(' ').Equals(string.Empty) || user.Password.Trim(' ').Equals(string.Empty))
                {
                    return 0;
                }

                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "[ForumDB].[dbo].[CreateUser]";
                    command.CommandType = CommandType.StoredProcedure;
                    Parameter(command, "@UserName", user.UserName, DbType.String);
                    Parameter(command, "@Password", user.Password, DbType.String);

                    return command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Удаление сообщения.
        /// </summary>
        public int DeleteMessage(int messageID)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "[ForumDB].[dbo].[DeleteMessage]";
                    command.CommandType = CommandType.StoredProcedure;
                    Parameter(command, "@MessageID", messageID, DbType.Int32);

                    return command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Изменение сообщения.
        /// </summary>
        public int EditMessage(Message mes)
        {
            try
            {
                if (mes.TextMessage.Trim(' ').Equals(string.Empty))
                {
                    return 0;
                }

                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "[ForumDB].[dbo].[EditMessage]";
                    command.CommandType = CommandType.StoredProcedure;
                    Parameter(command, "@TextMessage", mes.TextMessage, DbType.String);
                    Parameter(command, "@MessageID", mes.MessageID, DbType.Int32);

                    return command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Изменение названия темы.
        /// </summary>
        public int EditTopic(Topic topic)
        {
            try
            {
                if (ExistTopic(topic.TopicName) || topic.TopicName.Trim(' ').Equals(string.Empty))
                {
                    return 0;
                }

                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "[ForumDB].[dbo].[EditTopic]";
                    command.CommandType = CommandType.StoredProcedure;
                    Parameter(command, "@TopicName", topic.TopicName, DbType.String);
                    Parameter(command, "@TopicID", topic.TopicID, DbType.Int32);

                    return command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Изменение роли пользователя.
        /// </summary>
        public int EditTypeUser(int userID, int typeUserID)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "[ForumDB].[dbo].[EditTypeUser]";
                    command.CommandType = CommandType.StoredProcedure;
                    Parameter(command, "@TypeUserID", typeUserID, DbType.Int32);
                    Parameter(command, "@UserID", userID, DbType.Int32);

                    return command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Проверка на наличии темы с таким же названием.
        /// </summary>
        public bool ExistTopic(string TopicName)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "[ForumDB].[dbo].[ExistTopic]";
                    command.CommandType = CommandType.StoredProcedure;
                    Parameter(command, "@TopicName", TopicName, DbType.String);

                    return ((int)command.ExecuteScalar() > 0);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Проверка на наличие пользователя с таким же именем.
        /// </summary>
        public bool ExistUser(string UserName)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "[ForumDB].[dbo].[ExistUser]";
                    command.CommandType = CommandType.StoredProcedure;
                    Parameter(command, "@UserName", UserName, DbType.String);

                    return ((int)command.ExecuteScalar() > 0);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Выбор ID последней темы.
        /// </summary>
        public int SelectMaxTopicID()
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "[ForumDB].[dbo].[SelectMaxTopicID]";
                    command.CommandType = CommandType.StoredProcedure;

                    return (int)command.ExecuteScalar();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Выбор информации о последнем сообщении в теме.
        /// </summary>
        public Message SelectMessInfo(int topicID)
        {
            try
            {
                Message mes = new Message();
                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "[ForumDB].[dbo].[SelectMessInfo]";
                    command.CommandType = CommandType.StoredProcedure;
                    Parameter(command, "@TopicID", topicID, DbType.Int32);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            mes.MessageDate = reader.GetDateTime(0);
                            mes.CountMessages = reader.GetInt32(1);
                        }
                    }

                    return mes;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Выбор текста сообщения по ID.
        /// </summary>
        public string SelectTextMessage(int messageID)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "[ForumDB].[dbo].[SelectTextMessage]";
                    command.CommandType = CommandType.StoredProcedure;
                    Parameter(command, "@MessageID", messageID, DbType.Int32);

                    return (string)command.ExecuteScalar();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Выбор темы по ID.
        /// </summary>
        /// <param name="topicID"></param>
        public string SelectTopicName(int topicID)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "[ForumDB].[dbo].[SelectTopicName]";
                    command.CommandType = CommandType.StoredProcedure;
                    Parameter(command, "@TopicID", topicID, DbType.Int32);

                    return (string)command.ExecuteScalar();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Выбор роли пользователя.
        /// </summary>
        public string[] SelectTypeUser(string userName)
        {
            try
            {
                string[] role = new string[] { };

                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "[ForumDB].[dbo].[SelectTypeUser]";
                    command.CommandType = CommandType.StoredProcedure;
                    Parameter(command, "@UserName", userName, DbType.String);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            role = new string[] { reader.GetString(0) };
                        }
                    }  
                }

                return role;    
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Выбор ID роли по имени пользователя.
        /// </summary>
        public int SelectTypeUserID(string typeUser)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "[ForumDB].[dbo].[SelectTypeUserID]";
                    command.CommandType = CommandType.StoredProcedure;
                    Parameter(command, "@TypeUser", typeUser, DbType.String);

                    return (int)command.ExecuteScalar();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Выбор ID пользователя по имени.
        /// </summary>
        public int SelectUserID(string userName)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "[ForumDB].[dbo].[SelectUserID]";
                    command.CommandType = CommandType.StoredProcedure;
                    Parameter(command, "@UserName", userName, DbType.String);

                    return (int)command.ExecuteScalar();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Выбор имени пользователя по ID.
        /// </summary>
        public string SelectUserName(int userID)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "[ForumDB].[dbo].[SelectUserName]";
                    command.CommandType = CommandType.StoredProcedure;
                    Parameter(command, "@UserID", userID, DbType.Int32);

                    return (string)command.ExecuteScalar();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Выбор всех сообщений в теме.
        /// </summary>
        public List<Message> ShowMessages(int topicID)
        {
            try
            {
                List<Message> list = new List<Message>();
                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "[ForumDB].[dbo].[ShowMessages]";
                    command.CommandType = CommandType.StoredProcedure;
                    Parameter(command, "@TopicID", topicID, DbType.Int32);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Message mes = new Message();
                            mes.MessageID = reader.GetInt32(0);
                            mes.MessageDate = reader.GetDateTime(1);
                            mes.TextMessage = reader.GetString(2);
                            mes.MessageAuthor = SelectUserName(reader.GetInt32(3));
                            mes.TopicID = reader.GetInt32(4);
                            mes.TopicName = SelectTopicName(mes.TopicID);
                            mes.user = ShowUserInfo(mes.MessageAuthor);
                            list.Add(mes);
                        }
                    }
                }

                return list;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Выбор всех сообщений пользователя.
        /// </summary>
        public List<Message> ShowMessagesByOneUser(int userID)
        {
            try
            {
                List<Message> list = new List<Message>();
                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "[ForumDB].[dbo].[ShowMessagesByOneUser]";
                    command.CommandType = CommandType.StoredProcedure;
                    Parameter(command, "@UserID", userID, DbType.Int32);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Message mes = new Message();
                            mes.MessageID = reader.GetInt32(0);
                            mes.MessageDate = reader.GetDateTime(1);
                            mes.TextMessage = reader.GetString(2);
                            mes.MessageAuthor = SelectUserName(reader.GetInt32(3));
                            mes.TopicID = reader.GetInt32(4);
                            mes.TopicName = SelectTopicName(mes.TopicID);
                            mes.user = ShowUserInfo(mes.MessageAuthor);
                            list.Add(mes);
                        }
                    }
                }

                return list;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Выбор всех тем.
        /// </summary>
        public List<Topic> ShowTopics()
        {
            try
            {
                List<Topic> list = new List<Topic>();

                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "[ForumDB].[dbo].[ShowTopics]";
                    command.CommandType = CommandType.StoredProcedure;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int topicID = reader.GetInt32(0);
                            Message mes = SelectMessInfo(topicID);
                            Topic topic = new Topic(topicID, reader.GetString(1), reader.GetString(2), mes.MessageDate, mes.CountMessages);
                            list.Add(topic);
                        }
                    }
                }

                return list;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Выбор всех ролей.
        /// </summary>
        /// <returns></returns>
        public List<string> ShowTypeUsers()
        {
            try
            {
                List<string> list = new List<string>();

                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "[ForumDB].[dbo].[ShowTypeUsers]";
                    command.CommandType = CommandType.StoredProcedure;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(reader.GetString(0));
                        }
                    }
                }

                return list;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Выбор информации о пользователе.
        /// </summary>
        public User ShowUserInfo(string userName)
        {
            try
            {
                User user = new User();
                user.UserID = SelectUserID(userName);
                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "[ForumDB].[dbo].[ShowUserInfo]";
                    command.CommandType = CommandType.StoredProcedure;
                    Parameter(command, "@UserID", user.UserID, DbType.Int32);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            user.UserName = reader.GetString(0);
                            user.Password = reader.GetString(1);
                            user.RegistrationDate = reader.GetDateTime(2);
                            user.TypeUser = reader.GetString(3);
                            user.CountMessages = reader.GetInt32(4);
                        }
                    }
                }

                return user;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Выбор всех пользователей.
        /// </summary>
        public List<string> ShowUsers()
        {
            try
            {
                List<string> list = new List<string>();

                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "[ForumDB].[dbo].[ShowUsers]";
                    command.CommandType = CommandType.StoredProcedure;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(reader.GetString(0));
                        }
                    }
                }

                return list;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Проверка имени и пароля пользователя.
        /// </summary>
        public bool ValidateUser(User user)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "[ForumDB].[dbo].[ValidateUser]";
                    command.CommandType = CommandType.StoredProcedure;
                    Parameter(command, "@UserName", user.UserName, DbType.String);
                    Parameter(command, "@Password", user.Password, DbType.String);

                    return ((int)command.ExecuteScalar() > 0);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Добавление параметров в команду.
        /// </summary>
        private void Parameter<T>(IDbCommand command, string name, T value, DbType type)
        {
            IDbDataParameter Param = command.CreateParameter();
            Param.ParameterName = name;
            Param.Value = value;
            Param.DbType = type;
            command.Parameters.Add(Param);
        }
    }
}
