using DiveLogger.ViewModels;
using DiveLogger.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace DiveLogger.ViewModels
{
    class DiversBoardViewModel : BaseViewModel
    {
        public ICommand ShowCreatePostCommand { get; private set; }
        public ICommand SendPostCommand { get; private set; }

        private ObservableCollection<PostViewModel> posts = new ObservableCollection<PostViewModel>();
        public ObservableCollection<PostViewModel> Posts
        {
            get { return posts; }
            private set { SetValue(ref posts, value); }
        }
        
        private PostViewModel newPost;
        public PostViewModel NewPost
        {
            get { return newPost; }
            set { SetValue(ref newPost, value); }
        }

        private bool showPostForm = false;
        public bool ShowPostForm
        {
            get => showPostForm;
            set { SetValue(ref showPostForm, value); }
        }

        public DiversBoardViewModel()
        {
            ShowCreatePostCommand = new Command(IsHiddenPostForm);
            SendPostCommand = new Command<PostViewModel>(SendPost);
            newPost = new PostViewModel();
            GetPostsAsync();
        }

        private async void GetPostsAsync()
        {
            Posts = await PostViewModel.GetPostsAsync();
        }

        public void SendPost(PostViewModel post)
        {
            PostViewModel.SendPost(post);
            Posts.Add(post);
            NewPost = new PostViewModel();
            IsHiddenPostForm();
        }

        private void IsHiddenPostForm() => ShowPostForm = !ShowPostForm;
    }
}
