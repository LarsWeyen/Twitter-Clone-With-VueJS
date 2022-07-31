using ClassLibrary.Entities;
using ClassLibTeam01.Data.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Data
{
    public class PostsData : SqlCommands, ISqlCommands<Post>
    {
        private const string tableName = "Posts";
        public PostsData() : base(tableName)
        {
        }

        public InsertResult Insert(Post post)
        {
            var result = new InsertResult();
            try
            {
                //SQL Command
                StringBuilder insertQuery = new StringBuilder();
                insertQuery.Append($"Insert INTO {tableName} ");
                insertQuery.Append($"(UserID, Title, Image, Date) VALUES ");
                insertQuery.Append($"(@UserID, @Title, @Image, @Date); ");

                using (SqlCommand insertCommand = new SqlCommand(insertQuery.ToString()))
                {
                    insertCommand.Parameters.Add("@UserID", System.Data.SqlDbType.VarChar).Value = post.UserID;
                    insertCommand.Parameters.Add("@Title", System.Data.SqlDbType.VarChar).Value = post.Title;                 
                    insertCommand.Parameters.Add("@Image", System.Data.SqlDbType.VarChar).Value = !string.IsNullOrEmpty(post.Image) ? post.Image : (object)DBNull.Value; 
                    insertCommand.Parameters.Add("@Date", System.Data.SqlDbType.VarChar).Value = post.Date;                 
                    result = InsertRecord(insertCommand);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return result;
        }

        public SelectResult Select()
        {
            throw new NotImplementedException();
        }

        public SelectResult SelectPosts()
        {
            var result = new SelectResult();
            string query = $"Select * from Posts order by PostID desc";
            base.SelectRecords(query);
            result = (SelectResult)base.BaseResult;
            return result;
        }
    }
}
