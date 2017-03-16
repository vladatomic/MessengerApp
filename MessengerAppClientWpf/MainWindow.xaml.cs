using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MessengerAppClientWpf.MessageAppServiceReference;

namespace MessengerAppClientWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary> 
    /// 
    /// 
    /// Implmentiramo callback interface servisa MessengerService da bi servis 
    /// mogao da pozove metodu SendMessageToAllClients na client-u
    /// 
    [CallbackBehavior(UseSynchronizationContext =false)]
    public partial class MainWindow :Window,MessageAppServiceReference.IMessengerServiceCallback
    {
        private InstanceContext instanceContext;
        private MessageAppServiceReference.MessengerServiceClient clientProxy;
        private ObservableCollection<ChatMessege> conversationList;

        //Inicijalizacija DataContext na ObservableCollection tipa ChatMessage
        //
        public MainWindow()
        {
            InitializeComponent();
            instanceContext=new InstanceContext(this);
            clientProxy = new MessengerServiceClient(instanceContext);
            conversationList = new ObservableCollection<ChatMessege>();
            this.DataContext = conversationList;
            btnPostMessage.Visibility = Visibility.Hidden;
        }

        //Unosise se Nickname korisnika koji je obavezan i izvršava se metoda RegisterChatUser na servisu 
        //koja registruje korisnika na server za chat tako što skladišti Nickname i Callback channel do clienta
        //Tek kada se korisnik registruje pojavljuje se taster za Post poruke
        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tBoxNickName.Text) || string.IsNullOrWhiteSpace(tBoxNickName.Text))
            {
                MessageBox.Show("Nickname can not be empty!!!");
                return;
            }
            string user = tBoxNickName.Text;
            clientProxy.RegisterChatUser(new MessengerAppUser() { NickName=user});
            btnPostMessage.Visibility = Visibility.Visible;
        }

        //Unešena poruka ne može biti prazna i poziva se metoda PostMessage na servisu
        //koja uz pomoć callback metode svim registrovanim korisnicima šalje poruku , osim onome koji je šalje
        //Poruka koji je uneo korisnik se ispisuje u ListBox konverzacije da bi korisnik ispratio i svoje poruke
        //i fokus se stavlja na zadnju stavku u ListBox-u
        private void btnPostMessage_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tBoxMessageText.Text) || string.IsNullOrWhiteSpace(tBoxMessageText.Text))
            {
                MessageBox.Show("Message can not be empty!!!");
                return;
            }
            string user = tBoxNickName.Text;
            string messege = tBoxMessageText.Text;
            var time = DateTime.Now;
            MessengerAppUser messengarUser = new MessengerAppUser() { NickName =user };
            MessengerAppMessage msg = new MessengerAppMessage();
            msg.User = messengarUser;
            msg.Message = messege;
            msg.CreateAt = time;
            clientProxy.PostMessage(msg);
            messengarUser.NickName = "currentUser";
            AddToConversationList(msg);
            lBox.ScrollIntoView(lBox.Items[lBox.Items.Count-1]);
            tBoxMessageText.Clear();
            tBoxMessageText.Focus();
        }
         //Callback metoda servisa tj. ovu metodu sevis poziva na klijentu u procesu callback-a
        public void SendMessageToAllClients(MessengerAppMessage message)
        {
            try
            {
                Dispatcher.BeginInvoke(
                       (Action)( () => {
                           AddToConversationList(message);
                       } ));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        //Metoda koja dodaje poruke u ObservableCollection  conversationList
        public void AddToConversationList(MessengerAppMessage message)
        {
            ChatMessege msg = new ChatMessege();
            msg.CurrentUserMessage = tBoxMessageText.Text; 
            msg.ChatMemberNickName = message.User.NickName;
            msg.ChatMemberMessage = message.Message;
            conversationList.Add(msg);
            lBox.ScrollIntoView(lBox.Items[lBox.Items.Count - 1]);
        }
    }
}
