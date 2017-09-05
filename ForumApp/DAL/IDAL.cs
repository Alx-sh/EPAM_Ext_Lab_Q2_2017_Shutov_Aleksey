using DataAccessLayer.Models;
using System.Collections.Generic;

namespace DataAccessLayer
{
    interface IDAL
    {
        string[] SelectTypeUser(string userName);

        List<string> ShowTypeUsers();

        List<string> ShowUsers();

        bool ValidateUser(User user);

        int CreateUser(User user);

        int SelectUserID(string userName);

        int SelectTypeUserID(string typeUser);

        string SelectUserName(int userID);

        string SelectTopicName(int topicID);

        string SelectTextMessage(int messageID);

        int SelectMaxTopicID();

        int CreateMessage(Message mes);

        int EditMessage(Message mes);

        int DeleteMessage(int messageID);

        int CreateTopic(Topic topic);

        int EditTopic(Topic topic);

        Message SelectMessInfo(int topicID);

        User ShowUserInfo(string userName);

        List<Message> ShowMessages(int topicID);

        List<Message> ShowMessagesByOneUser(int userID);

        List<Topic> ShowTopics();

        int EditTypeUser(int userID, int typeUserID);

        bool ExistUser(string UserName);

        bool ExistTopic(string TopicName);
    }
}
