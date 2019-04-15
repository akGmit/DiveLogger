using DiveLogger.Utils;
using DiveLogger.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DiveLogger.ViewModels
{
    public class PostViewModel : BaseViewModel
    {
        //private string title;
        //private string post;

        public string Title { get; set; }
        public string Post { get; set; }

        public PostViewModel() { }

        public PostViewModel(string title, string post)
        {
            Title = title;
            Post = post;
        }

        public static async System.Threading.Tasks.Task<ObservableCollection<PostViewModel>> GetPostsAsync()
        {
            return await DBCollection.GetPostsAsync();
        }

        public static void SendPost(PostViewModel Post)
        {
            DBCollection.SendPost(Post);
        }
    }
}
