using ClassLibrary.Data;
using ClassLibrary.Entities;
using ClassLibTeam01.Data.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Business
{
    public class Posts
    {
       
        public static DataTable GetPostsDataTable()
        {
            var dt = new DataTable();
            try
            {
                var postsData = new PostsData();
                var result = postsData.SelectPosts();
                dt = result.DataTable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return dt;
        }
        public static InsertResult AddPost(Post post)
        {
            var result = new InsertResult();
            try
            {
                //Business.Students
                //Data.StudentsData.Insert
                //Frmwrk.SqlCommands.InsertRecord
                var gamesData = new PostsData();
                gamesData.Insert(post);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
    }
}
