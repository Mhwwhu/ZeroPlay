using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using ZeroPlay.Model;
using ZeroPlay.Util;
using ZeroPlay.ViewModel;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ZeroPlay.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public  partial class ChatPage : Page
    {
        public ChatViewModel ViewModel => App.GetRequiredService<ChatViewModel>() ??
            throw new ApplicationException("Can not load Chat ViewModel.");
        private ScrollViewer _messageScrollViewer;

        public ChatPage()
        {
            this.InitializeComponent();
            // �� ViewModel �󶨵�ҳ��� DataContext
            this.DataContext = ViewModel;

            // Find ScrollViewer after page is loaded
            _messageScrollViewer = MessageListView.FindDescendant<ScrollViewer>();
            ViewModel.SetScrollViewer(_messageScrollViewer);
        }

        private void FriendListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ViewModel.IsChatVisible = Visibility.Visible;
            ViewModel.SelectedFriend = (Friend)e.AddedItems[0];
            ViewModel.LoadMessages();
        }
        // ��������Ϣ

    }
}
