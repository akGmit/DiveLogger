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
        private string title;
        private string post;

        public string Title
        {
            get { return title; }
            set { SetValue(ref title, value); }
        }
        public string Post
        {
            get { return post; }
            set { SetValue(ref post, value); }
        }

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

        public static void SendPost(PostViewModel post)
        {
            DBCollection.SendPost(post);
        }
    }
}
